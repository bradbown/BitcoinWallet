using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace DraculaWallet.Views
{
    public partial class CreateWalletWindow : Window
    {
        public CreateWalletWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
