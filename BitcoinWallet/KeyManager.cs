using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security;
using Newtonsoft.Json;
using NBitcoin;

namespace BitcoinWallet
{
    [JsonObject(MemberSerialization.OptIn)]
    public class KeyManager
    {
        [JsonProperty]
        public Mnemonic mnemonic = null;
        [JsonProperty]
        public ExtKey extKey = null;
        [JsonProperty]
        public HDFingerprint masterKeyFingerprint;
        [JsonProperty]
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
