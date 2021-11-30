using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security;
using Newtonsoft.Json;
using NBitcoin;
using BitcoinWallet.JsonConverters;

namespace BitcoinWallet.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    internal class KeyManager
    {
        [JsonProperty(Order = 1)]
        public string walletName { get; set; }

        public Mnemonic mnemonic;

        public ExtKey extKey;

        [JsonProperty(Order = 2)]
        [JsonConverter(typeof(HDFingerprintJsonConverter))]
        public HDFingerprint masterKeyFingerprint { get; set; }

        [JsonProperty(Order = 3)]
        [JsonConverter(typeof(ExtPubKeyJsonConverter))]
        public ExtPubKey extPubKey { get; set; }

        [JsonProperty(Order = 4)]
        public string networkType { get; set; }

        public NBitcoin.Network network;
        public string networkTypeImage { get; set; }


        [JsonConstructor]
        public KeyManager(string walletName, HDFingerprint masterKeyFingerprint, ExtPubKey extPubKey, string networkType)
        {
            this.walletName = walletName;
            this.masterKeyFingerprint = masterKeyFingerprint;
            this.extPubKey = extPubKey;
            this.networkType = networkType;

            switch (networkType)
            {
                case "MainNet":
                    network = NBitcoin.Network.Main;
                    networkTypeImage = "btclogo.png";
                    break;

                case "TestNet":
                    network = NBitcoin.Network.TestNet;
                    networkTypeImage = "btclogogrey.png";
                    break;
            }
        }

        public KeyManager(string walletName, Mnemonic mnemonic, ExtKey extKey, HDFingerprint masterKeyFingerprint, ExtPubKey extPubKey, string networkType)
        {
            this.walletName = walletName;
            this.mnemonic = mnemonic;
            this.extKey = extKey;
            this.masterKeyFingerprint = masterKeyFingerprint;
            this.extPubKey = extPubKey;
            this.networkType = networkType;

            switch(networkType)
            {
                case "MainNet":
                    network = NBitcoin.Network.Main;
                    networkTypeImage = "btclogo.png";
                    break;

                case "TestNet":
                    network = NBitcoin.Network.TestNet;
                    networkTypeImage = "btclogogrey.png";
                    break;
            }                
        }
    }
}