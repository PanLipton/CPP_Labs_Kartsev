namespace Lab2;

public static class Program
{
    static void Main()
    {
        try
        {
            ExecuteProgram();
        }
        catch (Exception e)
        {
            Console.WriteLine($"Помилка: {e.Message}");
        }
    }

    public static void ExecuteProgram()
    {
        var filesHandler = new FilesHandler();

        
        (string[] rules, (char direction, int parameter) command) = filesHandler.ReadInputFile(); // Читаєм файл з командами

        // Словник для відповідності напрямків індексам
        Dictionary<char, int> directions = new Dictionary<char, int>
        {
            { 'N', 0 }, { 'S', 1 }, { 'W', 2 }, { 'E', 3 }, { 'U', 4 }, { 'D', 5 }
        };

        long result = DoMoves(command.direction, command.parameter, rules, directions);

        filesHandler.WriteOutputFile(result);
    }

    public static long DoMoves(char dir, int param, string[] rules, Dictionary<char, int> directions)
    {
        // Базовий випадок: якщо параметр = 1, повертаємо 1 переміщення
        if (param == 1)
        {
            Console.WriteLine($"Base case: {dir} with param 1 -> 1 move");            
            return 1;
        }

        long totalMoves = 1; // Рух у вказаному напрямку
        string rule = rules[directions[dir]];

        Console.WriteLine($"Processing {dir}({param}) with rule: {rule}");

        foreach (char subDir in rule)
        {
            long subMoves = DoMoves(subDir, param - 1, rules, directions);
            Console.WriteLine($"Sub move: {subDir}({param - 1}: {subMoves} moves");
            totalMoves += subMoves;
        }

        Console.WriteLine($"Total moves {dir}({param}): {totalMoves}");
        return totalMoves;
    }
}
