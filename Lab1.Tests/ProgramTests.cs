using System;
using System.IO;
using System.Text;
using Xunit;
using Lab1;

namespace Lab1.Tests
{
    public class ProgramTests : IDisposable
    {
        private readonly string _originalDirectory;
        private readonly string _testDirectory;

        static ProgramTests()
        {
            Console.OutputEncoding = Encoding.UTF8;
        }

        public ProgramTests()
        {
            _originalDirectory = Directory.GetCurrentDirectory();
            _testDirectory = Path.Combine(_originalDirectory, "Lab1");
            Directory.CreateDirectory(_testDirectory);
            Console.WriteLine($"Тестова директорія створена: {_testDirectory}");
        }

        public void Dispose()
        {
            if (Directory.Exists(_testDirectory))
            {
                Directory.Delete(_testDirectory, true);
                Console.WriteLine($"Тестова директорія видалена: {_testDirectory}");
            }
        }

        [Fact]
        public void Test1_CorrectInput()
        {
            Console.WriteLine("====== Початок тесту: Test1_CorrectInput ======");
            
            File.WriteAllText(Path.Combine(_testDirectory, "INPUT.txt"), "3 2");
            Console.WriteLine("Файл INPUT.txt створено зі значенням: 3 2");

            Program.SolveStringComputer();
            Console.WriteLine("Метод SolveStringComputer виконано");

            string outputPath = Path.Combine(_testDirectory, "OUTPUT.TXT");
            Assert.True(File.Exists(outputPath), "Файл OUTPUT.TXT не був створений");
            string[] output = File.ReadAllLines(outputPath);
            Console.WriteLine($"Вміст OUTPUT.TXT: {string.Join(", ", output)}");
            
            Assert.Equal(2, output.Length);
            Assert.Equal("12", output[0]);
            Assert.Equal("1", output[1]);
            
            Console.WriteLine("====== Кінець тесту: Test1_CorrectInput ======");
        }

        [Fact]
        public void Test2_LargeNumbers()
        {
            Console.WriteLine("====== Початок тесту: Test2_LargeNumbers ======");
            
            File.WriteAllText(Path.Combine(_testDirectory, "INPUT.txt"), "1000 100");
            Console.WriteLine("Файл INPUT.txt створено зі значенням: 1000 100");

            Program.SolveStringComputer();
            Console.WriteLine("Метод SolveStringComputer виконано");

            string outputPath = Path.Combine(_testDirectory, "OUTPUT.TXT");
            Assert.True(File.Exists(outputPath), "Файл OUTPUT.TXT не був створений");
            string[] output = File.ReadAllLines(outputPath);
            Console.WriteLine($"Довжина результату: {output[0].Length}");
            
            Assert.Equal(2, output.Length);
            Assert.True(output[0].Length > 100, "Результат не є достатньо великим числом");
            Assert.Equal("1", output[1]);
            
            Console.WriteLine("====== Кінець тесту: Test2_LargeNumbers ======");
        }

        [Fact]
        public void Test3_InvalidInput()
        {
            Console.WriteLine("====== Початок тесту: Test3_InvalidInput ======");
            
            File.WriteAllText(Path.Combine(_testDirectory, "INPUT.txt"), "abc def");
            Console.WriteLine("Файл INPUT.txt створено зі значенням: abc def");

            var exception = Assert.Throws<Exception>(() => Program.SolveStringComputer());
            Console.WriteLine($"Отримано виняток: {exception.Message}");
            
            Assert.Equal("Вхідні дані повинні бути цілими числами!", exception.Message);
            
            Console.WriteLine("====== Кінець тесту: Test3_InvalidInput ======");
        }

        [Fact]
        public void Test4_OutOfRangeInput()
        {
            Console.WriteLine("====== Початок тесту: Test4_OutOfRangeInput ======");
            
            File.WriteAllText(Path.Combine(_testDirectory, "INPUT.txt"), "0 101");
            Console.WriteLine("Файл INPUT.txt створено зі значенням: 0 101");

            var exception = Assert.Throws<Exception>(() => Program.SolveStringComputer());
            Console.WriteLine($"Отримано виняток: {exception.Message}");
            
            Assert.Equal("Числа N і K повинні бути в діапазоні від 1 до 1000 для N і від 1 до 100 для K!", exception.Message);
            
            Console.WriteLine("====== Кінець тесту: Test4_OutOfRangeInput ======");
        }

        [Fact]
        public void Test5_MissingInputFile()
        {
            Console.WriteLine("====== Початок тесту: Test5_MissingInputFile ======");
            
            string inputPath = Path.Combine(_testDirectory, "INPUT.txt");
            if (File.Exists(inputPath))
            {
                File.Delete(inputPath);
                Console.WriteLine("Існуючий файл INPUT.txt видалено");
            }

            var exception = Assert.Throws<Exception>(() => Program.SolveStringComputer());
            Console.WriteLine($"Отримано виняток: {exception.Message}");
            
            Assert.Equal("Не вдалося прочитати файл INPUT.txt", exception.Message);
            
            Console.WriteLine("====== Кінець тесту: Test5_MissingInputFile ======");
        }
    }
}