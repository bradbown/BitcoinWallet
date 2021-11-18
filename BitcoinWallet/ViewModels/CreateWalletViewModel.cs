using Microsoft.Maui;
using Microsoft.Maui.Controls;
using System;
using System.Windows.Input;

namespace BitcoinWallet.ViewModels
{
    internal class CreateWalletViewModel : ViewModelBase
    {
        public string walletName;

        private NBitcoin.Network network = NBitcoin.Network.Main;
        private Wallet wallet;
        private KeyManager keys;
        private string walletDirectory;

        public CreateWalletViewModel()
        {
            CreateWallet = new Command(OnCreateWallet);
            walletDirectory = "D:\\Projects\\Bitcoin\\BitcoinWallet\\";
        }

        public string WalletName 
        {
            get => walletName ?? null;
            set => SetProperty(ref walletName, value);
        }

        public ICommand CreateWallet { get; }
        public void OnCreateWallet()
        {
            wallet = new Wallet(NBitcoin.Network.Main, walletDirectory);
            
            //To do
            //open entry modal on new wallet to importname
            keys = wallet.GenerateWallet(walletName, "password");
            
            //(App.Current.MainPage as NavigationPage).PushAsync(new Pages.MnemonicPage(keys.mnemonic));
            App.Current.MainPage = new Pages.MnemonicPage(keys.mnemonic);
        }
    }
}
