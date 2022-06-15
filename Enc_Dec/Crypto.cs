using System.IO;
using System.Text;
using System.Security.Cryptography;
using System;

namespace Enc_Dec
{
    //Credit A Ghazal from https://stackoverflow.com/questions/10168240/encrypting-decrypting-a-string-in-c-sharp
    //This is a helper class used to encrypt and decrypt messages
    public static class Crypto
    {
        //Method Ecrypt
        //This is the encrypt method used for AES-256 bit encryption
        //This method takes two parameters - the encryption string and the key and returns the ecnrypted text
        public static string Encrypt(string clearText, string EncryptionKey)
        {
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }

        //Method Decrypt
        //This is the decrypt method used for AES-256 bit encryption
        //This method takes two parameters - the decryption string and the key and returns the decrypted text
        public static string Decrypt(string cipherText, string EncryptionKey)
        {
            cipherText = cipherText.Replace(" ", "+");
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                MemoryStream ms = new MemoryStream();

                CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write);
                 
                cs.Write(cipherBytes, 0, cipherBytes.Length);
                cs.FlushFinalBlock();
                    
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                
            }
            return cipherText;
        }

        //Method TrivialEncryption
        //This is the encryption method used for trivial encryption
        //This method takes one parameter - the encryption string and returns the ecnrypted string
        public static String TrivialEncryption(String s)
        {
            char[] chars = new char[512];
            for (int i = 0; i < s.Length; i++)
            {
                Int32 x = System.Convert.ToInt32(s[i]) + 1; //Adds 1 to the ASCII value to encrypt
                chars[i] = (char)x;

            }

            string encrypted = new string(chars);

            return encrypted;
        }

        //Method TrivialDecryption
        //This is the decryption method used for trivial decryption
        //This method takes one parameter - the decryption string and returns the decryption string
        public static String TrivialDecryption(String s)
        {
            char[] chars = new char[512];
            for (int i = 0; i < s.Length; i++)
            {
                Int32 x = System.Convert.ToInt32(s[i]) - 1; //Subtracts 1 to the ASCII value to decrypt
                if (x != -1) chars[i] = (char)x;
                else break;
            }
            string decrypted = new string(chars);
            return decrypted;
        }
    }
}