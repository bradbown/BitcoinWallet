using System;
using System.Collections.Generic;
using System.Text;
using NBitcoin;

namespace BitcoinWallet.ViewModels
{
    internal class MnemonicViewModel : ViewModelBase
    {
        public Mnemonic mnemonicDisplay;

        public MnemonicViewModel()
        {

        }

        public Mnemonic MnemonicDisplay
        {
            get => mnemonicDisplay != null ? mnemonicDisplay : null;
            set => SetProperty(ref mnemonicDisplay, value); 
        }
    }
}
