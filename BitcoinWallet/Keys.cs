using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NBitcoin;

namespace BitcoinWallet
{
    public class Keys
    {
        public Mnemonic mnemonic = null;
        public ExtKey extKey = null;
        public HDFingerprint masterKeyFingerprint;
        public ExtPubKey extPubKey = null;

        public Keys()
        {

        }
        public Keys(Mnemonic mnemonic, ExtKey extKey, HDFingerprint masterKeyFingerprint, ExtPubKey extPubKey)
        {
            this.mnemonic = mnemonic;
            this.extKey = extKey; 
            this.masterKeyFingerprint = masterKeyFingerprint;
            this.extPubKey = extPubKey;
        }
    }
}
