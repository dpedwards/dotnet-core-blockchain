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

       

       

    }
}
