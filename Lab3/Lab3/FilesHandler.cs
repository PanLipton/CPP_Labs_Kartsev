using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Lab3
{
    public class FilesHandler
    {
        private readonly string _inputFilePath;
        private readonly string _outputFilePath;

        public FilesHandler()
        {
            string labFolder = "Lab3";
            string baseDirectory = Directory.GetCurrentDirectory();
            string filesFolder = "files";

            // Формуємо шляхи до файлів
            _inputFilePath = Path.Combine(baseDirectory, labFolder, filesFolder, "INPUT.TXT");
            _outputFilePath = Path.Combine(baseDirectory, labFolder, filesFolder, "OUTPUT.TXT");
        }

        public string InputFilePath => _inputFilePath;

        public string OutputFilePath => _outputFilePath;

        // Метод для обробки вхідного файлу
        public (int, List<(int, int, int)>) ProcessInputFile(string inputFilePath)
        {
            var lines = File.ReadAllLines(inputFilePath);
            if (lines.Length == 0)
            {
                Console.WriteLine("Error: File is empty."); // Англійська для виводу
                throw new Exception("File is empty.");
            }

            var header = lines[0].Split();
            if (header.Length != 2 || !int.TryParse(header[0], out int vertices) || !int.TryParse(header[1], out int edgesCount))
            {
                Console.WriteLine($"Error: Invalid format in first line: {lines[0]}");
                throw new FormatException($"Invalid format in first line: {lines[0]}");
            }

            var edges = new List<(int, int, int)>();

            for (int i = 1; i < lines.Length; i++)
            {
                var parts = lines[i].Split();
                if (parts.Length != 3)
                {
                    Console.WriteLine($"Warning: Line {i + 1} has incorrect format: {lines[i]}");
                    continue; // Пропускаємо неправильні рядки
                }

                if (!int.TryParse(parts[0], out int from) ||
                    !int.TryParse(parts[1], out int to) ||
                    !int.TryParse(parts[2], out int weight))
                {
                    Console.WriteLine($"Warning: Line {i + 1} contains invalid numbers: {lines[i]}");
                    continue; // Пропускаємо рядки з помилками
                }

                edges.Add((from - 1, to - 1, weight)); // Зміщення на 1 для індексації з 0
            }

            if (edges.Count == 0)
            {
                Console.WriteLine("Error: No valid edges found in the input file.");
                throw new Exception("No valid edges found in the input file.");
            }

            return (vertices, edges);
        }

        // Метод для запису вихідного файлу
        public void WriteOutputFile(string outputFilePath, List<int> results)
        {
            var lines = results.Select(r => r == int.MaxValue ? "30000" : r.ToString()).ToArray();
            File.WriteAllLines(outputFilePath, lines);
            Console.WriteLine("Results written to file: " + outputFilePath); // Англійська для виводу
        }
    }
}
