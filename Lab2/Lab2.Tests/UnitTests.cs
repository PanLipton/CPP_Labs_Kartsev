using Lab2;
using Xunit;

namespace Lab2.Tests
{
    public class UnitTests
    {
        // Тест базового випадку: параметр = 1
        [Fact]
        public void TestDoMoves_BaseCase()
        {
            var directions = new Dictionary<char, int> { { 'N', 0 }, { 'S', 1 }, { 'W', 2 }, { 'E', 3 }, { 'U', 4 }, { 'D', 5 } };
            var rules = new string[] { "N", "NUSDDUSE", "WED", "", "U", "" };

            long result = Program.DoMoves('N', 1, rules, directions);

            Assert.Equal(1, result);
        }

        // Тест рекурсивного випадку
        [Fact]
        public void TestDoMoves_RecursiveCase()
        {
            var directions = new Dictionary<char, int> { { 'N', 0 }, { 'S', 1 }, { 'W', 2 }, { 'E', 3 }, { 'U', 4 }, { 'D', 5 } };
            var rules = new string[] { "N", "NUSDDUSE", "WED", "", "U", "" };

            long result = Program.DoMoves('S', 3, rules, directions);

            Assert.Equal(28, result); 
        }

        // Тест з порожнім правилом
        [Fact]
        public void TestDoMoves_WithEmptyRule()
        {
            var directions = new Dictionary<char, int> { { 'N', 0 }, { 'S', 1 }, { 'W', 2 }, { 'E', 3 }, { 'U', 4 }, { 'D', 5 } };
            var rules = new string[] { "", "", "", "", "", "" };

            long result = Program.DoMoves('N', 5, rules, directions);

            // Assert
            Assert.Equal(1, result); // Без правил завжди повертає 1
        }

        // Тест зчитування правил та команди з файлу
        [Fact]
        public void TestReadInputFile_ParsesCorrectly()
        {
            var filesHandler = new FilesHandler();
            string inputPath = filesHandler.InputFilePath;

            // Забезпечення існування директорії для файлу
            Directory.CreateDirectory(Path.GetDirectoryName(inputPath)!);

            File.WriteAllLines(inputPath, new string[]
            {
                "N", "NUSDDUSE", "WED", "", "U", "",
                "S 3"
            });

            var (rules, command) = filesHandler.ReadInputFile();

            Assert.Equal("N", rules[0]);
            Assert.Equal("NUSDDUSE", rules[1]);
            Assert.Equal('S', command.Direction);
            Assert.Equal(3, command.Parameter);
        }

        // Тест запису результату у файл
        [Fact]
        public void TestWriteOutputFile_WritesCorrectResult()
        {
            // Arrange
            var filesHandler = new FilesHandler();
            string outputPath = filesHandler.OutputFilePath;

            // Забезпечення існування директорії для файлу
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath)!);

            long result = 12345;

            // Act
            filesHandler.WriteOutputFile(result);

            // Assert
            string writtenResult = File.ReadAllText(outputPath);
            Assert.Equal("12345", writtenResult);
        }
    }
}
