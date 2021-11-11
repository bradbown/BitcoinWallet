using BitcoinWallet.ViewModels;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Essentials;
using System;
using System.Linq;
using NBitcoin;

namespace BitcoinWallet.Pages
{
    public partial class MnemonicPage : ContentPage
    {
        public MnemonicPage(Mnemonic mnemonic)
        {
            InitializeComponent();
            ((MnemonicViewModel)BindingContext).SetMnemonicDisplay(mnemonic);
        }

        private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
        {

        }
    }
}