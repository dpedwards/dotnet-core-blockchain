// =======================================================
// Author: Davain Pablo Edwards
// Email:  core8@gmx.net
// Web:    
// =======================================================

namespace BlockChain.Models
{

    /**
     * Used to define the blockchain transactions.
     * 
     * @author Davain Pablo Edwards
     * @license MIT 
     * @version 1.0
     */
    public class Transaction
    {
        // Amount for holding values. 
        public decimal Amount { get; set; }
        
        // Fees for transaction.
        public decimal Fees { get; set; }

        // Receives the full transaction.
        public string Recipient { get; set; }

        // Sends the full transaction. 
        public string Sender { get; set; }

        // Defines the signature for transaction.
        public string Signature { get; set; }

        /**
         * Overrides and returns the amount string with recipient and sender string.
         * 
         * @return amount + recipient + sender 
         */ 
        public override string ToString()
        {
            return Amount.ToString("0.00000000") + Recipient + Sender;
        }

    }
}
