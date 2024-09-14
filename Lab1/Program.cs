using System;
using System.IO;
using System.Numerics;

namespace Lab1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            SolveStringComputer();
        }

        public static void SolveStringComputer()
        {
            string[] input;
            try
            {
                input = File.ReadAllText("INPUT.txt").Split();
            }
            catch (Exception)
            {
                throw new Exception("Не вдалося прочитати файл INPUT.txt");
            }

            if (input.Length != 2)
                throw new Exception("У файлі INPUT.txt має бути два числа!");

            if (!int.TryParse(input[0], out int N) || !int.TryParse(input[1], out int K))
                throw new Exception("Вхідні дані повинні бути цілими числами!");

            if (N < 1 || N > 100 || K < 1 || K > 100)
                throw new Exception("Числа N і K повинні бути в діапазоні від 1 до 100 включно!");

            BigInteger maxStrings = BigInteger.Pow(K, N);

            Console.WriteLine($"Результат з вхідними значеннями INPUT: {maxStrings}");
            File.WriteAllText("OUTPUT.TXT", $"{maxStrings}\n1");
        }
    }
}