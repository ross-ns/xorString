using System.Text;

namespace xorString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a string: ");
            var input = Console.ReadLine();
            Console.Write("Enter a key: ");
            var key = Console.ReadLine();
            
            var encryptedString = EncryptString(input, key);
            
            Console.Write("Encrypted string: ");
            foreach (var t in encryptedString.encryptedString)
            {
                Console.Write(t);
                Console.Write(" ");
            }
            
            Console.WriteLine();
            
            var decryptedString = DecryptString(encryptedString.encryptedString, encryptedString.keyByte);
            Console.Write("Decrypted string: ");
            foreach (var t in decryptedString)
            {
                Console.Write(t);
            }
        }

        static (byte[] encryptedString, byte[] keyByte) EncryptString(string input, string key)
        {
            // Check for differences in length of input and key
            if (input.Length < key.Length)
            {
                input = input.PadLeft(key.Length, '\u0000');
            }
            else if (input.Length > key.Length)
            {
                key = key.PadLeft(input.Length, '\u0000');
            }
            
            // Convert input strings to byte arrays
            var inputByte = Encoding.UTF8.GetBytes(input);
            var keyByte = Encoding.UTF8.GetBytes(key);
            
            // XOR the string with the key
            var encryptedString = new byte[inputByte.Length];
            
            for (int i = 0; i < inputByte.Length; i++)
            {
                encryptedString[i] = (byte)(inputByte[i] ^ keyByte[i]);
            }
            
            return (encryptedString, keyByte);
        }

        static string DecryptString(byte[] encryptedString, byte[] key)
        {
            // XOR the encrypted string with the key
            var decryptedBytes = new byte[encryptedString.Length];
            for (int i = 0; i < encryptedString.Length; i++)
            {
                decryptedBytes[i] = (byte)(encryptedString[i] ^ key[i]);
            }
            
            // Convert the decrypted byte array to a string
            var decryptedString = Encoding.UTF8.GetString(decryptedBytes);

            return decryptedString;
        }
    }
}