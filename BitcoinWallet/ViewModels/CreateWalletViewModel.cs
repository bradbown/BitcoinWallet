using BitcoinWallet.Models;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using System;
using System.Windows.Input;

namespace BitcoinWallet.ViewModels
{
    internal class CreateWalletViewModel : ViewModelBase
    {
        NBitcoin.Network network;
        Wallet wallet;
        KeyManager keys;

        string walletName;

        public CreateWalletViewModel()
        {
            CreateWallet = new Command(OnCreateWallet);
            BitcoinWalletSelect = new Command(OnBitcoinWalletSelect);
        }

        public string WalletName 
        {
            get => walletName ?? null;
            set => SetProperty(ref walletName, value);
        }

        public ICommand CreateWallet { get; }
        public void OnCreateWallet()
        {
            wallet = new Wallet(network);
            
            //To do
            //open entry modal on new wallet to importname
            keys = wallet.GenerateWallet(walletName, "password");
            
            //(App.Current.MainPage as NavigationPage).PushAsync(new Pages.MnemonicPage(keys.mnemonic));
            App.Current.MainPage = new Pages.MnemonicPage(keys.mnemonic);
        }

        public ICommand BitcoinWalletSelect { get; }

        public void OnBitcoinWalletSelect()
        {
            network = NBitcoin.Network.Main;
        }
    }
}
