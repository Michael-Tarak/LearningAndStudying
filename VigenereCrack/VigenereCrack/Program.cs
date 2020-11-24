using System;
using System.IO;
using System.Linq;
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
            var englishIoC = 0.065;

            while (true)
            {
                Console.Write("Нажмите \"Enter\", чтобы взломать шифр.");
                Console.ReadLine();
                if (File.Exists("encodedText.txt"))
                {
                    encodedText = File.ReadAllText("encodedText.txt").ToLower();
                }
                else
                {
                    Console.WriteLine("Не найден файл с зашифрованным текстом!");
                    break;
                }

                int possibleIoC = 0;
                double smallestdiff = 1;
                double difIoC = smallestdiff;

                for (int cypherCycleLength = 2; cypherCycleLength < 13; cypherCycleLength++)
                {
                    var indexOfCoincidence = IndexOfCoincidence(cypherCycleLength, encodedText);
                    difIoC = Math.Abs(englishIoC - indexOfCoincidence);
                    if (difIoC < smallestdiff)
                    {
                        possibleIoC = cypherCycleLength;
                        smallestdiff = difIoC;
                    }
                    Console.WriteLine($"Индекс совпадения ключа из {cypherCycleLength} символов: { indexOfCoincidence.ToString()}");
                }
                Console.WriteLine($"Предположительная длина ключа: {possibleIoC}");
            }
        }
        static double IndexOfCoincidence(int length, string text)
        {
            string filteredText = "";

            for (var symbolCutterPosition = 0; symbolCutterPosition < text.Length; symbolCutterPosition +=length)
            {
                filteredText += text[symbolCutterPosition];
            }

            double textLength = filteredText.Length;
            var aCount = Convert.ToDouble(filteredText.Count(a => a == 'a'));
            var bCount = Convert.ToDouble(filteredText.Count(b => b == 'b'));
            var cCount = Convert.ToDouble(filteredText.Count(c => c == 'c'));
            var dCount = Convert.ToDouble(filteredText.Count(d => d == 'd'));
            var eCount = Convert.ToDouble(filteredText.Count(e => e == 'e'));
            var fCount = Convert.ToDouble(filteredText.Count(f => f == 'f'));
            var gCount = Convert.ToDouble(filteredText.Count(g => g == 'g'));
            var hCount = Convert.ToDouble(filteredText.Count(h => h == 'h'));
            var iCount = Convert.ToDouble(filteredText.Count(i => i == 'i'));
            var jCount = Convert.ToDouble(filteredText.Count(j => j == 'j'));
            var kCount = Convert.ToDouble(filteredText.Count(k => k == 'k'));
            var lCount = Convert.ToDouble(filteredText.Count(l => l == 'l'));
            var mCount = Convert.ToDouble(filteredText.Count(m => m == 'm'));
            var nCount = Convert.ToDouble(filteredText.Count(n => n == 'n'));
            var oCount = Convert.ToDouble(filteredText.Count(o => o == 'o'));
            var pCount = Convert.ToDouble(filteredText.Count(p => p == 'p'));
            var qCount = Convert.ToDouble(filteredText.Count(q => q == 'q'));
            var rCount = Convert.ToDouble(filteredText.Count(r => r == 'r'));
            var sCount = Convert.ToDouble(filteredText.Count(s => s == 's'));
            var tCount = Convert.ToDouble(filteredText.Count(t => t == 't'));
            var uCount = Convert.ToDouble(filteredText.Count(u => u == 'u'));
            var vCount = Convert.ToDouble(filteredText.Count(v => v == 'v'));
            var wCount = Convert.ToDouble(filteredText.Count(w => w == 'w'));
            var xCount = Convert.ToDouble(filteredText.Count(x => x == 'x'));
            var yCount = Convert.ToDouble(filteredText.Count(y => y == 'y'));
            var zCount = Convert.ToDouble(filteredText.Count(z => z == 'z'));

            var aIoC = (aCount * (aCount - 1)) / (textLength * (textLength - 1));
            var bIoC = (bCount * (bCount - 1)) / (textLength * (textLength - 1));
            var cIoC = (cCount * (cCount - 1)) / (textLength * (textLength - 1));
            var dIoC = (dCount * (dCount - 1)) / (textLength * (textLength - 1));
            var eIoC = (eCount * (eCount - 1)) / (textLength * (textLength - 1));
            var fIoC = (fCount * (fCount - 1)) / (textLength * (textLength - 1));
            var gIoC = (gCount * (gCount - 1)) / (textLength * (textLength - 1));
            var hIoC = (hCount * (hCount - 1)) / (textLength * (textLength - 1));
            var iIoC = (iCount * (iCount - 1)) / (textLength * (textLength - 1));
            var jIoC = (jCount * (jCount - 1)) / (textLength * (textLength - 1));
            var kIoC = (kCount * (kCount - 1)) / (textLength * (textLength - 1));
            var lIoC = (lCount * (lCount - 1)) / (textLength * (textLength - 1));
            var mIoC = (mCount * (mCount - 1)) / (textLength * (textLength - 1));
            var nIoC = (nCount * (nCount - 1)) / (textLength * (textLength - 1));
            var oIoC = (oCount * (oCount - 1)) / (textLength * (textLength - 1));
            var pIoC = (pCount * (pCount - 1)) / (textLength * (textLength - 1));
            var qIoC = (qCount * (qCount - 1)) / (textLength * (textLength - 1));
            var rIoC = (rCount * (rCount - 1)) / (textLength * (textLength - 1));
            var sIoC = (sCount * (sCount - 1)) / (textLength * (textLength - 1));
            var tIoC = (tCount * (tCount - 1)) / (textLength * (textLength - 1));
            var uIoC = (uCount * (uCount - 1)) / (textLength * (textLength - 1));
            var vIoC = (vCount * (vCount - 1)) / (textLength * (textLength - 1));
            var wIoC = (wCount * (wCount - 1)) / (textLength * (textLength - 1));
            var xIoC = (xCount * (xCount - 1)) / (textLength * (textLength - 1));
            var yIoC = (yCount * (yCount - 1)) / (textLength * (textLength - 1));
            var zIoC = (zCount * (zCount - 1)) / (textLength * (textLength - 1));

            return aIoC + bIoC + cIoC + dIoC + eIoC + fIoC + gIoC + hIoC + iIoC +
                jIoC + kIoC + lIoC + mIoC + nIoC + oIoC + pIoC + qIoC + rIoC + sIoC +
                tIoC + uIoC + vIoC + wIoC + xIoC + yIoC + zIoC;
        }
    }
}
