namespace CaesarCypher
{
    static class CaesarCode
    {
        private static readonly string alphabet = @"abcdefghijklmnopqrstuvwxyz1234567890 ,.?!:;'&%$#@^*_-+=|\/<>(){}[]";

        public static string Alphabet => alphabet;

        public static string Encrypt(string text, int step)
        {
            text = text.ToLower();
            var result = "";
            for (int i = 0; i < text.Length; i++)
            {
                for (int j = 0; j < Alphabet.Length; j++)
                {
                    if (text[i] == Alphabet[j])
                    {
                        var move = j + step;
                        while (move < 0)
                        {
                            move += Alphabet.Length;
                        }
                        result += Alphabet[move % Alphabet.Length];
                        break;
                    }
                }
            }
            return result;
        }

        public static  string[] Crack(string text)
        {
            string[] result = new string[Alphabet.Length];
            for (int step = 0; step < Alphabet.Length; step++)
            {
                for (int i = 0; i < text.Length; i++)
                {
                    for (int j = 0; j < Alphabet.Length; j++)
                    {
                        if (text[i] == Alphabet[j])
                        {
                            result[step] += Alphabet[(j + step) % Alphabet.Length];
                            break;
                        }
                    }
                }
            }
            return result;
        }
    }
}
