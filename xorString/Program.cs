using System.Text;

namespace xorString
{
    internal class Program
    {
        private static byte[] Input { get; set; }
        private static byte[] Key { get; set; }
        private static byte[] EncryptedString { get; set; }

        static void Main(string[] args)
        {
            Console.Write("Enter a string: ");
            var input = Console.ReadLine();
            Console.Write("Enter a key: ");
            var key = Console.ReadLine();
            
            EncryptString(input, key);
            
            Console.Write("Encrypted string: ");
            foreach (var t in EncryptedString)
            {
                Console.Write(t);
                Console.Write(" ");
            }
            
            Console.WriteLine();
            
            var decryptedString = DecryptString(EncryptedString, key);
            Console.Write("Decrypted string: " + decryptedString);
        }

        static void PadInputs(string input, string key)
        {
            Console.Write("Input length: " + input.Length + " key length: " + key.Length);
            if (input.Length < key.Length)
            {
                input = input.PadLeft(key.Length - input.Length, 'x');
                Input = Encoding.UTF8.GetBytes(input);
            }
            else if (input.Length > key.Length)
            {
                key = key.PadLeft(input.Length - key.Length + 1, 'x');
                Key = Encoding.UTF8.GetBytes(key);
            }
            else if (input.Length == key.Length)
            {
                Input = Encoding.UTF8.GetBytes(input);
                Key = Encoding.UTF8.GetBytes(key);
            }
            else
            {
                throw new Exception("Input lengths cannot be determined");
            }
        }

        static void EncryptString(string input, string key)
        {
            // Pad inputs if required
            PadInputs(input, key);
            
            // XOR the string with the key
            //var encryptedString = new byte[Input.Length];
            
            for (int i = 0; i < Input.Length; i++)
            {
                EncryptedString[i] = (byte)(Input[i] ^ Key[i]);
            }
        }

        static string DecryptString(byte[] encryptedString, string key)
        {
            // Convert the key to a byte array
            var keyByte = Encoding.UTF8.GetBytes(key);

            // XOR the encrypted string with the key
            var decryptedBytes = new byte[encryptedString.Length];
            for (int i = 0; i < encryptedString.Length; i++)
            {
                decryptedBytes[i] = (byte)(encryptedString[i] ^ keyByte[i]);
            }
            
            // Convert the decrypted byte array to a string
            return Encoding.UTF8.GetString(decryptedBytes);
        }
    }
}