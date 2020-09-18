using System;
namespace DESEncryption
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = "0001001000110100010101101010101111001101000100110010010100110110";
            var key =  "10101010101110110000100100011000001001110011011011001100";
            Console.WriteLine(DES.BinarToHex(text));
            Console.WriteLine(DES.BinarToHex(DES.Decrypt(DES.Encrypt(text, key), key)));
            
            
        }
    }
}
