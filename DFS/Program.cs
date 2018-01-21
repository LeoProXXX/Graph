using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Depth First Traversal or DFS for a Graph
// W głąb
namespace DFS
{
    // This class represents a directed graph using adjacency list
    // representation
    class Graph
    {
        private int V;   // No. of vertices

        // Array  of lists for Adjacency List Representation
        private List<int>[] adj;

        // Constructor
        public Graph(int v)
        {
            V = v;
            adj = new List<int>[v];
            for (int i = 0; i < v; ++i)
                adj[i] = new List<int>();
        }

        //Function to add an edge into the graph
        public void addEdge(int v, int w)
        {
            adj[v].Add(w);  // Add w to v's list.
        }

        /////////////////////////////////////////////////////////////////////////////////
        /// The recursive implementation uses function call stack.
        /////////////////////////////////////////////////////////////////////////////////

        // A function used by DFS
        public void DFSUtil(int v, bool[] visited)
        {
            // Mark the current node as visited and print it
            visited[v] = true;
            Console.Write(v + " ");

            // Recur for all the vertices adjacent to this vertex
            foreach (var item in adj[v])
            {
                if (!visited[item])
                    DFSUtil(item, visited);
            }
        }

        // The function to do DFS traversal. It uses recursive DFSUtil()
        public void DFS()
        {
            // Mark all the vertices as not visited(set as
            // false by default in java)
            bool[] visited = new bool[V];

            // Call the recursive helper function to print DFS traversal
            // starting from all vertices one by one
            for (int i = 0; i < V; ++i)
                if (visited[i] == false)
                    DFSUtil(i, visited);
        }

        /////////////////////////////////////////////////////////////////////////////////
        /// iterative implementation, an explicit stack is used to hold visited vertices.
        /////////////////////////////////////////////////////////////////////////////////

        // prints all not yet visited vertices reachable from s
        public void DFSiterate()
        {
            // Initially mark all vertices as not visited
            bool[] visited = new bool[V];

            for (int i = 0; i < V; i++)
                if (!visited[i])
                {
                    // Create a stack for DFS
                    Stack<int> stack = new Stack<int>();

                    // Push the current source node
                    stack.Push(i);

                    while (stack.Count > 0)
                    {
                        // Pop a vertex from stack and print it
                        i = stack.Peek();
                        stack.Pop();

                        // Stack may contain same vertex twice. So
                        // we need to print the popped item only
                        // if it is not visited.
                        if (visited[i] == false)
                        {
                            Console.Write(i + " ");
                            visited[i] = true;
                        }

                        // Get all adjacent vertices of the popped vertex s
                        // If a adjacent has not been visited, then puah it
                        // to the stack.
                        foreach (var item in adj[i])
                        {
                            //int n = i.next();
                            if (!visited[item])
                                stack.Push(item);
                        }
                    }
                }
        }

        /////////////////////////////////////////////////////////////////////////////////
        /// DFS - z zajec 
        /// zalozenia:
        ///     dociera tylko do mniejsc dostepnym z wezla 0 - no troche to ograniczone 
        /////////////////////////////////////////////////////////////////////////////////
        static List<int> DFS(List<List<int>> G)
        {
            int start = 0;
            Stack<int> stos = new Stack<int>(); //Stos
            List<int> wyniki = new List<int>();
            stos.Push(start); //dodanie pierwszego wierzcholka
            bool[] odwiedzone = new bool[G.Count];

            while (stos.Count != 0)
            {
                int pobrany = stos.Pop();
                if (odwiedzone[pobrany] == false)
                {
                    odwiedzone[pobrany] = true;
                    for (int i = 0; i < G[pobrany].Count; i++)
                    {
                        stos.Push(G[pobrany][G[pobrany].Count - i - 1]); // od konca
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
            Graph g = new Graph(4);

            g.addEdge(0, 1);
            g.addEdge(0, 2);
            g.addEdge(1, 2);
            g.addEdge(2, 0);
            g.addEdge(2, 3);
            g.addEdge(3, 3);

            Graph g2 = new Graph(5);
            g2.addEdge(1, 0);
            g2.addEdge(2, 1);
            g2.addEdge(3, 4);
            g2.addEdge(4, 0);


            Console.WriteLine("Following is Depth First Traversal");

            g.DFS();
            Console.WriteLine();
            g2.DFSiterate();

            Console.ReadKey();
        }
    }
}
