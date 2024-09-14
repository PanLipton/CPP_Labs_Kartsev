using System;
using System.IO;
using System.Numerics;
using Xunit;

namespace Lab1.Tests
{
    public class ProgramTests : IDisposable
    {
        [Fact]
        public void SolveStringComputer_ValidInput_CorrectOutput()
        {
            File.WriteAllText("INPUT.txt", "2 3");
            Program.Main(new string[] { });
            string[] output = File.ReadAllLines("OUTPUT.TXT");
            Assert.Equal(2, output.Length);
            Assert.Equal("9", output[0]);
            Assert.Equal("1", output[1]);
            Console.WriteLine("Тест з вхідними даними 2 3 пройдено успішно.");
        }

        [Fact]
        public void SolveStringComputer_MaximumInput_CorrectOutput()
        {
            File.WriteAllText("INPUT.txt", "100 100");
            Program.Main(new string[] { });
            string[] output = File.ReadAllLines("OUTPUT.TXT");
            Assert.Equal(2, output.Length);
            Assert.True(BigInteger.TryParse(output[0], out _), "Результат має бути числом");
            Assert.Equal("1", output[1]);
            Console.WriteLine("Тест з максимальними вхідними даними 100 100 пройдено успішно.");
        }

        [Fact]
        public void SolveStringComputer_MinimumInput_CorrectOutput()
        {
            File.WriteAllText("INPUT.txt", "1 1");
            Program.Main(new string[] { });
            string[] output = File.ReadAllLines("OUTPUT.TXT");
            Assert.Equal(2, output.Length);
            Assert.Equal("1", output[0]);
            Assert.Equal("1", output[1]);
            Console.WriteLine("Тест з мінімальними вхідними даними 1 1 пройдено успішно.");
        }

        [Fact]
        public void SolveStringComputer_InvalidInput_ThrowsException()
        {
            File.WriteAllText("INPUT.txt", "0 101");
            var exception = Assert.Throws<Exception>(() => Program.Main(new string[] { }));
            Assert.Contains("Числа N і K повинні бути в діапазоні від 1 до 100 включно!", exception.Message);
            Console.WriteLine("Тест з некоректними вхідними даними 0 101 пройдено успішно (виключення викинуто).");
        }

        [Fact]
        public void SolveStringComputer_MissingInput_ThrowsException()
        {
            File.WriteAllText("INPUT.txt", "5");
            var exception = Assert.Throws<Exception>(() => Program.Main(new string[] { }));
            Assert.Contains("У файлі INPUT.txt має бути два числа!", exception.Message);
            Console.WriteLine("Тест з неповними вхідними даними пройдено успішно (виключення викинуто).");
        }

        public void Dispose()
        {
            if (File.Exists("INPUT.txt"))
                File.Delete("INPUT.txt");
            if (File.Exists("OUTPUT.TXT"))
                File.Delete("OUTPUT.TXT");
        }
    }
}