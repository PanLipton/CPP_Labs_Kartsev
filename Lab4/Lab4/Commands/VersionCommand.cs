namespace Lab4.Commands
{
    public class VersionCommand : ICommand
    {
        public void Execute()
        {
            Console.WriteLine("Author: Ilya Kartsev");
            Console.WriteLine("Version: 1.0.0");
        }
    }
}