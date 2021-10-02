using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using NBitcoin;

namespace BitcoinWallet.ViewModel
{
    public class MainViewModel : BindableObject
    {
        NBitcoin.Network network = NBitcoin.Network.Main;
        Wallet wallet;
        KeyManager keys;
        string walletDirectory;

        //D:\Projects\Bitcoin\BitcoinWallet\BitcoinWallet\bin\Debug\net6.0-windows10.0.19041\win-x64\.exe

        public MainViewModel()
        {
            GenerateWallet = new Command(OnGenerateWallet);
            walletDirectory = "D:\\Projects\\Bitcoin\\BitcoinWallet\\";
        }        

        public ICommand GenerateWallet { get; }

        public KeyManager WalletDisplay
        {
            get => keys;
            set
            {

            }
        }


        public void OnGenerateWallet()
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
            Console.WriteLine("Address Segwit: " + AddressSegwitLabel.Text);
        }
    }
}
