using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Useful_Classes
{
    public class AESAlgorytm
    {
        Aes aes;
        public byte[] data;
        public byte[] key;
        public byte[] iv;
        public AESAlgorytm()
        {
            this.aes = Aes.Create();
            this.key = aes.Key;
            this.iv = aes.IV;
        }
        public Aes returnAES()
        {
            return this.aes;
        }
        public byte[] returnAESKey()
        {
            return key;
        }
        public byte[] returnAESIv()
        {
            return this.iv;
        }
        public AESAlgorytm(byte[] key, byte[] iv)
        {
            this.aes = Aes.Create();
            this.aes.Key = key;
            this.aes.IV = iv;
        }
        public byte[] Encrypt(string textToHash)
        {
            try
            {
                if (textToHash == null || textToHash.Length <= 0)
                    throw new ArgumentNullException("plainText");
                if (key == null || key.Length <= 0)
                    throw new ArgumentNullException("Key");
                if (iv == null || iv.Length <= 0)
                    throw new ArgumentNullException("IV");
                byte[] encryptedTab;
                string encryptedString = "";
                using (Aes aes = Aes.Create())
                {
                    aes.Key = key;
                    aes.IV = iv;
                    ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        using (CryptoStream cryptoStreamEncrypt = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                        {
                            using (StreamWriter streamWriterEncrypt = new StreamWriter(cryptoStreamEncrypt))
                            {
                                streamWriterEncrypt.Write(textToHash);
                            }
                            encryptedTab = memoryStream.ToArray();
                        }
                    }
                }
                return encryptedTab;
            }
            catch (Exception ex)
            {
                throw new Exception("Encryption failed: " + ex.Message);
            }
        }
        public byte[] Encrypt(string textToHash, byte[] key, byte[] iv)
        {
            try
            {
                if (textToHash == null || textToHash.Length <= 0)
                    throw new ArgumentNullException("plainText");
                if (key == null || key.Length <= 0)
                    throw new ArgumentNullException("Key");
                if (iv == null || iv.Length <= 0)
                    throw new ArgumentNullException("IV");
                byte[] encryptedTab;
                string encryptedString = "";
                using (Aes aes = Aes.Create())
                {
                    aes.Key = key;
                    aes.IV = iv;
                    ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        using (CryptoStream cryptoStreamEncrypt = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                        {
                            using (StreamWriter streamWriterEncrypt = new StreamWriter(cryptoStreamEncrypt))
                            {
                                streamWriterEncrypt.Write(textToHash);
                            }
                            encryptedTab = memoryStream.ToArray();
                        }
                    }
                }
                return encryptedTab;
            }
            catch (Exception ex)
            {
                throw new Exception("Encryption failed: " + ex.Message);
            }
        }
        public byte[] DecryptAsBytes(byte[] dataToHash, byte[] key, byte[] iv)
        {
            try
            {
                if (dataToHash == null || dataToHash.Length <= 0)
                    throw new ArgumentNullException("plainText");
                if (key == null || key.Length <= 0)
                    throw new ArgumentNullException("Key");
                if (iv == null || iv.Length <= 0)
                    throw new ArgumentNullException("IV");
                byte[] decryptedBytes;
                using (Aes aes = Aes.Create())
                {
                    aes.Key = key;
                    aes.IV = iv;
                    ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
                    using (MemoryStream memoryStream = new MemoryStream(dataToHash))
                    {
                        using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                        {
                            using (MemoryStream decryptedStream = new MemoryStream())
                            {
                                cryptoStream.CopyTo(decryptedStream);
                                decryptedBytes = decryptedStream.ToArray();
                                return decryptedBytes;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Decryption failed: " + ex.Message);
            }
        }
        public string DecryptAsString(byte[] dataToHash, byte[] key, byte[] iv)
        {
            if (dataToHash == null || dataToHash.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (key == null || key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (iv == null || iv.Length <= 0)
                throw new ArgumentNullException("IV");
            string decryptedString = "";
            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = iv;
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
                using (MemoryStream memoryStream = new MemoryStream(dataToHash))
                {
                    using (CryptoStream cryptoStreamEncrypt = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReaderDecrypt = new StreamReader(cryptoStreamEncrypt))
                        {
                            decryptedString = streamReaderDecrypt.ReadToEnd();
                        }
                    }
                }
            }

            return decryptedString;
        }
    }
}