using Microsoft.Maui.Controls;
using System.Windows.Input;
using NBitcoin;
using Microsoft.Maui.Graphics;

namespace BitcoinWallet.ViewModels
{
    internal class MnemonicViewModel : ViewModelBase
    {
        int mnemonicPage = 0;

        Mnemonic mnemonicDisplay;
        bool backEnabled = false;

        bool pageOne = true;
        bool pageTwo = false;
        bool mnemonicTestPage = false;

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

        public bool PageOne
        {
            get => pageOne;
            set => SetProperty(ref pageOne, value);
        }

        public bool PageTwo
        {
            get => pageTwo;
            set => SetProperty(ref pageTwo, value);
        }

        public bool MnemonicTestPage
        {
            get => mnemonicTestPage;
            set => SetProperty(ref mnemonicTestPage, value);
        }

        public void SetMnemonicDisplay(Mnemonic mnemonic)
        {
            MnemonicDisplay = mnemonic;
        }

        public ICommand OnBack { get; }
        public void Back()
        {
            if(mnemonicPage > 0)
            {
                mnemonicPage--;
                PageOne = (mnemonicPage == 0);
                PageTwo = (mnemonicPage == 1);
                if (mnemonicPage == 0)
                {
                    PageOne = (mnemonicPage == 0);
                    PageTwo = (mnemonicPage == 1);
                    BackEnabled = false;                    
                }
            }
        }

        public ICommand OnNext { get; }
        public void Next()
        {
            mnemonicPage++;
            PageOne = (mnemonicPage == 0);
            PageTwo = (mnemonicPage == 1);
            MnemonicTestPage = (mnemonicPage == 2);
            BackEnabled = true;
        }
    }
}