public class FilesHandler
{
    private readonly string _inputFilePath;
    private readonly string _outputFilePath;

    public FilesHandler()
    {
        string labFolder = "Lab1";
        string baseDirectory = Directory.GetCurrentDirectory();
        string filesFolder = "files";

        _inputFilePath = Path.Combine(baseDirectory, labFolder, filesFolder, "INPUT.txt");
        _outputFilePath = Path.Combine(baseDirectory, labFolder, filesFolder, "OUTPUT.txt");
    }

    public string InputFilePath => _inputFilePath;
    public string OutputFilePath => _outputFilePath;

    public (int N, int K) ReadInputLine(string line)
    {
        var parts = line.Split(' ');
        if (parts.Length != 2 || !int.TryParse(parts[0], out int n) || !int.TryParse(parts[1], out int k))
        {
            throw new InvalidOperationException("Invalid input format. Expected: N K");
        }
        return (n, k);
    }

    public bool IsValuesValid(int N, int K)
    {
        return N >= 1 && N <= 1000 && K >= 1 && K <= 100;
    }

    public void WriteOutputFile(long result)
    {
        File.WriteAllText(_outputFilePath, result.ToString());
    }
}