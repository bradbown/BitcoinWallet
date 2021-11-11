using Microsoft.Maui.Controls;
using System.Windows.Input;
using NBitcoin;

namespace BitcoinWallet.ViewModels
{
    internal class MnemonicViewModel : ViewModelBase
    {
        Mnemonic mnemonicDisplay;

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

        public void SetMnemonicDisplay(Mnemonic mnemonic)
        {
            this.MnemonicDisplay = mnemonic;
        }

        public ICommand OnBack { get; }
        public void Back()
        {

        }

        public ICommand OnNext { get; }
        public void Next()
        {

        }
    }
}
