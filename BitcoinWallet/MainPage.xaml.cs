using Microsoft.Maui.Controls;
using Microsoft.Maui.Essentials;
using System;
using NBitcoin;

namespace BitcoinWallet
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        Wallet wallet;

        struct WalletData
        {
            public Mnemonic mnemonic = null;
            public ExtKey extKey = null;
            public HDFingerprint masterKeyFingerprint;
            public ExtPubKey extPubKey = null;

            public WalletData()
            {

            }

            public WalletData(Mnemonic mnemonic, ExtKey extKey, HDFingerprint masterKeyFingerprint, ExtPubKey extPubKey)
            {
                this.mnemonic = mnemonic;
                this.extKey = extKey;
                this.masterKeyFingerprint = masterKeyFingerprint;
                this.extPubKey = extPubKey;
            }

        }


        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;
        }

        private void GenerateWallet()
        {
            wallet = new Wallet(NBitcoin.Network.Main, "walletDirectory");
            WalletData walletData = new WalletData(wallet.GenerateWallet("walletName", "password"));
        }
    }
}
