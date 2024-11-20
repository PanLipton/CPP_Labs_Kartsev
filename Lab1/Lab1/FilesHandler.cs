public class FilesHandler
{
    private readonly string _inputFilePath;
    private readonly string _outputFilePath;

    public FilesHandler()
    {
        string labFolder = "Lab2";
        string baseDirectory = AppContext.BaseDirectory;
        string filesFolder = "files";

        _inputFilePath = Path.Combine(baseDirectory, labFolder, filesFolder, "INPUT.TXT");
        _outputFilePath = Path.Combine(baseDirectory, labFolder, filesFolder, "OUTPUT.TXT");
    }

    public string InputFilePath
    {
        get { return _inputFilePath; }
    }

    public string OutputFilePath
    {
        get { return _outputFilePath; }
    }

    // Метод для читання правил і команди з файлу
    public (string[] Rules, (char Direction, int Parameter) Command) ReadInputFile()
    {
        string[] lines = File.ReadAllLines(_inputFilePath);
        if (lines.Length < 7)
        {
            throw new InvalidOperationException("Вхідний файл повинен містити 6 правил і 1 команду.");
        }

        string[] rules = lines.Take(6).ToArray();
        string[] commandParts = lines[6].Split(' ');

        if (commandParts.Length != 2 || !int.TryParse(commandParts[1], out int parameter))
        {
            throw new InvalidOperationException("Команда повинна мати формат: <напрямок> <параметр>");
        }

        return (rules, (commandParts[0][0], parameter));
    }

    // Метод для запису результату у файл
    public void WriteOutputFile(long result)
    {
        File.WriteAllText(_outputFilePath, result.ToString());
    }
}
