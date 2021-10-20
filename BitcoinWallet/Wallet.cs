using Microsoft.Maui.Controls;
using NBitcoin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitcoinWallet
{
    internal class Wallet
    {
        public NBitcoin.Network network;
        public string walletDirectory;

        public Wallet(NBitcoin.Network network, string walletDirectory)
        {
            this.network = network;
            this.walletDirectory = walletDirectory;
        }

        public KeyManager GenerateWallet(string walletName, string password)
        {
            string filePath = walletDirectory + walletName + ".json";
            if (IO.DoesDirectoryExist(walletDirectory))
            {
                //Directory doesn't exist
                Console.WriteLine("directory exists");
            }
            //if (IO.DoesFileExist(filePath))
            //{
            //    return IO.ReadFromFile(filePath);
            //}
            //else
            //{
                Mnemonic mnemonic = new Mnemonic(Wordlist.English, WordCount.Twelve);
                ExtKey extKey = mnemonic.DeriveExtKey(password);

                HDFingerprint masterKeyFingerprint = extKey.Neuter().PubKey.GetHDFingerPrint();
                ExtPubKey extPubKey = extKey.Neuter();

                KeyManager keyManager = new KeyManager(mnemonic, extKey, masterKeyFingerprint, extPubKey);

                IO.WriteToFile(filePath, ref keyManager);

            (App.Current.MainPage as NavigationPage).PushAsync(new Pages.MnemonicPage(mnemonic));

            return keyManager;
            //}
        }
    }
}
