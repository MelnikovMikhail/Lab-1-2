using System;

namespace LR2.Core
{
    public static class Program
    {
        public static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("=== Демонстрация класса Lcm (НОК) ===");
            PrintLcm(1, 1);
            PrintLcm(3, 5);
            PrintLcm(4, 2);
            PrintLcm(7, 7);
            PrintLcm(12, 18);
            PrintLcm(123456, 789012);

            Console.WriteLine();
            Console.WriteLine("=== Демонстрация класса Palindrome ===");
            PrintPalindrome("level");
            PrintPalindrome("hello");
            PrintPalindrome("");
            PrintPalindrome("RaceCar");
            PrintPalindrome("А роза упала на лапу Азора");
            PrintPalindrome("A man, a plan, a canal: Panama");
            PrintPalindrome("12321");
            PrintPalindrome("12345");

            Console.WriteLine();
            Console.WriteLine("=== Проверка обработки ошибок ===");
            TryLcm(0, 5);
            TryLcm(-3, 5);
            TryLcm(5, 0);
            TryPalindrome(null);

            Console.WriteLine();
            Console.WriteLine("Enter для выхода.");
            Console.ReadLine();
        }

        static void PrintLcm(int a, int b)
        {
            int result = new Lcm(a, b).Compute();
            Console.WriteLine($"НОК({a}, {b}) = {result}");
        }

        static void PrintPalindrome(string s)
        {
            bool isPal = new Palindrome(s).IsPalindrome();
            string display = s == "" ? "<пустая строка>" : $"\"{s}\"";
            Console.WriteLine($"{display} → палиндром? {isPal}");
        }

        static void TryLcm(int a, int b)
        {
            try
            {
                new Lcm(a, b);
                Console.WriteLine($"Lcm({a}, {b}) — ошибки не было");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Lcm({a}, {b}) — исключение: {ex.Message}");
            }
        }

        static void TryPalindrome(string s)
        {
            try
            {
                new Palindrome(s);
                Console.WriteLine("Palindrome(null) — ошибки нет");
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"Palindrome(null) — исключение: {ex.Message}");
            }
        }
    }
}
