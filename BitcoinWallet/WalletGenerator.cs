using NBitcoin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitcoinWallet.Wallets
{
    internal class WalletGenerator
    {
        public NBitcoin.Network network;
        public string walletDirectory;

        public WalletGenerator(NBitcoin.Network network, string walletDirectory)
        {
            this.network = network;
            this.walletDirectory = walletDirectory;
        }

        public void GenerateWallet(string walletName, string password)
        {

        }
    }
}
