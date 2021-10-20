using BitcoinWallet.ViewModels;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Essentials;
using System;
using NBitcoin;

namespace BitcoinWallet.Pages
{
    public partial class MnemonicPage : ContentPage
    {
        private Mnemonic mnemonic;
        public MnemonicPage(Mnemonic mnemonic)
        {
            InitializeComponent();
            this.mnemonic = mnemonic;
            TestMnemonic.Text = mnemonic.ToString();
        }
    }
}