using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security;
using Newtonsoft.Json;
using NBitcoin;
using BitcoinWallet.JsonConverters;

namespace BitcoinWallet
{
    [JsonObject(MemberSerialization.OptIn)]
    public class KeyManager
    {
        public Mnemonic mnemonic = null;

        public ExtKey extKey = null;

        [JsonProperty(Order = 1)]
        [JsonConverter(typeof(HDFingerprintJsonConverter))]
        public HDFingerprint masterKeyFingerprint;

        [JsonProperty(Order = 2)]
        [JsonConverter(typeof(ExtPubKeyJsonConverter))]
        public ExtPubKey extPubKey = null;

        [JsonConstructor]
        public KeyManager(Mnemonic mnemonic, ExtKey extKey, HDFingerprint masterKeyFingerprint, ExtPubKey extPubKey)
        {
            this.mnemonic = mnemonic;
            this.extKey = extKey; 
            this.masterKeyFingerprint = masterKeyFingerprint;
            this.extPubKey = extPubKey;

        }
    }
}
