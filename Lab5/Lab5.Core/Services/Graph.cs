using System;
using System.Collections.Generic;

namespace Lab5.Core.Services
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
            int[] dist = new int[vertices];
            for (int i = 0; i < vertices; i++)
            {
                dist[i] = int.MaxValue;
            }
            dist[start] = 0;

            // Релаксація всіх ребер (vertices - 1) разів
            for (int i = 0; i < vertices - 1; i++)
            {
                foreach (var edge in edges)
                {
                    if (dist[edge.Source] != int.MaxValue && 
                        dist[edge.Source] + edge.Weight < dist[edge.Destination])
                    {
                        dist[edge.Destination] = dist[edge.Source] + edge.Weight;
                    }
                }
            }

            // Перевірка на цикли з від'ємною вагою
            foreach (var edge in edges)
            {
                if (dist[edge.Source] != int.MaxValue && 
                    dist[edge.Source] + edge.Weight < dist[edge.Destination])
                {
                    throw new Exception("Граф містить цикл з від'ємною вагою");
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