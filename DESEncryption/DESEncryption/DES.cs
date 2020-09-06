using System;

namespace DESEncryption
{
    static class DES
    {
        public static string Round(string textBinary, bool isDecryption = false)
        {
            string leftPart;
            string rightPart;
            if (isDecryption)
            {
                leftPart = textBinary.Substring(32);
                rightPart=  textBinary.Substring(0, 32);
            }
            else
            {
                leftPart = textBinary.Substring(0, 32);
                rightPart = textBinary.Substring(32);
            }
        }
        public static string IPFirst(string inputBlock)
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
        public static string IPLast (string inputBlock)
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
        public static string KeyGenerator (int roundNumber, string inputKey)
        {
            string [] keyCheckExtd = {"","","","","","","",""}; //8
            //string[] keyCheckExtd = { inputKey.Substring(0, 7),
            //    inputKey.Substring(7, 7), inputKey.Substring(14, 7),
            //    inputKey.Substring(21, 7), inputKey.Substring(28, 7),
            //    inputKey.Substring(35, 7), inputKey.Substring(42, 7),inputKey.Substring(49, 7) };

            for (int i = 0; i < keyCheckExtd.Length; i++)
            {
                
            }
            return result;
        }
        public static string XOR (string firstOperand, string secondOperand)
        {
            if(firstOperand == secondOperand)
            {
                return "0";
            }
            else
            {
                return "1";
            }
        }
    }
}
