using Moq;
using System.Numerics;

namespace Lab1.Tests
{
    public class UnitTests
    {
        [Theory]
        [InlineData("3 2", 3, 2)]
        [InlineData("1 1", 1, 1)]
        [InlineData("1000 100", 1000, 100)]
        public void ReadInput(string input, int expectedN, int expectedK)
        {
            var filesHandler = new FilesHandler();
            var result = filesHandler.ReadInputLine(input);

            Assert.Equal((expectedN, expectedK), result);
        }

        [Theory]
        [InlineData(0, 1, false)]  // N має бути більше 1
        [InlineData(1001, 50, false)]  // N не більше 1000
        [InlineData(500, 0, false)]  // K має бути більше 1
        [InlineData(500, 101, false)]  // K не більше 100
        [InlineData(1, 1, true)]  // Мінімальні валідні значення
        [InlineData(1000, 100, true)]  // Максимальні валідні значення
        [InlineData(500, 50, true)]  // Середні валідні значення
        public void IsValuesValid(int N, int K, bool expectedResult)
        {
            var filesHandler = new FilesHandler();
            var result = filesHandler.IsValuesValid(N, K);

            Assert.Equal(expectedResult, result);
        }
    
        [Theory]
        [InlineData(1, 1, 1, 1)]  
        [InlineData(3, 2, 12, 1)]  
        public void Calculate(int N, int K, long expectedSize, long expectedCount)
        {
            var (size, count) = Program.CalculateStringComputer(N, K);
            Assert.Equal((BigInteger)expectedSize, size);
            Assert.Equal((BigInteger)expectedCount, count);
        }

        [Fact]
        public void ProcessInputFile_ValidInput_ReturnsCorrectResults()
        {
            string inputpath = "testInput.txt";
            var testLines = new List<string>
            {
                "3 2",
                "1 1"
            };
            File.WriteAllLines(inputpath, testLines);

            var filesHandlerMock = new Mock<FilesHandler>();
            filesHandlerMock.Setup(fh => fh.ReadInputLine(It.IsAny<string>()))
                .Returns<string>(line => 
                {
                    var parts = line.Split(' ');
                    return (int.Parse(parts[0]), int.Parse(parts[1]));
                });

            filesHandlerMock.Setup(fh => fh.IsValuesValid(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(true);

            var result = Program.ProcessInputFile(inputpath, filesHandlerMock.Object);

            Assert.Equal(4, result.Count); // Має бути 4 результати (2 пари значень)
            Assert.Equal("12", result[0]); // Розмір для першого випадку
            Assert.Equal("1", result[1]); // Кількість для першого випадку
            Assert.Equal("1", result[2]); // Розмір для другого випадку
            Assert.Equal("1", result[3]); // Кількість для другого випадку

            File.Delete(inputpath);
        }

        [Fact]
        public void FuncInputFile()
        {
            string inputpath = "testInput.txt";
            var testLines = new List<string>
            {
                "0 0",
                "-1 101"
            };
            File.WriteAllLines(inputpath, testLines);

            var filesHandlerMock = new Mock<FilesHandler>();
            filesHandlerMock.Setup(fh => fh.ReadInputLine(It.IsAny<string>()))
                .Returns<string>(line =>
                {
                    var parts = line.Split(' ');
                    return (int.Parse(parts[0]), int.Parse(parts[1]));
                });

            filesHandlerMock.Setup(fh => fh.IsValuesValid(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(false);

            var result = Program.ProcessInputFile(inputpath, filesHandlerMock.Object);

            Assert.Empty(result);

            File.Delete(inputpath);
        }
    }
}
