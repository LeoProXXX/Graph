using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Representation
{
    // A user define class to represent a graph.
    // A graph is an array of adjacency lists.
    // Size of array will be V (number of vertices 
    // in graph)
    class Graph
    {
        public int V;
        public List<int>[] adjListArray;

        // constructor 
        public Graph(int V)
        {
            this.V = V;

            // define the size of array as 
            // number of vertices
            adjListArray = new List<int>[V];

            // Create a new list for each vertex
            // such that adjacent nodes can be stored
            for (int i = 0; i < V; i++)
            {
                adjListArray[i] = new List<int>();
            }
        }
    }

    class Program
    {


        // Adds an edge to an undirected graph
        static void addEdge(Graph graph, int src, int dest)
        {
            // Add an edge from src to dest. 
            graph.adjListArray[src].Add(dest);

            // Since graph is undirected, add an edge from dest
            // to src also
            graph.adjListArray[dest].Add(src);
        }

        // A utility function to print the adjacency list 
        // representation of graph
        static void printGraph(Graph graph)
        {
            for (int v = 0; v < graph.V; v++)
            {
                Console.WriteLine("Adjacency list of vertex " + v);
                Console.Write("head");
                foreach (int pCrawl in graph.adjListArray[v])
                {
                    Console.Write(" -> " + pCrawl);
                }
                Console.WriteLine("\n");
            }
        }

        static List<List<int>> MacierzNaListe(int[,] tab)
        {
            List<List<int>> lista = new List<List<int>>();

            for (int i = 0; i < tab.GetLength(0); i++)
            {
                lista.Add(new List<int>());
                for (int j = 0; j < tab.GetLength(1); j++)
                {
                    if (tab[i, j] != 0)
                    {
                        lista[i].Add(j);
                    }
                }
            }
            return lista;
        }

        static int[,] ListaNaMacierz(List<List<int>> lista)
        {
            int[,] tab = new int[lista.Count, lista.Count];

            for (int i = 0; i < lista.Count; i++)
            {
                for (int j = 0; j < lista[i].Count; j++)
                {
                    tab[i, lista[i][j]] = 1;
                }
            }

            return tab;
        }

        static void Main(string[] args)
        {
            // create the graph given in above figure
            int V = 5;
            Graph graph = new Graph(V);
            addEdge(graph, 0, 1);
            addEdge(graph, 0, 4);
            addEdge(graph, 1, 2);
            addEdge(graph, 1, 3);
            addEdge(graph, 1, 4);
            addEdge(graph, 2, 3);
            addEdge(graph, 3, 4);

            // print the adjacency list representation of 
            // the above graph
            printGraph(graph);

            Console.ReadKey();

            //////////////////////////////////////////////////////////////////////////////////////////////////
            /// listy na macierze i na odwrót 
            //////////////////////////////////////////////////////////////////////////////////////////////////

            //macierz sąsiedztwa
            int[,] tab ={   {0, 1, 0, 0, 1, 0},
                            {1, 0, 1, 0, 1, 0},
                            {0, 1, 0, 1, 0, 0},
                            {0, 0, 1, 0, 1, 1},
                            {1, 1, 0, 1, 0, 0},
                            {0, 0, 0, 1, 0 ,0} };

            // numeracja od 0 
            List<List<int>> G = new List<List<int>>();
            List<int> l1 = new List<int>();
            l1.Add(1); l1.Add(4); G.Add(l1);
            List<int> l2 = new List<int>();
            l2.Add(0); l2.Add(2); l2.Add(4); G.Add(l2);
            List<int> l3 = new List<int>();
            l3.Add(1); l3.Add(3); G.Add(l3);
            List<int> l4 = new List<int>();
            l4.Add(2); l4.Add(4); l4.Add(5); G.Add(l4);
            List<int> l5 = new List<int>();
            l5.Add(0); l5.Add(1); l5.Add(3); G.Add(l5);
            List<int> l6 = new List<int>();
            l6.Add(3); G.Add(l6);

            Console.WriteLine("lista sąsiedztwa bezpośrednio");

            for (int i = 0; i < G.Count; i++)
            {
                Console.Write(i + ": ");
                for (int j = 0; j < G[i].Count; j++)
                {
                    Console.Write(G[i][j] + " ");
                }
                Console.WriteLine();
            }

            List<List<int>> GG = MacierzNaListe(tab);
            Console.WriteLine("lista sąsiedztwa z macierzy");
            for (int i = 0; i < GG.Count; i++)
            {
                Console.Write(i + ": ");
                for (int j = 0; j < GG[i].Count; j++)
                {
                    Console.Write(GG[i][j] + " ");
                }
                Console.WriteLine();
            }

            int[,] tab2 = ListaNaMacierz(G);
            Console.WriteLine("macierz z listy");
            for (int i = 0; i < tab2.GetLength(0); i++)
            {
                for (int j = 0; j < tab2.GetLength(1); j++)
                {
                    Console.Write(tab2[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.ReadKey();

        }
    }
}