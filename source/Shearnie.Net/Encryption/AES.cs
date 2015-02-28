using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Paddings;
using Org.BouncyCastle.Crypto.Parameters;

namespace Shearnie.Net.Encryption
{
    public class AES
    {
        private static readonly byte[] salt = new byte[] { 44, 12, 67, 164, 153, 47, 211, 98, 32, 87, 59, 218, 114, 171, 210, 205 };
        private static readonly string saltPassword = "Bl)<7*]j13{;4F4$6}*+]&@6{W%0|@46%>hu{;5=6|<5 >f9(1H8'^;]2</Pn6,0(8)=_$j/'2+/{e.dTc6!}1#:#36)]65t~697";

        // from: http://elian.co.uk/post/2009/07/29/Bouncy-Castle-CSharp.aspx
        private class BCEngine
        {
            private readonly Encoding _encoding;
            private readonly IBlockCipher _blockCipher;
            private PaddedBufferedBlockCipher _cipher;
            private IBlockCipherPadding _padding;

            public BCEngine(IBlockCipher blockCipher, Encoding encoding)
            {
                _blockCipher = blockCipher;
                _encoding = encoding;
            }

            public void SetPadding(IBlockCipherPadding padding)
            {
                if (padding != null)
                    _padding = padding;
            }

            public string Encrypt(string plain, byte[] key)
            {
                byte[] result = BouncyCastleCrypto(true, _encoding.GetBytes(plain), key);
                return Convert.ToBase64String(result);
            }

            public string Decrypt(string cipher, byte[] key)
            {
                byte[] result = BouncyCastleCrypto(false, Convert.FromBase64String(cipher), key);
                return _encoding.GetString(result);
            }

            /// <summary>
            ///
            /// </summary>
            /// <param name="forEncrypt"></param>
            /// <param name="input"></param>
            /// <param name="key"></param>
            /// <returns></returns>
            /// <exception cref="CryptoException"></exception>
            private byte[] BouncyCastleCrypto(bool forEncrypt, byte[] input, byte[] key)
            {
                try
                {
                    _cipher = _padding == null ? new PaddedBufferedBlockCipher(_blockCipher) : new PaddedBufferedBlockCipher(_blockCipher, _padding);
                    _cipher.Init(forEncrypt, new KeyParameter(key));
                    return _cipher.DoFinal(input);
                }
                catch (CryptoException ex)
                {
                    throw new CryptoException(ex.Message);
                }
            }
        }


        private static byte[] CreateKey(string password, int keySize = 32)
        {
            const int iterations = 1000;
            var keyGenerator = new Rfc2898DeriveBytes(password, salt, iterations);
            return keyGenerator.GetBytes(keySize);
        }

        public static string Encrypt(string plain, string password)
        {
            try
            {
                var bcEngine = new BCEngine(new AesEngine(), Encoding.ASCII);
                bcEngine.SetPadding(new Pkcs7Padding());
                var key = CreateKey(saltPassword + password);
                return bcEngine.Encrypt(plain, key);
            }
            catch (Exception ex)
            {
                // TODO dodgy pokemon catch, we will worry later
                var ignore = ex;
                return plain;
            }
        }

        public static string Decrypt(string cipher, string password)
        {
            try
            {
                var bcEngine = new BCEngine(new AesEngine(), Encoding.ASCII);
                bcEngine.SetPadding(new Pkcs7Padding());
                return bcEngine.Decrypt(cipher, CreateKey(saltPassword + password));
            }
            catch (Exception ex)
            {
                // TODO dodgy pokemon catch, we will worry later
                var ignore = ex;
                return "";
            }
        }
    }
}
