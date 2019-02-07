using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockChain.Models
{

    /**
    * Used to define block
    * 
    * @author Davain Pablo Edwards
    * @license MIT 
    * @version 1.0
    */
    public class Block
    {

        public int Index { get; set; }
        public DateTime TimeStamp { get; set; }
        public List<Transaction> Transactions { get; set; }
        public int Proof { get; set; }
        public string PreviousHash { get; set; }

        /**
         * Overrides and returns the block string
         * 
         * @return block
         */ 
        public override string ToString()
        {
            return $"{Index} [{TimeStamp.ToString("yyyy-MM-dd HH:mm:ss")}] Proof: {Proof} | PrevHash: {PreviousHash} | Trx: {Transactions.Count}";
        }

    }
}
