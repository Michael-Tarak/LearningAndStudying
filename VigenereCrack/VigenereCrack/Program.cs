using System;
using System.IO;
using System.Text;

namespace VigenereCrack
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            string encodedText = "";
            //if(File.Exists("encodedText.txt"))
            //{
            //    encodedText = File.ReadAllText("encodedText.txt").ToLower();
            //}
            //else
            //{
            //    Console.WriteLine("Не найден файл с зашифрованным текстом!");
            //}
            while(true)
            {
                Console.Write("Введите зашифрованный текст (на английском языке, только буквы, без пробелов):");
                encodedText = Console.ReadLine().ToLower().Trim();
                if(encodedText == "exit")
                {
                    break;
                }
                for(int cypherCycleLength = 2; cypherCycleLength < 10; cypherCycleLength++)
                {

                }    
            }
        }
        double IndexOfCoincidence(int potentialLength, string text)
        {
            string filteredText = "";
            for (var symbolCutterPosition = 0; symbolCutterPosition < text.Length; symbolCutterPosition +=potentialLength)
            {
                filteredText += text[symbolCutterPosition];
            }
        }
    }
}
