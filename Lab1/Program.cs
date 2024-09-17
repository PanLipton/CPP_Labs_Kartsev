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
            string lab1Path = Path.Combine(Directory.GetCurrentDirectory(), "Lab1");  
            string inputFilePath = Path.Combine(lab1Path, "INPUT.txt");
            string outputFilePath = Path.Combine(lab1Path, "OUTPUT.TXT");

            string[] input;
            try
            {
                input = File.ReadAllText(inputFilePath).Split(); // Читаємо файл і ділимо на частини
            }
            catch (Exception)
            {
                throw new Exception("Не вдалося прочитати файл INPUT.txt");
            }

            if (input.Length != 2) // Має бути два числа
                throw new Exception("У файлі INPUT.txt має бути два числа!");

            if (!int.TryParse(input[0], out int N) || !int.TryParse(input[1], out int K))
                throw new Exception("Вхідні дані повинні бути цілими числами!");

            if (N < 1 || N > 1000 || K < 1 || K > 100)
                throw new Exception("Числа N і K повинні бути в діапазоні від 1 до 1000 для N і від 1 до 100 для K!");

            // Вычисляем количество всех строк от длины 1 до N
            BigInteger totalStrings = 0;
            BigInteger currentPower = 1;

            // Считаем количество строк для каждой длины от 1 до N
            for (int i = 1; i <= N; i++)
            {
                currentPower *= K; 
                totalStrings += currentPower;
            }

            // Вычитаем чрезмерные строки
            BigInteger nonRedundantStrings = totalStrings - K;

            // Максимальное количество нечрезмерных наборов всегда 1
            int numberOfSets = 1;

            // Записываем результат в файл
            File.WriteAllText(outputFilePath, $"{nonRedundantStrings}\n{numberOfSets}");
            Console.WriteLine($"Значення записані в OUTPUT.TXT: {nonRedundantStrings}, {numberOfSets}");
        }
    }
}
