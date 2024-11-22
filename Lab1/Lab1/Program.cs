using System.Numerics;

namespace Lab1
{
    public static class Program
    {
        static void Main()
        {
            try
            {
                Console.WriteLine("Lab-1: String Computer");
                Console.WriteLine();
                ExecuteProgram();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
        }

        public static void ExecuteProgram()
        {
            var filesHandler = new FilesHandler();
            List<string> answers = ProcessInputFile(filesHandler.InputFilePath, filesHandler);
            File.WriteAllLines(filesHandler.OutputFilePath, answers);
        }

        public static List<string> ProcessInputFile(string inputFilePath, FilesHandler filesHandler)
        {
            List<string> answers = new List<string>();
            string[] lines = File.ReadAllLines(inputFilePath);

            foreach (string line in lines)
            {
                try
                {
                    (int N, int K) = filesHandler.ReadInputLine(line);

                    if (!filesHandler.IsValuesValid(N, K))
                    {
                        Console.WriteLine($"Invalid values: N={N}, K={K}");
                        continue;
                    }

                    Console.WriteLine($"Processing: N={N}, K={K}");

                    var (maxSetSize, maxSetCount) = CalculateStringComputer(N, K);
                    Console.WriteLine($"Result: size={maxSetSize}, count={maxSetCount}");

                    answers.Add(maxSetSize.ToString());
                    answers.Add(maxSetCount.ToString());
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error processing line '{line}': {e.Message}");
                }
            }

            return answers;
        }

        public static (BigInteger, BigInteger) CalculateStringComputer(int N, int K)
        {
            BigInteger maxSetSize = 0;
            for (int m = 1; m <= N; m++)
            {
                maxSetSize += K * m;
            }

            BigInteger maxSetCount = 1;

            return (maxSetSize, maxSetCount);
        }
    }
}