using NBitcoin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitcoinWallet
{
    public class Wallet
    {
        public NBitcoin.Network network;
        public string walletDirectory;

        public Wallet(NBitcoin.Network network, string walletDirectory)
        {
            this.network = network;
            this.walletDirectory = walletDirectory;
        }

        public KeyManager GenerateWallet(string walletName, string password)
        {
            Mnemonic mnemonic = new Mnemonic(Wordlist.English, WordCount.Twelve);
            ExtKey extKey = mnemonic.DeriveExtKey(password);

            HDFingerprint masterKeyFingerprint = extKey.Neuter().PubKey.GetHDFingerPrint();
            ExtPubKey extPubKey = extKey.Neuter();  

            return new KeyManager(mnemonic, extKey, masterKeyFingerprint, extPubKey);
        }
    }
}
