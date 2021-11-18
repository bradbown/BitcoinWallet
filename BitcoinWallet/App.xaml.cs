using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.PlatformConfiguration.WindowsSpecific;
using Application = Microsoft.Maui.Controls.Application;

namespace BitcoinWallet
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            //MainPage = new MainPage();
        }
        protected override Window CreateWindow(IActivationState activationState)
        {
            Window window = new Window(new NavigationPage(new MainPage()));
            window.Title = "Dracula Wallet";
            // Todo:
            // set icon
            // set toolbar background
            return window;
        }
    }
}
