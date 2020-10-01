using System;
namespace Encryption2
{
    static class Substitution
    {
        private static readonly string[] alphabetDefault = new string[]
        { 
            @"abcdefghijklmnopqrstuvwxyz 0123456789!?@#$%^&*()_+-=[]{}<>,.:;|/",
            @"qw@-ert+#yuio$p}a=|/{sdf]. ghj%klz?[xcvbnm7^:()5*,8<941_>;62&!30"
        };

        public static string[] AlphabetDefault => alphabetDefault;

        public static string Encrypt(string text, string substitutionIn, string substitutionOut)
        {
            try
            {
                if (substitutionIn.Length != substitutionOut.Length)
                {
                    throw new ArgumentException();
                }

                var result = "";
                for (int i = 0; i < text.Length; i++)
                {
                    for (int j = 0; j < substitutionIn.Length; j++)
                    {
                        if (text[i] == substitutionIn[j])
                        {
                            result += substitutionOut[j];
                            break;
                        }
                    }
                }
                return result;

            }
            catch (ArgumentException)
            {
                return "Invalid Arguments!";
            }
        }
    }
}
