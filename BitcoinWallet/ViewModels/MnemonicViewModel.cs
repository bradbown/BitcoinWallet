using Microsoft.Maui.Controls;
using System.Windows.Input;
using NBitcoin;

namespace BitcoinWallet.ViewModels
{
    internal class MnemonicViewModel : ViewModelBase
    {
        int mnemonicPageCount = 0;

        Mnemonic mnemonicDisplay;
        bool backEnabled = false;

        public MnemonicViewModel()
        {
            OnBack = new Command(Back);
            OnNext = new Command(Next);
        }

        public Mnemonic MnemonicDisplay
        {
            get => mnemonicDisplay ?? null;
            set => SetProperty(ref mnemonicDisplay, value); 
        }

        public bool BackEnabled
        {
            get => backEnabled;
            set => SetProperty(ref backEnabled, value);
        }
        public void SetMnemonicDisplay(Mnemonic mnemonic)
        {
            MnemonicDisplay = mnemonic;
        }

        public ICommand OnBack { get; }
        public void Back()
        {
            if(mnemonicPageCount > 0)
            {
                mnemonicPageCount--;
                if (mnemonicPageCount == 0)
                    BackEnabled = false;                
            }
        }

        public ICommand OnNext { get; }
        public void Next()
        {
            mnemonicPageCount++;
            BackEnabled = true;
        }
    }
}