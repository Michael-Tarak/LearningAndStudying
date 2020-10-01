using System;
using System.IO;
using System.Text;
namespace CaesarCypher
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            while (true)
            {
                Console.WriteLine("Выберите действие:\n1 - шифрование/дешифрование\n2 - взлом\nДля выхода введите \"exit\"");
                var input = Console.ReadLine().ToLower().Trim();
                if (input == "exit")
                {
                    break;
                }
                switch (input)
                {
                    case "1":
                        Console.Write("Введите текст: ");
                        var text = Console.ReadLine().Trim();
                        Console.Write("Введите шаг(отрицательный для расшифровки): ");
                        var step = int.Parse(Console.ReadLine().Trim());
                        Console.WriteLine($"Вывод: {CaesarCode.Encrypt(text,step)}");
                        break;
                    case "2":
                        Console.Write("Введите текст: ");
                        var textCrack = Console.ReadLine().Trim();
                        var crackOutput = CaesarCode.Crack(textCrack);
                        for (int i = 0; i < crackOutput.Length; i++)
                        {
                            Console.WriteLine($"{crackOutput[i]}");
                        }
                        break;
                    default:
                        Console.WriteLine("Неверная команда!");
                        break;
                }
            }
        }
    }
}
