using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BitcoinWallet.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WalletSelectorView : ContentView
    {
        public WalletSelectorView()
        {
            InitializeComponent();
        }
    }
}