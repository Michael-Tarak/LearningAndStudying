using System;
using System.IO;
using System.Text;

namespace Encryption2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            while (true)
            {
                Console.WriteLine("Выберите действие:\n1 - шифрование\n2 - дешифрование\nДля выхода введите \"exit\"");
                var input = Console.ReadLine().ToLower();
                if (input == "exit")
                {
                    break;
                }
                switch (input)
                {
                    case "1":
                        Console.Write("Введите текст: ");
                        Console.WriteLine($"Вывод: {Substitution.Encrypt(Console.ReadLine().ToLower().Trim(), Substitution.AlphabetDefault[0], Substitution.AlphabetDefault[1])}");
                        break;
                    case "2":
                        Console.Write("Введите текст: ");
                        Console.WriteLine($"Вывод: {Substitution.Encrypt(Console.ReadLine().ToLower().Trim(), Substitution.AlphabetDefault[1], Substitution.AlphabetDefault[0])}");

                        break;
                    default:
                        Console.WriteLine("Неверная команда!");
                        break;
                }
            }
        }
    }
}
