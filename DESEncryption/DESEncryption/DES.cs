using System;

namespace DESEncryption
{
    static class DES
    {
        private static readonly int[][,] sBoxes = new int[][,]
        {
            new int [4,16] {//1
                { 14, 4, 13, 1, 2, 15, 11, 8, 3, 10, 6, 12, 5, 9, 0, 7 },
                { 0, 15, 7, 4, 14, 2, 13, 1, 10, 6, 12, 11, 9, 5, 3, 8 },
                { 4, 1, 14, 8, 13, 6, 2, 11, 15, 12, 9, 7, 3, 10, 5, 0 },
                { 15, 12, 8, 2, 4, 9, 1, 7, 5, 11, 3, 14, 10, 0, 6, 13 }
            },
            new int [4,16] {//2
                { 15, 1, 8, 14, 6, 11, 3, 4, 9, 7, 2, 13, 12, 0, 5, 10 },
                { 3, 13, 4, 7, 15, 2, 8, 14, 12, 0, 1, 10, 6, 9, 11, 5 },
                { 0, 14, 7, 11, 10, 4, 13, 1, 5, 8, 12, 6, 9, 3, 2, 15 },
                { 13, 8, 10, 1, 3, 15, 4, 2, 11, 6, 7, 12, 0, 5, 14, 9 }
            },
            new int [4,16] {//3
                { 10, 0, 9, 14, 6, 3, 15, 5, 1, 13, 12, 7, 11, 4, 2, 8 },
                { 13, 7, 0, 9, 3, 4, 6, 10, 2, 8, 5, 14, 12, 11, 15, 1 },
                { 13, 6, 4, 9, 8, 15, 3, 0, 11, 1, 2, 12, 5, 10, 14, 7 },
                { 1, 10, 13, 0, 6, 9, 8, 7, 4, 15, 14, 3, 11, 5, 2, 12 }
            },
            new int [4,16] {//4
                { 7, 13, 14, 3, 0, 6, 9, 10, 1, 2, 8, 5, 11, 12, 4, 15 },
                { 13, 8, 11, 5, 6, 15, 0, 3, 4, 7, 2, 12, 1, 10, 14, 9 },
                { 10, 6, 9, 0, 12, 11, 7, 13, 15, 1, 3, 14, 5, 2, 8, 4 },
                { 3, 15, 0, 6, 10, 1, 13, 8, 9, 4, 5, 11, 12, 7, 2, 14 }
            },
            new int [4,16] {//5
                { 2, 12, 4, 1, 7, 10, 11, 6, 8, 5, 3, 15, 13, 0, 14, 9 },
                { 14, 11, 2, 12, 4, 7, 13, 1, 5, 0, 15, 10, 3, 9, 8, 6 },
                { 4, 2, 1, 11, 10, 13, 7, 8, 15, 9, 12, 5, 6, 3, 0, 14 },
                { 11, 8, 12, 7, 1, 14, 2, 13, 6, 15, 0, 9, 10, 4, 5, 3 }
            },
            new int [4,16] {//6
                { 12, 1, 10, 15, 9, 2, 6, 8, 0, 13, 3, 4, 14, 7, 5, 11 },
                { 10, 15, 4, 2, 7, 12, 9, 5, 6, 1, 13, 14, 0, 11, 3, 8 },
                { 9, 14, 15, 5, 2, 8, 12, 3, 7, 0, 4, 10, 1, 13, 11, 6 },
                { 4, 3, 2, 12, 9, 5, 15, 10, 11, 14, 1, 7, 6, 0, 8, 13 }
            },
            new int [4,16] {//7
                { 4, 11, 2, 14, 15, 0, 8, 13, 3, 12, 9, 7, 5, 10, 6, 1 },
                { 13, 0, 11, 7, 4, 9, 1, 10, 14, 3, 5, 12, 2, 15, 8, 6 },
                { 1, 4, 11, 13, 12, 3, 7, 14, 10, 15, 6, 8, 0, 5, 9, 2 },
                { 6, 11, 13, 8, 1, 4, 10, 7, 9, 5, 0, 15, 14, 2, 3, 12 }
            },
            new int [4,16] {//8
                { 13, 2, 8, 4, 6, 15, 11, 1, 10, 9, 3, 14, 5, 0, 12, 7 },
                { 1, 15, 13, 8, 10, 3, 7, 4, 12, 5, 6, 11, 0, 14, 9, 2 },
                { 7, 11, 4, 1, 9, 12, 14, 2, 0, 6, 10, 13, 15, 3, 5, 8 },
                { 2, 1, 14, 7, 4, 10, 8, 13, 15, 12, 9, 0, 3, 5, 6, 11 }
            },
        };
        public static string Encrypt(string binaryText, string binaryKey)
        {
            while (binaryText.Length % 64 != 0)
            {
                binaryText += "0";
            }
            var result = "";
            var blockCounter = 0;
            for (int i = 0; i < binaryText.Length; i++)
            {
                var tempText = IPFirst(binaryText.Substring(blockCounter,64));
                var generatedRoundKey = RoundKeysGenerator(binaryKey);
                for (int j = 0; j < 16; j++)
                {
                    tempText = Round(tempText, generatedRoundKey[j], j + 1);
                }
                result += IPLast(tempText);
            }

            return result;
        }
        public static string Decrypt(string binaryText, string binaryKey)
        {
            var tempText = IPFirst(binaryText);
            var generatedRoundKey = RoundKeysGenerator(binaryKey);
            for (int i = 0; i < 16; i++)
            {
                tempText = Round(tempText, generatedRoundKey[15-i], i+1);
            }
            return IPLast(tempText);
        }
        private static string Round(string textBinary, string roundKey,int roundNumber)
        {
            var leftPart = textBinary.Substring(0, 32);
            var rightPart = textBinary.Substring(32);
            if (roundNumber == 16)
            {
                return XOR(leftPart, FeistelFunction(rightPart, roundKey)) + rightPart;
            }
            return rightPart + XOR(leftPart, FeistelFunction(rightPart, roundKey));

        }
        private static string [] RoundKeysGenerator(string inputKey)
        {
            var keyCheckExtdFull = "";
            if (inputKey.Length == 56)
            {
                string[] keyCheckExtd = { "", "", "", "", "", "", "", "" }; //8
                var byteLength = 0;
                for (int i = 0; i < keyCheckExtd.Length; i++)
                {
                    keyCheckExtd[i] = inputKey.Substring(byteLength, 7);
                    if ((NumberOneCounter(keyCheckExtd[i]) % 2) == 0)
                    {
                        keyCheckExtd[i] = keyCheckExtd[i].Insert(0, "1");
                    }
                    else
                    {
                        keyCheckExtd[i] = keyCheckExtd[i].Insert(0, "0");
                    }
                    byteLength += 7;
                }

                
                for (int i = 0; i < keyCheckExtd.Length; i++)
                {
                    keyCheckExtdFull += keyCheckExtd[i];
                }
            }
            else
            {
                keyCheckExtdFull = inputKey;
            }
            

            string[] cI = new string[17];
            string[] dI = new string[17];
            (cI[0], dI[0]) = ZeroCAndDGenerator(keyCheckExtdFull);
            for (int j = 1; j < cI.Length; j++) //j=0 for C0 and D0
            {
                int shiftMove;
                if (j == 1 || j == 2 || j == 9 || j == 16)
                {
                    shiftMove = 1;
                }
                else
                {
                    shiftMove = 2;
                }
                for (int i = 0; i < 28; i++)
                {
                    cI[j] += cI[j-1][(i + shiftMove) % 28];
                    dI[j] += dI[j-1][(i + shiftMove) % 28];
                }
            }

            string[] result = new string[16];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = PBox(cI[i + 1] + dI[i + 1]);
            }

            return result;

            string PBox(string input)
            {
                var result = "";
                result += input[13];
                result += input[16];
                result += input[10];
                result += input[23];
                result += input[0];
                result += input[4];
                result += input[2];
                result += input[27];
                result += input[14];
                result += input[5];
                result += input[20];
                result += input[9];
                result += input[22];
                result += input[18];
                result += input[11];
                result += input[3];
                result += input[25];
                result += input[7];
                result += input[15];
                result += input[6];
                result += input[26];
                result += input[19];
                result += input[12];
                result += input[1];
                result += input[40];
                result += input[51];
                result += input[30];
                result += input[36];
                result += input[46];
                result += input[54];
                result += input[29];
                result += input[39];
                result += input[50];
                result += input[44];
                result += input[32];
                result += input[47];
                result += input[43];
                result += input[48];
                result += input[38];
                result += input[55];
                result += input[33];
                result += input[52];
                result += input[45];
                result += input[41];
                result += input[49];
                result += input[35];
                result += input[28];
                result += input[31];
                return result;
            }
            int NumberOneCounter(string input)
            {
                var result = 0;
                for (int i = 0; i < input.Length; i++)
                {
                    if (input[i] == '1')
                    {
                        result++;
                    }
                }
                return result;
            }
            (string, string) ZeroCAndDGenerator(string input)
            {
                var outputC = "";
                var outputD = "";

                outputC += input[56];
                outputC += input[48];
                outputC += input[40];
                outputC += input[32];
                outputC += input[24];
                outputC += input[16];
                outputC += input[8];
                outputC += input[0];
                outputC += input[57];
                outputC += input[49];
                outputC += input[41];
                outputC += input[33];
                outputC += input[25];
                outputC += input[17];
                outputC += input[9];
                outputC += input[1];
                outputC += input[58];
                outputC += input[50];
                outputC += input[42];
                outputC += input[34];
                outputC += input[26];
                outputC += input[18];
                outputC += input[10];
                outputC += input[2];
                outputC += input[59];
                outputC += input[51];
                outputC += input[43];
                outputC += input[35];

                outputD += input[62];
                outputD += input[54];
                outputD += input[46];
                outputD += input[38];
                outputD += input[30];
                outputD += input[22];
                outputD += input[14];
                outputD += input[6];
                outputD += input[61];
                outputD += input[53];
                outputD += input[45];
                outputD += input[37];
                outputD += input[29];
                outputD += input[21];
                outputD += input[13];
                outputD += input[5];
                outputD += input[60];
                outputD += input[52];
                outputD += input[44];
                outputD += input[36];
                outputD += input[28];
                outputD += input[20];
                outputD += input[12];
                outputD += input[4];
                outputD += input[27];
                outputD += input[19];
                outputD += input[11];
                outputD += input[3];

                return (outputC, outputD);
            }

        }
        private static string FeistelFunction(string inputRightSide, string roundKey)
        {
            var pBoxBefore = PBoxOfExntention(inputRightSide);
            var xored = "";
            for (int i = 0; i < 48; i++)
            {
                xored += XOR(pBoxBefore[i], roundKey[i]);
            }

            return DirectPBox(
                SBoxing(new string[]
                {
                    xored.Substring(0, 6), xored.Substring(6, 6),
                    xored.Substring(12, 6), xored.Substring(18, 6),
                    xored.Substring(24, 6), xored.Substring(30, 6),
                    xored.Substring(36, 6), xored.Substring(42, 6)
                }
                )
            );

            string PBoxOfExntention(string input)
            {
                var result = "";
                result += input[31];
                result += input[0];
                result += input[1];
                result += input[2];
                result += input[3];
                result += input[4];
                result += input[3];
                result += input[4];
                result += input[5];
                result += input[6];
                result += input[7];
                result += input[8];
                result += input[7];
                result += input[8];
                result += input[9];
                result += input[10];
                result += input[11];
                result += input[12];
                result += input[11];
                result += input[12];
                result += input[13];
                result += input[14];
                result += input[15];
                result += input[16];
                result += input[15];
                result += input[16];
                result += input[17];
                result += input[18];
                result += input[19];
                result += input[20];
                result += input[19];
                result += input[20];
                result += input[21];
                result += input[22];
                result += input[23];
                result += input[24];
                result += input[23];
                result += input[24];
                result += input[25];
                result += input[26];
                result += input[27];
                result += input[28];
                result += input[27];
                result += input[28];
                result += input[29];
                result += input[30];
                result += input[31];
                result += input[0];
                return result;
            }
            string SBoxing(string[] input)
            {
                var result = "";
                for (int i = 0; i < input.Length; i++)
                {
                    var binarSmall = DecimalToBinar(sBoxes[i]
                        [
                            BinarToDecimal(input[i][0].ToString() + input[i][input[i].Length - 1].ToString()),
                            BinarToDecimal(input[i].Substring(1, 4))
                        ]);
                    while(binarSmall.Length<4)
                    {
                        binarSmall = binarSmall.Insert(0, "0");
                    }
                    result += binarSmall;
                }
                return result;
            }
            string DirectPBox(string input)
            {
                var result = "";
                result += input[15];
                result += input[6];
                result += input[19];
                result += input[20];
                result += input[28];
                result += input[11];
                result += input[27];
                result += input[16];
                result += input[0];
                result += input[14];
                result += input[22];
                result += input[25];
                result += input[4];
                result += input[17];
                result += input[30];
                result += input[9];
                result += input[1];
                result += input[7];
                result += input[23];
                result += input[13];
                result += input[31];
                result += input[26];
                result += input[2];
                result += input[8];
                result += input[18];
                result += input[12];
                result += input[29];
                result += input[5];
                result += input[21];
                result += input[10];
                result += input[3];
                result += input[24];

                return result;
            }
        }
        private static string IPFirst(string inputBlock)
        {
            string result = "";
            result += inputBlock[57];
            result += inputBlock[49];
            result += inputBlock[41];
            result += inputBlock[33];
            result += inputBlock[25];
            result += inputBlock[17];
            result += inputBlock[9];
            result += inputBlock[1];
            result += inputBlock[59];
            result += inputBlock[51];
            result += inputBlock[43];
            result += inputBlock[35];
            result += inputBlock[27];
            result += inputBlock[19];
            result += inputBlock[11];
            result += inputBlock[3];
            result += inputBlock[61];
            result += inputBlock[53];
            result += inputBlock[45];
            result += inputBlock[37];
            result += inputBlock[29];
            result += inputBlock[21];
            result += inputBlock[13];
            result += inputBlock[5];
            result += inputBlock[63];
            result += inputBlock[55];
            result += inputBlock[47];
            result += inputBlock[39];
            result += inputBlock[31];
            result += inputBlock[23];
            result += inputBlock[15];
            result += inputBlock[7];
            result += inputBlock[56];
            result += inputBlock[48];
            result += inputBlock[40];
            result += inputBlock[32];
            result += inputBlock[24];
            result += inputBlock[16];
            result += inputBlock[8];
            result += inputBlock[0];
            result += inputBlock[58];
            result += inputBlock[50];
            result += inputBlock[42];
            result += inputBlock[34];
            result += inputBlock[26];
            result += inputBlock[18];
            result += inputBlock[10];
            result += inputBlock[2];
            result += inputBlock[60];
            result += inputBlock[52];
            result += inputBlock[44];
            result += inputBlock[36];
            result += inputBlock[28];
            result += inputBlock[20];
            result += inputBlock[12];
            result += inputBlock[4];
            result += inputBlock[62];
            result += inputBlock[54];
            result += inputBlock[46];
            result += inputBlock[38];
            result += inputBlock[30];
            result += inputBlock[22];
            result += inputBlock[14];
            result += inputBlock[6];
            return result;
        }
        private static string IPLast(string inputBlock)
        {
            var result = "";
            result += inputBlock[39];
            result += inputBlock[7];
            result += inputBlock[47];
            result += inputBlock[15];
            result += inputBlock[55];
            result += inputBlock[23];
            result += inputBlock[63];
            result += inputBlock[31];
            result += inputBlock[38];
            result += inputBlock[6];
            result += inputBlock[46];
            result += inputBlock[14];
            result += inputBlock[54];
            result += inputBlock[22];
            result += inputBlock[62];
            result += inputBlock[30];
            result += inputBlock[37];
            result += inputBlock[5];
            result += inputBlock[45];
            result += inputBlock[13];
            result += inputBlock[53];
            result += inputBlock[21];
            result += inputBlock[61];
            result += inputBlock[29];
            result += inputBlock[36];
            result += inputBlock[4];
            result += inputBlock[44];
            result += inputBlock[12];
            result += inputBlock[52];
            result += inputBlock[20];
            result += inputBlock[60];
            result += inputBlock[28];
            result += inputBlock[35];
            result += inputBlock[3];
            result += inputBlock[43];
            result += inputBlock[11];
            result += inputBlock[51];
            result += inputBlock[19];
            result += inputBlock[59];
            result += inputBlock[27];
            result += inputBlock[34];
            result += inputBlock[2];
            result += inputBlock[42];
            result += inputBlock[10];
            result += inputBlock[50];
            result += inputBlock[18];
            result += inputBlock[58];
            result += inputBlock[26];
            result += inputBlock[33];
            result += inputBlock[1];
            result += inputBlock[41];
            result += inputBlock[9];
            result += inputBlock[49];
            result += inputBlock[17];
            result += inputBlock[57];
            result += inputBlock[25];
            result += inputBlock[32];
            result += inputBlock[0];
            result += inputBlock[40];
            result += inputBlock[8];
            result += inputBlock[48];
            result += inputBlock[16];
            result += inputBlock[56];
            result += inputBlock[24];
            return result;
        }

        public static string XOR(char firstOperand, char secondOperand)
        {
            if (firstOperand == secondOperand)
            {
                return "0";
            }
            else
            {
                return "1";
            }
        }
        public static string XOR(string firstOperand, string secondOperand)
        {
            var result = "";
            for (int i = 0; i < firstOperand.Length; i++)
            {
                if (firstOperand[i] == secondOperand[i])
                {
                    result += "0";
                }
                else
                {
                    result += "1";
                }
            }
            return result;
        }
        public static string DecimalToBinar(int decimalNumber)
        {
            string result = "";
            while (decimalNumber > 0)
            {

                if (result.Length < 1)
                {
                    result += (decimalNumber % 2).ToString();
                }
                else
                {
                    result = result.Insert(0, (decimalNumber % 2).ToString());
                }
                decimalNumber /= 2;
            }
            return result;
        }
        public static int BinarToDecimal(string binarString)
        {
            int result = 0;
            for (int i = 0; i < binarString.Length; i++)
            {
                result += int.Parse(binarString[i].ToString()) * Convert.ToInt32(Math.Pow(2, binarString.Length - i - 1));
            }
            return result;
        }
        public static string BinarToHex(string binarString)
        {
            var result = "";
            var counter = 0;
            while (counter <binarString.Length)
            {
                var binarPiece = binarString.Substring(counter, 4);
                if (binarPiece == "0000")
                {
                    result += "0";
                }
                else if (binarPiece == "0001")
                {
                    result += "1";
                }
                else if (binarPiece == "0010")
                {
                    result += "2";
                }
                else if (binarPiece == "0011")
                {
                    result += "3";
                }
                else if (binarPiece == "0100")
                {
                    result += "4";
                }
                else if (binarPiece == "0101")
                {
                    result += "5";
                }
                else if (binarPiece == "0110")
                {
                    result += "6";
                }
                else if (binarPiece == "0111")
                {
                    result += "7";
                }
                else if (binarPiece == "1000")
                {
                    result += "8";
                }
                else if (binarPiece == "1001")
                {
                    result += "9";
                }
                else if (binarPiece == "1010")
                {
                    result += "A";
                }
                else if (binarPiece == "1011")
                {
                    result += "B";
                }
                else if (binarPiece == "1100")
                {
                    result += "C";
                }
                else if (binarPiece == "1101")
                {
                    result += "D";
                }
                else if (binarPiece == "1110")
                {
                    result += "E";
                }
                else if (binarPiece == "1111")
                {
                    result += "F";
                }
                counter += 4;
            }
            return result;
        }
    }
}
