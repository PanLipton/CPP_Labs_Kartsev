using System;
using System.Collections.Generic;
using System.IO;
using IKartsev.GraphLibrary;
using Xunit;

namespace Lab3.Tests
{
    public class GraphTests
    {
        // Дані для тесту читання файлу
        public static IEnumerable<object[]> FileTestCases => new List<object[]>
        {
            new object[] { "4 5\n1 2 10\n2 3 10\n1 3 100\n3 1 -10\n2 3 1", 4, 5, new List<(int, int, int)> { (0, 1, 10), (1, 2, 10), (0, 2, 100), (2, 0, -10), (1, 2, 1) } },
            new object[] { "3 2\n1 2 5\n2 3 7", 3, 2, new List<(int, int, int)> { (0, 1, 5), (1, 2, 7) } }
        };

        [Theory]
        [MemberData(nameof(FileTestCases))]
        public void TestReadFile(string content, int expectedVertices, int expectedEdges, List<(int, int, int)> expectedEdgeList)
        {
            // Тимчасовий файл для тесту
            string tempFile = Path.GetTempFileName();
            File.WriteAllText(tempFile, content);

            var fileHandler = new FilesHandler();
            var result = fileHandler.ProcessInputFile(tempFile);

            Assert.Equal(expectedVertices, result.Item1); // Перевірка кількості вершин
            Assert.Equal(expectedEdges, result.Item2.Count); // Перевірка кількості ребер

            // Перевірка ребер
            for (int i = 0; i < result.Item2.Count; i++)
            {
                Assert.Equal(expectedEdgeList[i], result.Item2[i]);
            }

            File.Delete(tempFile);
        }

        // Дані для тесту алгоритму Беллмана-Форда
        public static IEnumerable<object[]> BellmanFordCases => new List<object[]>
        {
            new object[] { 4, new List<(int, int, int)> { (0, 1, 10), (1, 2, 10), (0, 2, 100), (2, 0, -10), (1, 2, 1) }, 0, new[] { 0, 10, 11, 30000 } },
            new object[] { 3, new List<(int, int, int)> { (0, 1, 5), (1, 2, 7) }, 0, new[] { 0, 5, 12 } }
        };

        [Theory]
        [MemberData(nameof(BellmanFordCases))]
        public void TestBellmanFord(int vertices, List<(int, int, int)> edges, int startVertex, int[] expectedDistances)
        {
            // Створення графу
            var graph = new Graph(vertices);
            foreach (var edge in edges)
            {
                graph.AddEdge(edge.Item1, edge.Item2, edge.Item3);
            }

        
            var distances = graph.BellmanFord(startVertex);

           
            for (int i = 0; i < expectedDistances.Length; i++)  // Перевірка результату
            {
                Assert.Equal(expectedDistances[i], distances[i] == int.MaxValue ? 30000 : distances[i]);
            }
        }
    }
}
