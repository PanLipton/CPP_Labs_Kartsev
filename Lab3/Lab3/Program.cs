using IKartsev.GraphLibrary;

namespace Lab3
{
    public static class Program
    {
        static void Main()
        {
            Console.WriteLine("Lab-03");
            Console.WriteLine();
            try
            {
                ExecuteProgram();
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: " + e.Message);
            }
        }

        public static void ExecuteProgram()
        {
            var filesHandler = new FilesHandler();

            string inputFilePath = filesHandler.InputFilePath;
            string outputFilePath = filesHandler.OutputFilePath;


            var inputData = filesHandler.ProcessInputFile(inputFilePath);

            int vertices = inputData.Item1; // Кількість вершин
            var edges = inputData.Item2;   // Ребра графа

            Console.WriteLine("Graph loaded:");
            Console.WriteLine("Number of vertices: " + vertices);
            foreach (var edge in edges)
            {
                Console.WriteLine($"Edge: {edge.Item1} -> {edge.Item2}, weight: {edge.Item3}");
            }

            // Рахуємо найкоротші шляхи
            var graph = new Graph(vertices);
            foreach (var edge in edges)
            {
                graph.AddEdge(edge.Item1, edge.Item2, edge.Item3);
            }

            var distances = graph.BellmanFord(0); // Обчислюємо шляхи від вершини 0

            // Перетворюємо результат для запису
            var results = new List<int>();
            foreach (var distance in distances)
            {
                if (distance == int.MaxValue)
                {
                    results.Add(30000);
                }
                else
                {
                    results.Add(distance);
                }
            }

            Console.WriteLine("Shortest distances from vertex 0:");
            foreach (var res in results)
            {
                Console.Write(res + " ");
            }
            Console.WriteLine();

            filesHandler.WriteOutputFile(outputFilePath, results);

            Console.WriteLine("Results written to file: " + outputFilePath);
        }
    }
}
