using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Utilities
{
    public static class StringCipher
    {
        public static string Decrypt(string encrypted, string password)
        {
            using (Aes AES = Aes.Create())
            {

                byte[] passwordBytes = Encoding.ASCII.GetBytes(password);
                byte[] aesKey = SHA256Managed.Create().ComputeHash(passwordBytes);
                byte[] aesIV = MD5.Create().ComputeHash(passwordBytes);
                AES.Key = aesKey;
                AES.IV = aesIV;
                AES.Mode = CipherMode.CBC;
                AES.Padding = PaddingMode.PKCS7;

                // Encrypt the string to an array of bytes.
                byte[] bytes = Convert.FromBase64String(encrypted);
                return DecryptStringFromBytes_Aes(bytes, AES.Key, AES.IV);
            }
        }

        public static string Encrypt(string plainText, string password)
        {
            using (Aes AES = Aes.Create())
            {

                byte[] passwordBytes = Encoding.ASCII.GetBytes(password);
                byte[] aesKey = SHA256Managed.Create().ComputeHash(passwordBytes);
                byte[] aesIV = MD5.Create().ComputeHash(passwordBytes);
                AES.Key = aesKey;
                AES.IV = aesIV;
                AES.Mode = CipherMode.CBC;
                AES.Padding = PaddingMode.PKCS7;

                // Encrypt the string to an array of bytes.
                byte[] encrypted = EncryptStringToBytes_Aes(plainText, AES.Key, AES.IV);

                return Convert.ToBase64String(encrypted);
            }
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
