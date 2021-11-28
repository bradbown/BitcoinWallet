using BitcoinWallet.Models;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using MvvmHelpers;
using NBitcoin;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitcoinWallet
{
    internal class Wallet
    {
        public NBitcoin.Network network;
        public string walletDirectory;
        static string filePath = "D:\\Projects\\Bitcoin\\BitcoinWallet\\walletNet.json";

        public Wallet(NBitcoin.Network network)
        {
            this.network = network;
            //filePath = walletDirectory + "wallet" + ".json";

#if __ANDROID__
            walletDirectory = "Microsoft.Maui.Essentials.FileSystem.AppDataDirectory";
#else
            walletDirectory = "D:\\Projects\\Bitcoin\\BitcoinWallet\\";
#endif
        }
        public Wallet(NBitcoin.Network network, string walletDirectory)
        {
            this.network = network;
            this.walletDirectory = walletDirectory;
        }

        public KeyManager GenerateWallet(string walletName, string password, string network)
        {
            
            //if (IO.DoesDirectoryExist(walletDirectory))
            //{
            //    //Directory doesn't exist
            //    Console.WriteLine("directory exists");
            //}
            if (IO.DoesFileExist(filePath))
            {
                //Todo append to json
                List<KeyManager> walletList = LoadWallets();

                Mnemonic mnemonic = new Mnemonic(Wordlist.English, WordCount.Twelve);
                ExtKey extKey = mnemonic.DeriveExtKey(password);

                HDFingerprint masterKeyFingerprint = extKey.Neuter().PubKey.GetHDFingerPrint();
                ExtPubKey extPubKey = extKey.Neuter();

                KeyManager keyManager = new KeyManager(walletName, mnemonic, extKey, masterKeyFingerprint, extPubKey, network);

                walletList.Add(keyManager);
                IO.WriteToFile(filePath, ref walletList);

                return keyManager;
            }
            else
            {
                Mnemonic mnemonic = new Mnemonic(Wordlist.English, WordCount.Twelve);
                ExtKey extKey = mnemonic.DeriveExtKey(password);

                HDFingerprint masterKeyFingerprint = extKey.Neuter().PubKey.GetHDFingerPrint();
                ExtPubKey extPubKey = extKey.Neuter();

                KeyManager keyManager = new KeyManager(walletName, mnemonic, extKey, masterKeyFingerprint, extPubKey, network);

                IO.WriteToFile(filePath, ref keyManager);

                return keyManager;
            }
        }

        public static List<KeyManager> LoadWallets()
        {
            List<KeyManager> walletList = new List<KeyManager>();
            var jsonData = IO.ReadListFromFile(filePath);

            foreach (var key in jsonData)
                walletList.Add(key);

            return walletList;
        }

        public static ObservableRangeCollection<KeyManager> LoadWalletsObservable()
        {
            ObservableRangeCollection<KeyManager> walletList = new ObservableRangeCollection<KeyManager>();
            var jsonData = IO.ReadListFromFile(filePath);

            foreach (var key in jsonData)
                walletList.Add(key);

            return walletList;
        }
    }
}
