using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// Breadth First Traversal or BFS for a Graph
// Przechodzenie w szerz
namespace BFS
{
    class Graph
    {
        private int V;   // No. of vertices
        private List<int>[] adj; //Adjacency Lists

        // Constructor
        public Graph(int v)
        {
            V = v;
            adj = new List<int>[v];
            for (int i = 0; i < v; ++i)
                adj[i] = new List<int>();
        }

        // Function to add an edge into the graph
        public void addEdge(int v, int w)
        {
            adj[v].Add(w);
        }


        /////////////////////////////////////////////////////////////////////////////////
        /// Z geeksforgeeks.com 
        ///     Dociera do wieszcholków dostepnych z wierzcholka s
        /////////////////////////////////////////////////////////////////////////////////
        // prints BFS traversal from a given source s
        public void BFS(int s)
        {
            // Mark all the vertices as not visited(By default
            // set as false)
            bool[] visited = new bool[V];

            // Create a queue for BFS
            Queue<int> queue = new Queue<int>();

            // Mark the current node as visited and enqueue it
            visited[s] = true;
            queue.Enqueue(s);

            while (queue.Count != 0)
            {
                // Dequeue a vertex from queue and print it
                s = queue.Dequeue();
                Console.Write(s + " ");

                // Get all adjacent vertices of the dequeued vertex s
                // If a adjacent has not been visited, then mark it
                // visited and enqueue it
                foreach (var item in adj[s])
                {
                    if (!visited[item])
                    {
                        visited[item] = true;
                        queue.Enqueue(item);
                    }
                }
            }
        }

        /////////////////////////////////////////////////////////////////////////////////
        /// BFS - z zajec 
        /// zalozenia:
        ///     dociera tylko do mniejsc dostepnym z wezla 0 - no troche to ograniczone 
        /////////////////////////////////////////////////////////////////////////////////
        static List<int> BFS(int[,] tab)
        {
            int start = 0;
            Queue<int> kolejka = new Queue<int>(); //kolejka
            List<int> wyniki = new List<int>();
            kolejka.Enqueue(start); // dodanie pierwszego wierchołka
            bool[] odwiedzone = new bool[tab.GetLength(0)];
            while (kolejka.Count != 0)
            {
                int pobrany = kolejka.Dequeue();
                if (odwiedzone[pobrany] == false)
                {
                    odwiedzone[pobrany] = true;
                    for (int i = 0; i < tab.GetLength(1); i++)
                    {
                        if (tab[pobrany, i] != 0)
                        {
                            kolejka.Enqueue(i);
                        }
                    }
                    wyniki.Add(pobrany);
                }
            }
            return wyniki;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Graph g = new Graph(7);

            g.addEdge(1, 2);
            g.addEdge(1, 3);
            g.addEdge(2, 4);
            g.addEdge(2, 5);
            g.addEdge(3, 5);
            g.addEdge(4, 5);
            g.addEdge(4, 6);
            g.addEdge(5, 6);

            Console.WriteLine("Following is Breadth First Traversal " +
                               "(starting from vertex 1)");

            g.BFS(1);




            Console.WriteLine();
            Console.WriteLine();



            Graph g2 = new Graph(4);

            g2.addEdge(0, 1);
            g2.addEdge(0, 2);
            g2.addEdge(1, 2);
            g2.addEdge(2, 0);
            g2.addEdge(2, 3);
            g2.addEdge(3, 3);

            Console.WriteLine("Following is Breadth First Traversal " +
                               "(starting from vertex 2)");

            g2.BFS(2);


            Console.ReadKey();
        }
    }
}
