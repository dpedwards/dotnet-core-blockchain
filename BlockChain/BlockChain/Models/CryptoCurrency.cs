using Newtonsoft.Json;
using RSA;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace BlockChain.Models
{

   /**
    * Used to define CryptoCurrency
    * 
    * @author Davain Pablo Edwards
    * @license MIT 
    * @version 1.0
    */
    public class CryptoCurrency
    {

        // Initial current transactions list 
        private List<Transaction> _currentTransactions = new List<Transaction>();

        // Initial blockchain list 
        private List<Block> _chain = new List<Block>();

        // Initial of node list 
        private List<Node> _nodes = new List<Node>();

        private Block _lastBlock => _chain.Last();
        
        public string NodeId { get; private set; }
        static int blockCount = 0;
        static decimal reward = 50; // Set test reward value

        static string minerPrivateKey = "";
        static Wallet _minersWallet = RSA.RSA.KeyGenerate();

        /*
         * Constructor 
         */ 
        public CryptoCurrency()
        {
            // Set test public / private keys
            minerPrivateKey = "KwdUArshaG5LjrY5bji5oJMLvWfwfxkdJAHNYXhf8A49AS89Csi3";//_minersWallet.PrivateKey; 
            NodeId = "1EDvdbQVNEtEvSsUpwunpjbGoZa3SCnkUu"; //_minersWallet.PublicKey; 

            // Initial transaction
            var transaction = new Transaction { Sender = "0", Recipient = NodeId, Amount = 50, Fees = 0, Signature = "" };
            _currentTransactions.Add(transaction);

            CreateNewBlock(proof: 100, previousHash: "1"); // Genesis block 
        }

        /*
         * CreateNewBlock() Method to create new block 
         * 
         * @param proof 
         * @param previousHash
         * @return block
         */
        private Block CreateNewBlock(int proof, string previousHash = null)
        {
            var block = new Block
            {
                Index = _chain.Count,
                TimeStamp = DateTime.Now,
                Transactions = _currentTransactions.ToList(),
                Proof = proof,
                PreviousHash = previousHash ?? GetHash(_chain.Last())
            };

            _currentTransactions.Clear();
            _chain.Add(block);
            return block;
        }

        /*
         * GetHash() Method to get block hashes 
         * 
         * @param block
         * @return blockText
         */ 
        private string GetHash(Block block)
        {
            string blockText = JsonConvert.SerializeObject(block);
            return GetSha256(blockText);
        }

        /*
         * GetSha256() Method to get SHA (Secure Hash Algorithm ) hash
         * 
         * @param blockText
         * @return hasBuilder.ToString()
         */ 
        private string GetSha256(string blockText)
        {
            var sha256 = new SHA256Managed();
            var hasBuilder = new StringBuilder();

            byte[] bytes = Encoding.Unicode.GetBytes(blockText);
            byte[] hash = sha256.ComputeHash(bytes);

            foreach (byte x in hash)
                hasBuilder.Append($"{x:x2}");

            return hasBuilder.ToString();
        }

        /*
        * CreateProofOfWork() Method for Proof-of-Work (PoW) concept
        * 
        * @param previousHash
        * @return proof
        */
        private int CreateProofOfWork(string previousHash)
        {
            int proof = 0;
            while (!IsValidProof(_currentTransactions, proof, previousHash))
                proof++;

            if (blockCount == 10)
            {
                blockCount = 0;
                reward = reward / 2;
            }

            var transaction = new Transaction { Sender = "0", Recipient = NodeId, Amount = reward, Fees = 0, Signature = "" };
            _currentTransactions.Add(transaction);

            blockCount++;
            return proof;
        }

        /*
         * IsValidProof() Method for PoW difficulty
         * 
         * @param transactions
         * @param proof
         * @param previousHash
         * @return result.StartsWith("")
         */
        private bool IsValidProof(List<Transaction> transactions, int proof, string previousHash)
        {
            var signatures = transactions.Select(x => x.Signature).ToArray();
            string guess = $"{signatures}{proof}{previousHash}";
            string result = GetSha256(guess);

            return result.StartsWith("00"); // difficulty
        }

        /*
         * VerifyTransactionSignature() Method to validate transaction signature 
         * 
         * @param transaction
         * @param signedMessage
         * @param publicKey
         * @return verified
         */
        public bool VerifyTransactionSignature(Transaction transaction, string signedMessage, string publicKey)
        {
            string originalMessage = transaction.ToString();
            bool verified = RSA.RSA.Verify(publicKey, originalMessage, signedMessage);

            return verified;
        }

        /*
         * TransactionByAddress() Method to check all transactions of particular owner address
         * 
         * @param ownerAddress
         * @return transactions 
         */
        private List<Transaction> TransactionByAddress(string ownerAddress)
        {
            List<Transaction> transactions = new List<Transaction>();
            foreach (var block in _chain.OrderByDescending(x => x.Index))
            {
                var ownerTransactions = block.Transactions.Where(x => x.Sender == ownerAddress || x.Recipient == ownerAddress).ToList();
                transactions.AddRange(ownerTransactions);
            }
            return transactions;
        }

        /*
         * HasBalance() Method to check balance 
         * 
         * @param transaction
         * @return balance
         */
        public bool HasBalance(Transaction transaction)
        {
            var transactions = TransactionByAddress(transaction.Sender);
            decimal balance = 0;
            foreach (var item in transactions)
            {
                if (item.Recipient == transaction.Sender)
                {
                    balance = balance + item.Amount;
                }
                else
                {
                    balance = balance - item.Amount;
                }
            }

            return balance >= (transaction.Amount + transaction.Fees);
        }

        /*
         * AddTransaction() Method to add transaction 
         * 
         * @param transaction
         */
        private void AddTransaction(Transaction transaction)
         {
            _currentTransactions.Add(transaction);

            if (transaction.Sender != NodeId)
            {
                _currentTransactions.Add(new Transaction
                {
                    Sender = transaction.Sender,
                    Recipient = NodeId,
                    Amount = transaction.Fees,
                    Signature = "",
                    Fees = 0
                });
            }
         }

        /*
         * ResolveConflicts() Method for consensus to solve conflicts 
         * maybe if two different miners solve the Proof-of-Work at the same time and thus add their blocks to the last known block in the chain. 
         * 
         */
        private bool ResolveConflicts()
        {
            List<Block> newChain = null;
            int maxLength = _chain.Count;

            foreach (Node node in _nodes)
            {
                var url = new Uri(node.Address, "/chain");
                var request = (HttpWebRequest)WebRequest.Create(url);
                var response = (HttpWebResponse)request.GetResponse();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var model = new
                    {
                        chain = new List<Block>(),
                        length = 0
                    };
                    string json = new StreamReader(response.GetResponseStream()).ReadToEnd();
                    var data = JsonConvert.DeserializeAnonymousType(json, model);

                    if (data.chain.Count > _chain.Count && IsValidChain(data.chain))
                    {
                        maxLength = data.chain.Count;
                        newChain = data.chain;
                    }
                }
            }

            if (newChain != null)
            {
                _chain = newChain;
                return true;
            }

            return false;
        }

        /*
         * IsValidChain() Method to check if chain is valid
         */ 
        private bool IsValidChain(List<Block> chain)
        {
            Block block = null;
            Block lastBlock = chain.First();
            int currentIndex = 1;
            while (currentIndex < chain.Count)
            {
                block = chain.ElementAt(currentIndex);

                //Check that the hash of the block is correct
                if (block.PreviousHash != GetHash(lastBlock))
                    return false;

                //Check that the Proof-of-Work is correct
                if (!IsValidProof(block.Transactions, block.Proof, lastBlock.PreviousHash))
                    return false;

                lastBlock = block;
                currentIndex++;
            }

            return true;
        }

        /*
         * Mine() Method for mining
         * 
         * @return block
         */
        internal Block Mine()
         {
            int proof = CreateProofOfWork(_lastBlock.PreviousHash);

            Block block = CreateNewBlock(proof);

            return block;
         }

        /*
         * GetFullChain() Method to get full chain length 
         * 
         * @return response 
         */
         internal string GetFullChain()
         {
            var response = new
            {
                chain = _chain.ToArray(),
                length = _chain.Count
            };

            return JsonConvert.SerializeObject(response);
         }

        /*
         * RegisterNode() Method to add new address for node registration 
         * 
         * @param address
         */
         private void RegisterNode(string address)
         {
            _nodes.Add(new Node { Address = new Uri(address) });
         }

        /*
         * RegisterNodes() Method to register new nodes
         * 
         * @param nodes
         * @return result.Substring()
         */
         internal string RegisterNodes(string[] nodes)
         {
            var builder = new StringBuilder();
            foreach (string node in nodes)
            {
                string url = node;
                RegisterNode(url);
                builder.Append($"{url}, ");
            }

            builder.Insert(0, $"{nodes.Count()} new nodes have been added:");
            string result = builder.ToString();

            return result.Substring(0, result.Length - 2);
         }

        /*
         * Consensus() Object
         * 
         * 
         * @return response
         */
         internal object Consensus()
         {
            bool replaced = ResolveConflicts();
            string message = replaced ? "was replaced" : "is authoritive";

            var response = new
            {
                Message = $"Our chain {message}",
                Chain = _chain
            };

            return response;
         }

        /*
         * CreateTransaction() Object
         * 
         * @param transaction
         * @return response
         */
        internal object CreateTransaction(Transaction transaction)
        {
            var response = new object();
            //verify
            var verified = VerifyTransactionSignature(transaction, transaction.Signature, transaction.Sender);
            if (verified == false || transaction.Sender == transaction.Recipient)
            {
                response = new { message = $"Invalid Transaction!" };
                return response;
            }
            if (HasBalance(transaction) == false)
            {
                response = new { message = $"InSufficient Balance" };
                return response;
            }

            AddTransaction(transaction);

            var blockIndex = _lastBlock != null ? _lastBlock.Index + 1 : 0;

            response = new { message = $"Transaction will be added to Block {blockIndex}" };
            return response;
        }

       /*
        * GetTransactions() Function to get list of current transactions
        * 
        * @return _currentTransactions
        */ 
        internal List<Transaction> GetTransactions()
        {
            return _currentTransactions;
        }

       /*
        * GetNodes() Function to get list of blockchain
        */
       internal List<Block> GetBlocks()
       {
            return _chain;
       }

       /*
        * GetNodes() Function to get list of nodes
        * 
        * @return _nodes
        */
        internal List<Node> GetNodes()
        {
            return _nodes;
        }

        /*
        * GetMinersWallet() Function to get miners wallet
        * 
        * @return _minersWallet()
        */
        internal Wallet GetMinersWallet()
        {
            return _minersWallet;
        }












    }
}
