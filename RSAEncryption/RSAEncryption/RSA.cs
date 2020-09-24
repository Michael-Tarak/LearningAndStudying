using System;
using System.Numerics;

namespace RSAEncryption
{
    class RSA
    {
        public static BigInteger Encrypt(BigInteger message, BigInteger power, BigInteger module)
        {
            return BigInteger.ModPow(message,power,module);
        }

        public static (BigInteger, BigInteger) CreateKeys(long pValue, long qValue, long eValue)
        {
            try
            {
                if (!IsPrime(pValue) || !IsPrime(qValue))
                {
                    throw new ArgumentException();
                }
                var moduleN = BigInteger.Multiply(pValue,qValue);
                var eulerFunction = BigInteger.Multiply(pValue - 1, qValue - 1);
                if (!IsPrime(eValue) || eValue >= eulerFunction || eulerFunction % eValue == 0)
                {
                    throw new ArgumentException();
                }
                var dSecret = new BigInteger();
                dSecret = 100;
                while (BigInteger.Remainder(BigInteger.Multiply(dSecret, eValue), eulerFunction) !=1)
                {
                    dSecret++;
                }
                return (dSecret, moduleN);
            }
            catch (Exception)
            {
                return (0, 0);
            }
        }

        public static bool IsPrime (long value)
        {
            if (value < 2)
            {
                return false;
            }
            for (int i = 2; i <= Math.Sqrt(value); i++)
            {
                if (value % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
