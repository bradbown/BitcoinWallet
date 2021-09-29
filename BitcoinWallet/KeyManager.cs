using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security;
using Newtonsoft.Json;
using NBitcoin;

namespace BitcoinWallet
{
    [JsonObject(MemberSerialization.OptIn)]
    public class KeyManager
    {
        public Mnemonic mnemonic = null;
        public ExtKey extKey = null;
        public HDFingerprint masterKeyFingerprint;
        public ExtPubKey extPubKey = null;

        [JsonConstructor]
        public KeyManager(Mnemonic mnemonic, ExtKey extKey, HDFingerprint masterKeyFingerprint, ExtPubKey extPubKey)
        {
            this.mnemonic = mnemonic;
            this.extKey = extKey; 
            this.masterKeyFingerprint = masterKeyFingerprint;
            this.extPubKey = extPubKey;
        }

        public void WriteToFile(string filePath)
        {
            string jsonString = JsonConvert.SerializeObject(this, Formatting.Indented);
            File.WriteAllText(filePath, jsonString, Encoding.UTF8);
        }

        public bool DoesFileExist(string filePath)
        {
            return File.Exists(filePath);
        }
    }
}
