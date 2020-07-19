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
                Console.WriteLine("Выберите действие:\n1 - шифрование\n2 - дешифрование\nДля выхода введите \"exit\"");
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
                    default:
                        Console.WriteLine("Неверная команда!");
                        break;
                }
            }
            static void Encryption(string alphabet)
            {
                try
                {
                    string keyWordInput = "";
                    while (true)
                    {
                        Console.Write("Введите шифрующее слово(латиница):");
                        keyWordInput = Console.ReadLine().ToLower();
                        if (!string.IsNullOrWhiteSpace(keyWordInput))
                        {
                            break;
                        }
                        Console.WriteLine("Некорректное слово!");
                    }
                    var keyAppendable = new StringBuilder("");
                    var inputAlphabet = new StringBuilder(alphabet);
                    var inputText = new StringBuilder(File.ReadAllText("encryptionInput.txt").ToLower());
                    var outputText = new StringBuilder("");
                    while (keyAppendable.Length < inputText.Length)
                    {
                        keyAppendable.Append(keyWordInput);
                    }
                    if (keyAppendable.Length > inputText.Length)
                    {
                        keyAppendable.Remove(inputText.Length, keyAppendable.Length % inputText.Length);
                    }
                    var step = new int[keyAppendable.Length];
                    for (int i = 0; i < step.Length; i++)
                    {
                        for (int j = 0; j < alphabet.Length; j++)
                        {
                            if (keyAppendable[i] == alphabet[j])
                            {
                                step[i] = j;
                                break;
                            }
                        }
                    }
                    for (int i = 0; i < inputText.Length; i++)
                    {
                        for (int j = 0; j < alphabet.Length; j++)
                        {
                            if (inputText[i] == alphabet[j])
                            {
                                outputText.Append(alphabet[(j + step[i]) % alphabet.Length]);
                            }
                        }
                    }
                    Console.WriteLine($"Ввод:  {inputText}");
                    Console.WriteLine($"Вывод: {outputText}");
                    File.WriteAllText("encryptionOutput.txt", outputText.ToString());
                }
                catch (IOException)
                {
                    Console.WriteLine("Файл не найден!");
                }
            }
            static void Decryption(string alphabet)
            {
                try
                {
                    string keyWordInput = "";
                    while (true)
                    {
                        Console.Write("Введите шифрующее слово(латиница):");
                        keyWordInput = Console.ReadLine().ToLower();
                        if (!string.IsNullOrWhiteSpace(keyWordInput))
                        {
                            break;
                        }
                        Console.WriteLine("Некорректное слово!");
                    }
                    var keyAppendable = new StringBuilder("");
                    var inputAlphabet = new StringBuilder(alphabet);
                    var inputText = new StringBuilder(File.ReadAllText("encryptionOutput.txt").ToLower());
                    var outputText = new StringBuilder("");
                    while (keyAppendable.Length < inputText.Length)
                    {
                        keyAppendable.Append(keyWordInput);
                    }
                    if (keyAppendable.Length > inputText.Length)
                    {
                        keyAppendable.Remove(inputText.Length, keyAppendable.Length - inputText.Length);
                    }
                    var step = new int[keyAppendable.Length];
                    for (int i = 0; i < step.Length; i++)
                    {
                        for (int j = 0; j < alphabet.Length; j++)
                        {
                            if (keyAppendable[i] == alphabet[j])
                            {
                                step[i] = j;
                                break;
                            }
                        }
                    }
                    for (int i = 0; i < inputText.Length; i++)
                    {
                        for (int j = 0; j < alphabet.Length; j++)
                        {
                            if (inputText[i] == alphabet[j])
                            {
                                var move = (j - step[i]);
                                if (move < 0)
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
                    Console.WriteLine("Файл не найден!");
                }
            }

        }
    }
}
