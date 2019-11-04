using System;
using System.IO;
using System.Text;
namespace Encryption1
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            string alphabet = "";
            if (File.Exists("alphabet.txt"))
            {
                alphabet = File.ReadAllText("alphabet.txt");
            }
            else
            {
                Console.WriteLine("Не найден файл с алфавитом!");
            }
            while (true)
            {
                Console.WriteLine("Выберите действие:\n1 - шифрование\n2 - дешифрование\n3 - взлом\nДля выхода введите \"exit\"");
                var input = Console.ReadLine().ToLower();
                if (input == "exit")
                {
                    break;
                }
                switch (input)
                {
                    case "1":
                        Encryption(alphabet);
                        break;
                    case "2":
                        Decryption(alphabet);
                        break;
                    case "3":
                        Cracking(alphabet);
                        break;
                    default:
                        Console.WriteLine("Неверная команда!");
                        break;
                }
            }
        }
        static void Encryption(string alphabet)
        {
            try
            {
                var inputAlphabet = new StringBuilder(alphabet);
                var inputText = new StringBuilder(File.ReadAllText("encryptionInput.txt").ToLower());
                int step;
                while (true)
                {
                    Console.Write("Введите шаг: ");
                    if (int.TryParse(Console.ReadLine(), out step) && step >= 0)
                    {
                        break;
                    }
                    Console.WriteLine("Неверное значение!");
                }
                var outputText = new StringBuilder("");
                for (int i = 0; i < inputText.Length; i++)
                {
                    for (int j = 0; j < inputAlphabet.Length; j++)
                    {
                        if (inputText[i] == inputAlphabet[j])
                        {
                            outputText.Append(inputAlphabet[(j + step) % inputAlphabet.Length]);
                            break;
                        }
                    }
                }
                Console.WriteLine($"Ввод:  {inputText}");
                Console.WriteLine($"Вывод: {outputText}");
                File.WriteAllText("encryptionOutput.txt", outputText.ToString());
            }
            catch (IOException)
            {
                Console.WriteLine("Отсутствует файл!");
            }
        }
        static void Decryption(string alphabet)
        {
            try
            {
                var inputAlphabet = new StringBuilder(alphabet);
                var inputText = new StringBuilder(File.ReadAllText("encryptionOutput.txt").ToLower());
                int step;
                while (true)
                {
                    Console.Write("Введите шаг: ");
                    if (int.TryParse(Console.ReadLine(), out step) && step >= 0)
                    {
                        break;
                    }
                    Console.WriteLine("Неверное значение!");
                }
                var outputText = new StringBuilder("");
                for (int i = 0; i < inputText.Length; i++)
                {
                    for (int j = 0; j < inputAlphabet.Length; j++)
                    {
                        if (inputText[i] == inputAlphabet[j])
                        {
                            var move = (j - step);
                            if(move < 0)
                            {
                                move = (move + (-move / inputAlphabet.Length + 1) * inputAlphabet.Length) % inputAlphabet.Length;
                            }
                            outputText.Append(inputAlphabet[move]);
                        }
                    }
                }
                Console.WriteLine($"Ввод:  {inputText}");
                Console.WriteLine($"Вывод: {outputText}");
                File.WriteAllText("decryptionOutput.txt", outputText.ToString());
            }
            catch (IOException)
            {
                Console.WriteLine("Отсутствует файл!");
            }
        }
        static void Cracking(string alphabet)
        {
            try
            {
                var inputAlphabet = new StringBuilder(alphabet);
                var inputText = new StringBuilder(File.ReadAllText("encryptionOutput.txt").ToLower());
                var outputText = new StringBuilder();
                var outputFileLines = new string[alphabet.Length]; 
                Console.WriteLine($"Ввод:  {inputText}");
                for (int step = 0; step < alphabet.Length; step++)
                {
                    for (int i = 0; i < inputText.Length; i++)
                    {
                        for (int j = 0; j < inputAlphabet.Length; j++)
                        {
                            if (inputText[i] == inputAlphabet[j])
                            {
                                outputText.Append(inputAlphabet[(j + step) % inputAlphabet.Length]);
                                break;
                            }
                        }
                    }
                    Console.WriteLine($"Вывод: {outputText}");
                    outputFileLines[step] = outputText.ToString();
                    outputText.Clear();
                }
                File.WriteAllLines("crackOutput.txt", outputFileLines);
            }
            catch (IOException)
            {
                Console.WriteLine("Отсутствует файл!");
            }
        }
    }
}
