using BlockChain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BlockChain.Api
{

   /**
    * Used to define blockchain interactions
    * 
    * @author Davain Pablo Edwards
    * @license MIT 
    * @version 1.0
    */
    [Produces("application/json")]
    [Route("")]
    public class BlockChainController : Controller
    {

        // Initial cryptocurrency mechanisms
        public static CryptoCurrency blockchain = new CryptoCurrency();

       /*
        * NewTransaction() http web method to post new transactions
        * 
        * @param transaction 
        * @return response
        */
        [HttpPost("transactions/new")]
        public IActionResult NewTransaction([FromBody]Transaction transaction)
        {
            var response = blockchain.CreateTransaction(transaction);

            return Ok(response);
        }

       /*
        * GetTransactions() http web method to get transactions
        * 
        * @return response
        */ 
        [HttpGet("transaction")]
        public IActionResult GetTransactions()
        {
            var response = new { transactions = blockchain.GetTransactions() };

            return Ok(response);
        }

       /*
        * GetFullChain() http web method to get full chain
        * 
        * @return response
        */ 
        [HttpGet("chain")]
        public IActionResult FullChain()
        {
            var blocks = blockchain.GetBlocks();
            var response = new { chain = blocks, length = blocks.Count };

            return Ok(response);
        }

       /*
        * Mine() http web method to get new forged block 
        * 
        * @return response
        */ 
        [HttpGet("mine")]
        public IActionResult Mine()
        {
            var block = blockchain.Mine();
            var response = new
            {
                message = "New Block Forged",
                blockNumber = block.Index,
                transactions = block.Transactions.ToArray(),
                nonce = block.Proof,
                previousHash = block.PreviousHash
            };

            return Ok(response);
        }

       /*
        * RegisterNodes() http web method to post new nodes to register 
        * 
        * @return response
        */ 
        [HttpPost("nodes/register")]
        public IActionResult RegisterNodes(string[] nodes)
        {
            blockchain.RegisterNodes(nodes);
            var response = new
            {
                message = "New nodes have been added",
                totalNodes = nodes.Count()
            };

            return Created("", response);
        }

        /*
         * Consensus() http web method to get blockchain consensus 
         * 
         * @return blockchain.Consensus()
         */ 
         [HttpGet("nodes/resolve")]
         public IActionResult Consensus()
         {
            return Ok(blockchain.Consensus());
         }

        /*
         * GetNodes() http web method to get blockchain nodes 
         * 
         * @return nodes = blockchain.GetNodes() 
         */ 
         [HttpGet("nodes")]
         public IActionResult GetNodes()
         {
            return Ok(new { nodes = blockchain.GetNodes() });
         }

        /*
         * GetMinersWallet() http web method to get miners wallet 
         * 
         * @return blockchain.GetMinersWallet()
         */ 
         [HttpGet("wallet/miner")]
         public IActionResult GetMinersWallet()
         {
            return Ok(blockchain.GetMinersWallet());
         }


    






      



    }
}
