using Microsoft.Maui;
using Microsoft.Maui.Controls;
using System;
using System.Windows.Input;
using NBitcoin;
using System.Collections.Generic;
using MvvmHelpers;
using BitcoinWallet.Models;

namespace BitcoinWallet.ViewModels
{
    internal class MainViewModel : ViewModelBase
    {
        public ObservableRangeCollection<KeyManager> Wallets { get; set; }

        public MainViewModel()
        {
            GenerateWallet = new Command(OnGenerateWallet);
            //Wallets = Wallet.LoadWalletsObservable();
        }

        public ICommand GenerateWallet { get; }

        public void OnGenerateWallet()
        {
            App.Current.MainPage = new Pages.CreateWalletPage();


            //MnemonicLabel.Text = $"Mnemonic: {keys.mnemonic}";
            //ExtKeyLabel.Text = $"ExtKey: {keys.extKey}";
            //HDFingerprintLabel.Text = $"HDFingerprint: {keys.masterKeyFingerprint}";
            //ExtPubKeyLabel.Text = $"ExtPubKey: {keys.extPubKey}";
            //AddressP2PKHLabel.Text = $"Address P2PKH: {keys.extKey.GetWif(network).GetPublicKey().Hash.GetAddress(NBitcoin.Network.Main)}"; //BASE58 (P2PKH)
            //AddressSegwitLabel.Text = $"Address Segwit: {keys.extKey.GetWif(network).GetPublicKey().WitHash.ScriptPubKey.GetDestinationAddress(NBitcoin.Network.Main)}"; //BECH32 (P2WPKH)
            //Console.WriteLine("Address P2PKH: " + AddressP2PKHLabel.Text);
            //Console.WriteLine("Address Segwit: " + AddressSegwitLabel.Text);
        }
    }
}
