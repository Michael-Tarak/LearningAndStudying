using System;
using System.IO;
using System.Numerics;

namespace RSAEncryption
{
    class Program
    {
        static void Main(string[] args)
        {
            //for (int i = 2; i < 10000; i++)
            //{
            //    if (RSA.IsPrime(i))
            //    {
            //        Console.WriteLine(i); //Цикл выводит простые числа от пределах 2 ло 10000
            //    }
            //}
            var input = "";
            while (input != "exit")
            {
                Console.WriteLine("Введите команду:\n1 - создание ключей\n2 - шифрование\nexit - выход");
                input = Console.ReadLine().Trim().ToLower();
                switch (input)
                {
                    case "1":
                        Console.Write("Введите первое простое число: ");
                        var p = long.Parse(Console.ReadLine());
                        Console.Write("Введите второе простое число: ");
                        var q = long.Parse(Console.ReadLine());
                        Console.Write("Введите степень открытого ключа: ");
                        var e = long.Parse(Console.ReadLine());
                        var (d,n) = RSA.CreateKeys(p, q, e);
                        Console.WriteLine($"Степень закрытого ключа d - {d}\nМодуль n - {n}");
                        break;
                    case "2":
                        Console.Write("Введите число для шифрования/дешифрования: ");
                        var messsage = BigInteger.Parse(Console.ReadLine());
                        Console.Write("Введите степень ключа: ");
                        var power = BigInteger.Parse(Console.ReadLine());
                        Console.Write("Введите модуль ключа: ");
                        var module = BigInteger.Parse(Console.ReadLine());
                        Console.WriteLine($"Вывод: {RSA.Encrypt(messsage,power,module)}");

                        break;
                    case "exit":
                        break;
                    default:
                        Console.WriteLine("Неверный ввод!");
                        break;
                }
            }
        }
    }
}
