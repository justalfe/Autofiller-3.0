using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace AutoFiller_API
{
    public class AES
    {
        public const string KEY = "mS7sBzS6HrqDJMQJCQaJ2ubxceMGEoQI8h5BuDLFHvk=";
        public const string VECTOR = "lp713LLkMxokgUY62oMbDQ==";

        //public static string EncryptLongData(string data)
        //{
        //    var rsa = GetNewRsaProvider();
        //    rsa.ImportParameters(GetRsaKey());
        //    var decryptedBytes = System.Text.Encoding.UTF8.GetBytes(data);
        //    var encryptedString = "";
        //    for (var i = 0; i < decryptedBytes.length; i += 256)
        //    {
        //        if (i == 0)
        //            encryptedString = System.Convert.ToBase64String(rsa.Encrypt(decryptedBytes.slice(i, i + 256), false));
        //        else
        //            encryptedString += "," + System.Convert.ToBase64String(rsa.Encrypt(decryptedBytes.slice(i, i + 256), false));
        //    }
        //    return encryptedString;
        //}
        public static string Encrypt(string data)
        {
            byte[] encrypted = EncryptStringToBytes_Aes(data, Convert.FromBase64String(KEY), Convert.FromBase64String(VECTOR));
            var encryptedString = Convert.ToBase64String(encrypted);
            return encryptedString;
        }

        // vector and key have to match between encryption and decryption
        public static string Decrypt(string encryptedString)
        {
            string decryptedString = DecryptStringFromBytes_Aes(Convert.FromBase64String(encryptedString), Convert.FromBase64String(KEY), Convert.FromBase64String(VECTOR));
            return decryptedString;
        }

        static byte[] EncryptStringToBytes_Aes(string plainText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");
            byte[] encrypted;

            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Create an encryptor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            //Write all data to the stream.
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }


            // Return the encrypted bytes from the memory stream.
            return encrypted;

        }

        static string DecryptStringFromBytes_Aes(byte[] cipherText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");

            // Declare the string used to hold
            // the decrypted text.
            string plaintext = null;

            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Create a decryptor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {

                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }

            }

            return plaintext;

        }
    }
}