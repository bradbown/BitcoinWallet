using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using NBitcoin;

namespace BitcoinWallet.ViewModels
{
    internal class MainViewModel : BindableObject
    {
        public NBitcoin.Network network = NBitcoin.Network.Main;
        public Wallet wallet;
        public KeyManager keys;
        public string walletDirectory;

        public string mnemonicDisplay;

        //D:\Projects\Bitcoin\BitcoinWallet\BitcoinWallet\bin\Debug\net6.0-windows10.0.19041\win-x64\.exe

        public MainViewModel()
        {
            GenerateWallet = new Command(OnGenerateWallet);
            walletDirectory = "D:\\Projects\\Bitcoin\\BitcoinWallet\\";
            wallet = new Wallet(NBitcoin.Network.Main, walletDirectory);
            BindingContext = this;
        }

        public ICommand GenerateWallet { get; }

        public string MnemonicDisplay
        {
            get => keys.mnemonic.ToString();
            set
            {
                if (value == mnemonicDisplay)
                    return;

                mnemonicDisplay = value.ToString();
                OnPropertyChanged(nameof(MnemonicDisplay));
            }
        }

        public void OnGenerateWallet()
        {
            wallet = new Wallet(NBitcoin.Network.Main, walletDirectory);
            keys = wallet.GenerateWallet("wallet", "password");
            MnemonicDisplay = $"Mnemonic: {keys.mnemonic.ToString()}";
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
