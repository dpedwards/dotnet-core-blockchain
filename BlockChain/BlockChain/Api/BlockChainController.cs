using BlockChain.Models;
using Microsoft.AspNetCore.Mvc;

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

      



    }
}
