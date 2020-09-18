using System;
namespace DESEncryption
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = "00010010001101000101011010101011110011010001001100100101001101100";
            var key =  "10101010101110110000100100011000001001110011011011001100";
            Console.WriteLine(DES.BinarToHex(text));
            Console.WriteLine(DES.BinarToHex(DES.Decrypt(DES.Encrypt(text, key), key)));
            
            
        }
    }
}
