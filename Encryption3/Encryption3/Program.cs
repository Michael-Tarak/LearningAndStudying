using System;
using System.IO;
using System.Text;

namespace Encryption3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            while (true)
            {
                Console.Write("Введите текст: ");
                var text = Console.ReadLine().ToLower().Trim();
                Console.Write("Введите ключ: ");
                var key = Console.ReadLine().ToLower().Trim();
                Console.WriteLine("Выберите действие:\n1 - шифрование\n2 - дешифрование");
                var input = Console.ReadLine().ToLower();
                if (input == "exit")
                {
                    break;
                }
                switch (input)
                {
                    case "1":
                        Console.WriteLine($"Вывод: {Vigenere.Encrypt(text, key, Vigenere.Alphabet)}");
                        break;
                    case "2":
                        Console.WriteLine($"Вывод: {Vigenere.Encrypt(text,key,Vigenere.Alphabet,true)}");
                        break;
                    default:
                        Console.WriteLine("Неверная команда!");
                        break;
                }
            }
        }
    }
}
