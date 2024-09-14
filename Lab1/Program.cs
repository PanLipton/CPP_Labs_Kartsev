using System;
using System.IO;

namespace Lab1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                SolveStringComputer();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка: {ex.Message}");
            }
        }

        static void SolveStringComputer()
        {
            string[] input = File.ReadAllText("Lab1/INPUT.txt").Split();
            if (input.Length != 2)
                throw new Exception("У файлі INPUT.txt має бути два числа!");

            int N = int.Parse(input[0]);
            int K = int.Parse(input[1]);

            // Перевірка коректності вхідних даних
            if (N < 1 || N > 100 || K < 1 || K > 100)
                throw new Exception("Числа N і K повинні бути в діапазоні від 1 до 100 включно!");

            // Обчислення кількості рядків у максимальному наборі
            long maxStrings = (long)Math.Pow(K, N);

            // Кількість таких максимальних наборів завжди дорівнює 1
            Console.WriteLine("Результат з вхідними значеннями INPUT: "+maxStrings);
            File.WriteAllText("Lab1/OUTPUT.TXT", $"{maxStrings}\n1");
        }
    }
}
