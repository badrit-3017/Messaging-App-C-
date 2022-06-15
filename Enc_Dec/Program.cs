/*-----------------------------------------------------------------------------------------
- Done by Badrit Bin Imran, Nizar Khalili and Yusuf Ghodiwala
- Purpose of this file: This is the file used for decrypting messages of the chat appp
- captured through wireshark
-
*/

using System;

namespace Enc_Dec
{
    class Program
    {
        static void Main(string[] args)
        {
            String password = "Password123"; //Password used for encryption
            Console.WriteLine("Press 1 for decrypting trivial encryption schemes, 2 for AES-256 decryption and 3 for quitting");
            int option = Convert.ToInt32(Console.ReadLine()); //option used for decryption
            while (option!=3)
            {
                Console.WriteLine();
                //Option 1 : We use trivial decryption
                if (option == 1)
                {
                    Console.WriteLine("Please paste the trivial encrypted string here");
                    string enc = Console.ReadLine();
                    string dec = Crypto.TrivialDecryption(enc);
                    Console.WriteLine("The decrypted string is:");
                    Console.WriteLine(dec);
                }
                //Option 2 : We use AES decryption
                else
                {
                    Console.WriteLine("Please enter the super secret password here");
                    password = Console.ReadLine();
                    Console.WriteLine("Please paste the AES encrypted string here");
                    string enc = Console.ReadLine();
                    string dec = Crypto.Decrypt(enc,password);
                    Console.WriteLine("The decrypted string is:");
                    Console.WriteLine(dec);
                }

            }


        }
    }
}
