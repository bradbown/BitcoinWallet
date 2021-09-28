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
            public Mnemonic mnemonic;
            public ExtKey extKey;
            public HDFingerprint masterKeyFingerprint;
            public ExtPubKey extPubKey;

            public WalletData(Keys keys)
            {
                mnemonic = keys.mnemonic;
                extKey = keys.extKey;
                masterKeyFingerprint = keys.masterKeyFingerprint;
                extPubKey = keys.extPubKey;
            }
        }

        Keys keys;


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

            keys = new Keys(walletData.mnemonic, walletData.extKey, walletData.masterKeyFingerprint, walletData.extPubKey);
        }
    }
}
