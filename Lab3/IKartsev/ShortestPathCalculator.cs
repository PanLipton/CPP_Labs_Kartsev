using System;
using System.Collections.Generic;

namespace IKartsev.GraphLibrary
{
    public class Graph
    {
        private int vertices; // Кількість вершин
        private List<Edge> edges; // Список ребер

        public Graph(int v)
        {
            vertices = v;
            edges = new List<Edge>();
        }

        // Додаємо ребро до графа
        public void AddEdge(int from, int to, int weight)
        {
            edges.Add(new Edge(from, to, weight));
        }

        // Алгоритм Беллмана-Форда
        public int[] BellmanFord(int start)
        {
            int[] dist = new int[vertices]; // Відстані від стартової вершини
            for (int i = 0; i < vertices; i++)
            {
                dist[i] = int.MaxValue; // Початково всі відстані нескінченні
            }
            dist[start] = 0; // Відстань до самої себе — 0

            // Релаксуємо всі ребра (vertices - 1) разів
            for (int i = 0; i < vertices - 1; i++)
            {
                foreach (var edge in edges)
                {
                    // Якщо шлях через вершину коротший — оновлюємо
                    if (dist[edge.Source] != int.MaxValue && dist[edge.Source] + edge.Weight < dist[edge.Destination])
                    {
                        dist[edge.Destination] = dist[edge.Source] + edge.Weight;
                    }
                }
            }

            // Перевіряємо на цикл з від’ємною вагою
            foreach (var edge in edges)
            {
                if (dist[edge.Source] != int.MaxValue && dist[edge.Source] + edge.Weight < dist[edge.Destination])
                {
                    throw new Exception("Цикл з від'ємною вагою");
                }
            }

            return dist;
        }

        // Внутрішній клас для представлення ребра
        private class Edge
        {
            public int Source, Destination, Weight;

            public Edge(int src, int dest, int w)
            {
                Source = src;
                Destination = dest;
                Weight = w;
            }
        }
    }
}
