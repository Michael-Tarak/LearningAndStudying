using System;
using System.IO;
using System.Text;

namespace XorSypher
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            var inputTextFile = "encodeInput.txt";
            var alphabetCryptFile = "alphabet.txt";
            while (true)
            {
                if (!File.Exists(inputTextFile))
                {
                    Console.WriteLine("Не найден файл с текстом!");
                    break;
                }
                if (!File.Exists(alphabetCryptFile))
                {
                    Console.WriteLine("Не найден файл с алфавитом!");
                    break;
                }

                var textToEncode = File.ReadAllText(inputTextFile).ToLower().Trim();
                var alphabetFromFile = File.ReadAllLines(alphabetCryptFile);
                var symbolAlphabet = new string [alphabetFromFile.Length];
                var gammedAlphabet = new string [alphabetFromFile.Length];

                Console.Write("Введите гамму (двоичная):");
                var gamma = Console.ReadLine();
            }
        }
    }
}
