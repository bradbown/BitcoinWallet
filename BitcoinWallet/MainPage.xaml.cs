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

        Keys keys = new Keys();

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;
        }

        private void OnGenerateWalletClicked(object sender, EventArgs e)
        {
            GenerateWallet();
        }

        private void GenerateWallet()
        {
            wallet = new Wallet(NBitcoin.Network.Main, "walletDirectory");
            keys = wallet.GenerateWallet("walletName", "password");
            MnemonicLabel.Text = $"MnemonicLabel: {keys.mnemonic}";
            ExtKeyLabel.Text = $"ExtKeyLabel: {keys.extKey}";
            HDFingerprintLabel.Text = $"HDFingerprintLabel: {keys.masterKeyFingerprint}";
            ExtPubKeyLabel.Text = $"ExtPubKeyLabel: {keys.extPubKey}";

            //CounterLabel.Text = $"Current count: {count}";
        }
    }
}
