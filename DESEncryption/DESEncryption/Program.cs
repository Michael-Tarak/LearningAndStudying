using System;
using System.IO;
using System.Text;

namespace DESEncryption
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            var consoleInput = "";

            while (consoleInput != "quit")
            {
                Console.WriteLine("Введите команду:\n1 - шифрование\n2 - дешифрование\nquit - завершение программы");
                consoleInput = Console.ReadLine();
                var text = "";
                var key = "";
                switch (consoleInput)
                {
                    case "1":
                        Console.Write("Введите текст шифрования(шестнадцатеричный): ");
                        text = Console.ReadLine().ToLower().Trim();
                        Console.Write("Введите ключ шифрования(шестнадцатеричный): ");
                        key = Console.ReadLine().ToLower().Trim();
                        Console.WriteLine($"Вывод: {DES.BinarToHex(DES.Encrypt(DES.HexToBinar(text), DES.HexToBinar(key)))}");
                        break;
                    case "2":
                        Console.Write("Введите текст дешифрования(шестнадцатеричный): ");
                        text = Console.ReadLine().ToLower().Trim();
                        Console.Write("Введите ключ дешифрования(шестнадцатеричный): ");
                        key = Console.ReadLine().ToLower().Trim();
                        Console.WriteLine($"Вывод: {DES.BinarToHex(DES.Decrypt(DES.HexToBinar(text), DES.HexToBinar(key)))}");
                        break;
                    case "quit":
                        break;
                    default:
                        Console.WriteLine("Неверная команда!");
                        break;
                }
                
            }
        }
    }
}
