using BitcoinWallet.Models;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using System;
using System.Windows.Input;

namespace BitcoinWallet.ViewModels
{
    internal class CreateWalletViewModel : ViewModelBase
    {
        NBitcoin.Network network = NBitcoin.Network.Main;
        Wallet wallet;
        KeyManager keys;

        string walletName;

        public CreateWalletViewModel()
        {
            CreateWallet = new Command(OnCreateWallet);
        }

        public string WalletName 
        {
            get => walletName ?? null;
            set => SetProperty(ref walletName, value);
        }

        public ICommand CreateWallet { get; }
        public void OnCreateWallet()
        {
            wallet = new Wallet(NBitcoin.Network.Main);
            
            //To do
            //open entry modal on new wallet to importname
            keys = wallet.GenerateWallet(walletName, "password");
            
            //(App.Current.MainPage as NavigationPage).PushAsync(new Pages.MnemonicPage(keys.mnemonic));
            App.Current.MainPage = new Pages.MnemonicPage(keys.mnemonic);
        }
    }
}
