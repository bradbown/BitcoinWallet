﻿using System;
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
        public HDFingerprint masterKeyFingerprint;

        [JsonProperty(Order = 3)]
        [JsonConverter(typeof(ExtPubKeyJsonConverter))]
        public ExtPubKey extPubKey;


        [JsonConstructor]
        public KeyManager(string walletName, Mnemonic mnemonic, ExtKey extKey, HDFingerprint masterKeyFingerprint, ExtPubKey extPubKey)
        {
            this.walletName = walletName;
            this.mnemonic = mnemonic;
            this.extKey = extKey;
            this.masterKeyFingerprint = masterKeyFingerprint;
            this.extPubKey = extPubKey;
        }
    }
}