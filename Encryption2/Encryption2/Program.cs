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
            string alphabet = "";
            var alphabetDirectory = "alphabet.txt";
            if (File.Exists(alphabetDirectory))
            {
                alphabet = File.ReadAllText(alphabetDirectory);
            }
            else
            {
                Console.WriteLine("Не найден файл с алфавитом!");
            }
            string key = "";
            var keyDirectory = "key.txt";
            if (File.Exists(keyDirectory))
            {
                key = File.ReadAllText(keyDirectory);
            }
            else
            {
                Console.WriteLine("Не найден файл с шифром/ключом!");
            }
            if(alphabet.Length != key.Length)
            {
                Console.WriteLine("Количество символов в файлах не совпадает! Проверьте файлы alphabet.txt и key.txt на наличие всех букв");
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
                        Encryption(alphabet, key);
                        break;
                    case "2":
                        Decryption(alphabet, key);
                        break;
                    default:
                        Console.WriteLine("Неверная команда!");
                        break;
                }
            }
        }
        static void Encryption(string alphabet, string key)
        {
            try
            {
                var keyInput = new StringBuilder(key);
                var alphabetInput = new StringBuilder(alphabet);
                var textInput = new StringBuilder(File.ReadAllText("encryptionInput.txt").ToLower());
                var textOutput = new StringBuilder("");
                for (int i = 0; i < textInput.Length; i++)
                {
                    for (int j = 0; j < alphabetInput.Length; j++)
                    {
                        if(textInput[i] == alphabetInput[j])
                        {
                            textOutput.Append(keyInput[j]);
                            break;
                        }
                    }
                }
                Console.WriteLine($"Ввод:  {textInput}");
                Console.WriteLine($"Вывод: {textOutput}");
                File.WriteAllText("encryptionOutput.txt", textOutput.ToString());
            }
            catch (IOException)
            {
                Console.WriteLine("Отсутствует файл!");
            }
        }
        static void Decryption (string alphabet, string key)
        {
            try
            {
                var keyInput = new StringBuilder(key);
                var alphabetInput = new StringBuilder(alphabet);
                var textInput = new StringBuilder(File.ReadAllText("encryptionOutput.txt").ToLower());
                var textOutput = new StringBuilder("");
                for (int i = 0; i < textInput.Length; i++)
                {
                    for (int j = 0; j < alphabetInput.Length; j++)
                    {
                        if (textInput[i] == keyInput[j])
                        {
                            textOutput.Append(alphabetInput[j]);
                            break;
                        }
                    }
                }
                Console.WriteLine($"Ввод:  {textInput}");
                Console.WriteLine($"Вывод: {textOutput}");
                File.WriteAllText("decryptionOutput.txt", textOutput.ToString());
            }
            catch (IOException)
            {
                Console.WriteLine("Отсутствует файл!");
            }

        }
    }
}
