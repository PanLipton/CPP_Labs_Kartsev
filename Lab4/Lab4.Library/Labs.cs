using System;
using System.IO;

namespace Lab4.Library
{
    public class Labs
    {
        private readonly string _baseDirectory;
        private readonly string _rootDirectory;

        public Labs()
        {
            _baseDirectory = Directory.GetCurrentDirectory();
            
            // шукаєм корінь проекту (там де білд.прож лежить)
            _rootDirectory = FindProjectRoot(_baseDirectory);
            if (_rootDirectory == null)
            {
                throw new DirectoryNotFoundException("not find file with bild");
            }
            
            // дебаг, щоб бачити що воно хоч шось знайшло
            Console.WriteLine($"Base directory: {_baseDirectory}");
            Console.WriteLine($"Root directory: {_rootDirectory}");
        }

        public void RunLab(string labName, string inputFilePath, string outputFilePath)
        {
            try
            {
                string buildProjPath = Path.Combine(_rootDirectory, "Build.proj");
                if (!File.Exists(buildProjPath))
                {
                    throw new FileNotFoundException($"No build file: {buildProjPath}");
                }

                string fullInputPath = Path.GetFullPath(Path.Combine(_baseDirectory, inputFilePath));
                string fullOutputPath = Path.GetFullPath(Path.Combine(_baseDirectory, outputFilePath));
                
                // дебаг принти 
                Console.WriteLine($"Input file path: {fullInputPath}");
                Console.WriteLine($"Output file path: {fullOutputPath}");

                if (!File.Exists(fullInputPath))
                {
                    throw new FileNotFoundException($"No input: {fullInputPath}");
                }

                Directory.CreateDirectory(Path.GetDirectoryName(fullOutputPath));

                string labOutputPath = Path.Combine(_rootDirectory, labName, labName, "files", "OUTPUT.txt");
                
                LabExecution.ExecuteLabCommand(labName, _rootDirectory);

                System.Threading.Thread.Sleep(1000);

                // якщо лаба зробила аутпут - копіюєм його куди нам треба
                if (!File.Exists(labOutputPath))
                {
                    throw new FileNotFoundException($"лаба чомусь не створила аутпут: {labOutputPath}");
                }

                File.Copy(labOutputPath, fullOutputPath, true);
                Console.WriteLine($"Results written to: {fullOutputPath}");
            }
            catch (Exception ex)
            {
                
                Console.WriteLine($"Error running {labName}: {ex.Message}");
            }
        }

        
        private string FindProjectRoot(string startPath)
        {
            var currentPath = startPath;
            while (!string.IsNullOrEmpty(currentPath))
            {
                if (File.Exists(Path.Combine(currentPath, "Build.proj")))
                    return currentPath;
                
                currentPath = Path.GetDirectoryName(currentPath); // йдем на папку вище
            }
            return null; // якщо нічого не знайшли
        }
    }
}