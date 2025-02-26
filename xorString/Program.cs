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
            foreach (var t in encryptedString)
            {
                Console.Write(t);
                Console.Write(" ");
            }
            
            Console.WriteLine();
            
            var decryptedString = DecryptString(encryptedString, key);
            Console.Write("Decrypted string: ");
            foreach (var t in decryptedString)
            {
                Console.Write(t);
            }
        }

        static byte[] EncryptString(string input, string key)
        {
            // Check for differences in length of input and key
            if (input.Length < key.Length)
            {
                input.PadLeft(key.Length - input.Length, 'x');
            }
            else if (input.Length > key.Length)
            {
                key.PadLeft(input.Length - key.Length, 'x');
            }
            
            // Convert input string to byte array
            var inputByte = new byte[input.Length];
            for (int i = 0; i < inputByte.Length; i++)
            {
                inputByte[i] = Convert.ToByte(input[i]);
            }
            
            // Convert the key to a byte
            //byte keyByte = (byte)(key);
            var keyByte = new byte[key.Length];
            for (int i = 0; i < keyByte.Length; i++)
            {
                keyByte[i] = Convert.ToByte(key[i]);
            }
            
            // XOR the string with the key
            var encryptedString = new byte[inputByte.Length];
            
            for (int i = 0; i < inputByte.Length; i++)
            {
                encryptedString[i] = (byte)(inputByte[i] ^ keyByte[i]);
            }
            
            return encryptedString;
        }

        static string DecryptString(byte[] encryptedString, string key)
        {
            // Convert the key to a byte array
            var keyByte = new byte[key.Length];
            for (int i = 0; i < keyByte.Length; i++)
            {
                keyByte[i] = Convert.ToByte(key[i]);
            }
            
            // XOR the encrypted string with the key
            var decryptedBytes = new byte[encryptedString.Length];
            for (int i = 0; i < encryptedString.Length; i++)
            {
                decryptedBytes[i] = (byte)(encryptedString[i] ^ keyByte[i]);
            }
            
            // Convert the decrypted byte array to a string
            var decryptedString = "";
            for (int i = 0; i < decryptedBytes.Length; i++)
            {
                decryptedString += (char)decryptedBytes[i];
            }
            
            return decryptedString;
        }
    }
}