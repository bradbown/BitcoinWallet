using Avalonia.Controls.ApplicationLifetimes;
using DraculaWallet.Views;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace DraculaWallet.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public ICommand CreateWalletCommand { get; }

        public MainWindowViewModel()
        {

            CreateWalletCommand = ReactiveCommand.Create(async () =>
            {
                var createWalletWindow = new CreateWalletWindow();

                if (Avalonia.Application.Current.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
                {
                    await createWalletWindow.ShowDialog(desktop.MainWindow);
                }
            });
        }
    }
}
