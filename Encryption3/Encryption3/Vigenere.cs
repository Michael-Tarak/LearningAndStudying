namespace Encryption3
{
    static class Vigenere
    {
        private static readonly string alphabet = "abcdefghijklmnopqrstuvwxyz";

        public static string Alphabet => alphabet;
        public static string Encrypt(string text, string key, string alphabet, bool isDecryption = false)
        {
            var result = "";

            var step = new int[key.Length];
            for (int i = 0; i < step.Length; i++)
            {
                for (int j = 0; j < alphabet.Length; j++)
                {
                    if (key[i] == alphabet[j])
                    {
                        if (isDecryption)
                        {
                            step[i] = -j;
                        }
                        else
                        {
                            step[i] = j;
                        }
                        
                        break;
                    }
                }
            }

            for (int i = 0; i < text.Length; i++)
            {
                for (int j = 0; j < alphabet.Length; j++)
                {
                    if (text[i] == alphabet[j])
                    {
                        var move = (j + step[i % key.Length]);
                        if (move < 0)
                        {
                            move += alphabet.Length;
                        }
                        result += alphabet[move % alphabet.Length];
                    }
                }
            }

            return result;
        }
    }
}
