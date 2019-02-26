using NBitcoin;
using System;

namespace RSA
{

    /**
     * Used to define RSA (Rivest-Shamir-Adleman) cryptosystem
     * Key size 1,024 to 4,096 bit typical for secure data transmission 
     * 'NBitcoin' is a port of Bitcoin from C++ to C# 
     * GitHub Project Source: https://github.com/MetacoSA/NBitcoin
     * 
     * @author Davain Pablo Edwards
     * @license MIT 
     * @version 1.0
     */
    public static class RSA
    {

        /*
         * KeyGenerate() Method to generate keys
         * 
         * @return new Wallet private & public keys
         */ 
        public static Wallet KeyGenerate()
        {

            Key privateKey = new Key();

            var v = privateKey.GetBitcoinSecret(Network.Main).GetAddress();
            var address = BitcoinAddress.Create(v.ToString(), Network.Main);

            return new Wallet { PublicKey = v.ToString(), PrivateKey = privateKey.GetBitcoinSecret(Network.Main).ToString() };

        }

        /*
         * Sign() Method for signature to pass a transaction 
         * 
         * @param privKey
         * @param msgToSign
         * @return signature
         */ 
        public static string Sign(string privKey, string msgToSign)
        {
            //var address = BitcoinAddress.Create(pubKey, Network.Main);
            //var pkh = (address as IPubkeyHashUsable);

            var secret = Network.Main.CreateBitcoinSecret(privKey);
            var signature = secret.PrivateKey.SignMessage(msgToSign);
            //var bol = pkh.VerifyMessage(msgToSign, signature));
            var v = secret.PubKey.VerifyMessage(msgToSign, signature);
            return signature;
        }

        /*
         * Verify() Method to verify signature 
         * 
         * @param pbKey
         * @param originalMessage
         * @param signedMessage
         * @return bol
         */ 
        public static bool Verify(string pbKey, string originalMessage, string signedMessage)
        {
            var adress = BitcoinAddress.Create(pbKey, Network.Main);
            var pkh = (adress as IPubkeyHashUsable);

            var bol = pkh.VerifyMessage(originalMessage, signedMessage);

            return bol;

        }



    }
}
