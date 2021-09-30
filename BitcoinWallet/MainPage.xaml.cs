using Microsoft.Maui.Controls;
using Microsoft.Maui.Essentials;
using System;
using NBitcoin;

namespace BitcoinWallet
{
    public partial class MainPage : ContentPage
    {
        NBitcoin.Network network = NBitcoin.Network.Main;
        Wallet wallet;
        KeyManager keys;
        string walletDirectory;

        //D:\Projects\Bitcoin\BitcoinWallet\BitcoinWallet\bin\Debug\net6.0-windows10.0.19041\win-x64\.exe

        public MainPage()
        {
            walletDirectory = "D:\\Projects\\Bitcoin\\BitcoinWallet\\";
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            
        }

        private void OnGenerateWalletClicked(object sender, EventArgs e)
        {
            GenerateWallet();
        }

        private void GenerateWallet()
        {
            wallet = new Wallet(NBitcoin.Network.Main, walletDirectory);
            keys = wallet.GenerateWallet("wallet", "password");
            MnemonicLabel.Text = $"Mnemonic: {keys.mnemonic}";
            ExtKeyLabel.Text = $"ExtKey: {keys.extKey}";
            HDFingerprintLabel.Text = $"HDFingerprint: {keys.masterKeyFingerprint}";
            ExtPubKeyLabel.Text = $"ExtPubKey: {keys.extPubKey}";
            AddressP2PKHLabel.Text = $"Address P2PKH: {keys.extKey.GetWif(network).GetPublicKey().Hash.GetAddress(NBitcoin.Network.Main)}"; //BASE58 (P2PKH)
            AddressSegwitLabel.Text = $"Address Segwit: {keys.extKey.GetWif(network).GetPublicKey().WitHash.ScriptPubKey.GetDestinationAddress(NBitcoin.Network.Main)}"; //BECH32 (P2WPKH)
            Console.WriteLine("Address P2PKH: " + AddressP2PKHLabel.Text);
            Console.WriteLine("Address Segwit: " +AddressSegwitLabel.Text);
        }
    }
}
