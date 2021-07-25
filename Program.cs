using DegreeArray;
using System;
using System.Collections.Generic;
using System.IO;

namespace DoubleDegreeArray
{
    class Program
    {
        static void Main(string[] args)
        {
            GraphImporter graphImporter = new();
            var graph = graphImporter.ImportGraph("C:/Users/masterofdoom/code projects/C#/doubleDegreeArray/rosalind_ddeg.txt");

            var degreeArray = DegreeArray(graph);

            var doubleDegreeArray = DoubleDegree(graph, degreeArray);

            using StreamWriter sw = new("C:/Users/masterofdoom/code projects/C#/doubleDegreeArray/solution.txt");
            {
                for (int i = 1; i < doubleDegreeArray.Count; i++) // ignoring the first index because it doesn't contain any information to aid base 0 index alignment.
                {
                    int vertex = doubleDegreeArray[i];
                    Console.Write($"{vertex} ");
                    sw.Write($"{vertex} ");
                }
            }            
        }

        public static List<int> DegreeArray(List<string[]> graph)
        {
            int numberOfVertices = Int32.Parse(graph[0][0]);
            List<int> degreeOfVertex = new() { 0 };

            for (int i = 1; i <= numberOfVertices; i++) // Starting at 1 to ignore the first position in the list which corresponds to m and n and not to an edge.
            {
                degreeOfVertex.Add(0);
                for (int j = 1; j < graph.Count; j++)
                {
                    string iString = i.ToString();
                    var edge = graph[j];
                    if (edge[0] == iString || edge[1] == iString) // Every edge a vertex is part of increases its degree of vertex by 1.
                    {
                        degreeOfVertex[i] += 1;
                    }
                }
            }
            return degreeOfVertex;
        }

        public static List<int> DoubleDegree(List<string[]> graph, List<int> degreeArray) // Returns the sum of the degree of vertex of adjacent vertices for each vertex in a graph. 
        {
            int numberOfVertices = Int32.Parse(graph[0][0]);
            List<int> doubleDegreeArray = new() { 0 };

            for (int i = 1; i <= numberOfVertices; i++) // Get all the adjacent vertices of each vertex.
            {
                doubleDegreeArray.Add(0);
                List<int> adjacentVertices = new();
                for (int j = 1; j < graph.Count; j++)
                {
                    var iString = i.ToString();
                    var edge = graph[j];
                    if (edge[0] == iString)
                    {
                        adjacentVertices.Add(Int32.Parse(edge[1]));
                    }
                    else if (edge[1] == iString)
                    {
                        adjacentVertices.Add(Int32.Parse(edge[0]));
                    }
                }
                foreach (int vertex in adjacentVertices) // Sum the degree of vertex for all adjacent vertices.
                {
                    doubleDegreeArray[i] += degreeArray[vertex];
                }
            }
            return doubleDegreeArray;
        }
    }
}
