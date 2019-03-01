using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BlockChain.Models;
using BlockChain.Api;

namespace BlockChain.Controllers
{

   /**
    * Used to define main interactions with MVC application 
    * 
    * @author Davain Pablo Edwards
    * @license MIT 
    * @version 1.0
    */
    public class HomeController : Controller
    {

        // Instantiating CryptoCurrency and BlockChainController class for model and method access
        private static CryptoCurrency blockchain = BlockChainController.blockchain; // new CryptoCurrency();

        
        public IActionResult Index()
        {

            // Initial list of transactions for data view  
            List<Transaction> transactions = blockchain.GetTransactions();
            ViewBag.Transactions = transactions;

            // Initial list of blocks for data view
            List<Block> blocks = blockchain.GetBlocks();
            ViewBag.Blocks = blocks;

            return View();
        }

       /*
        * Mine() action Method for redirection to index view 
        *
        *@return RedirectToAction("Index")
        */ 
        public IActionResult Mine()
        {
           blockchain.Mine();
           return RedirectToAction("Index");
        }

       /*
        * Configure() action Method to show node(s) information to configure view 
        * 
        *@return View()
        */ 
        public IActionResult Configure()
        {
            return View(blockchain.GetNodes());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
