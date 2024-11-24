namespace Lab5.Core.Services
{
    public class Lab3Service
    {
        public List<int> CalculateShortestPaths(int vertices, List<(int From, int To, int Weight)> edges)
        {
            var graph = new Graph(vertices);
            foreach (var edge in edges)
            {
                graph.AddEdge(edge.From - 1, edge.To - 1, edge.Weight);
            }

            var distances = graph.BellmanFord(0);
            return distances.ToList();
        }
    }
}