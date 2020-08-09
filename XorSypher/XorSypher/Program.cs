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

            var encodeTextFileName = "encodeInput.txt";
            var decodeTextFileName = "encodeOutput.txt";
            var alphabetCryptFile = "alphabet.txt";
            while (true)
            {
                if (!File.Exists(encodeTextFileName))
                {
                    Console.WriteLine("Не найден файл с текстом!");
                    break;
                }
                if (!File.Exists(alphabetCryptFile))
                {
                    Console.WriteLine("Не найден файл с алфавитом!");
                    break;
                }

                var textToEncode = File.ReadAllText(encodeTextFileName).ToLower().Trim();

                var alphabetFromFile = File.ReadAllLines(alphabetCryptFile);
                var symbolAlphabet = new char[alphabetFromFile.Length];
                var gammedAlphabet = new string[alphabetFromFile.Length];

                for (int i = 0; i < alphabetFromFile.Length; i++)
                {
                    symbolAlphabet[i] = alphabetFromFile[i][0];
                    gammedAlphabet[i] = alphabetFromFile[i].Substring(2).Trim();
                    //Console.WriteLine($"{symbolAlphabet[i]},{gammedAlphabet[i]}");
                }

                for (int i = 1; i < gammedAlphabet.Length; i++)
                {
                    if (gammedAlphabet[i].Length != gammedAlphabet[i - 1].Length)
                    {
                        Console.WriteLine($"Длина гаммы {i + 1}-го символа отлична от предыдущего!");
                    }
                }

                Console.Write("Введите ключ (двоичный): ");
                var gammaKey = Console.ReadLine().Trim();
                string gammedFileText = "";

                for (int j = 0; j < textToEncode.Length; j++)
                {
                    for (int i = 0; i < symbolAlphabet.Length; i++)
                    {
                        if (textToEncode[j] == symbolAlphabet[i])
                        {
                            gammedFileText += gammedAlphabet[i];
                            break;
                        }
                        else if (i == symbolAlphabet.Length)
                        {
                            Console.WriteLine($"{j + 1}-й символ в тексте отсутствует в алфавите!");
                        }
                    }
                }

                var extendableGammaKey = gammaKey;

                while (gammedFileText.Length > extendableGammaKey.Length)
                {
                    extendableGammaKey += gammaKey;
                }
                if (extendableGammaKey.Length > gammedFileText.Length)
                {
                    extendableGammaKey = extendableGammaKey.Substring(0, gammedFileText.Length);
                }

                string binarTextXORResult = "";

                for (int i = 0; i < gammedFileText.Length; i++)         //XOR
                {
                    if (extendableGammaKey[i] == gammedFileText[i])
                    {
                        binarTextXORResult += "0";
                    }
                    else
                    {
                        binarTextXORResult += "1";
                    }
                }

                int gammaMarker = 0;
                var alphabetSymbolEncodingLength = gammedAlphabet[0].Length;
                string outputText = "";

                while (gammaMarker < binarTextXORResult.Length)
                {
                    var pieceOfXOR = binarTextXORResult.Substring(gammaMarker, alphabetSymbolEncodingLength);
                    //Console.Write(pieceOfXOR);
                    for (int i = 0; i < gammedAlphabet.Length; i++)
                    {
                        if (pieceOfXOR.Equals(gammedAlphabet[i]))
                        {
                            //Console.WriteLine(symbolAlphabet[i]);
                            outputText += symbolAlphabet[i];
                            break;
                        }
                    }
                    gammaMarker += alphabetSymbolEncodingLength;
                }
                File.WriteAllText(decodeTextFileName, outputText);
                Console.WriteLine($"Вывод: {outputText}");
            }
        }
    }
}
