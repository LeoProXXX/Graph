using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstra
{
    //Zadanie 4
    // Zaimplementuj algorytm Dijkstry zgodnie z pseudokodem podanym na wykładzie. 
    //Dla grafów z zadania 2 wypisz krok po kroku realizację algorytmu Dijkstry, 
    //wybierając jako startowy wierzchołek pierwszy (w przypadku B ten z krawędzią cykliczną). 


    // Dodatkowa klasa 
    class Krawedz
    {
        public int koniec;
        public int waga;

        public Krawedz(int koniec, int waga)
        {
            this.koniec = koniec;
            this.waga = waga;
        }
    }

    class Program
    {
        // Modyfikujemy metode z zadania 1
        static List<List<Krawedz>> MacierzNaListe(int[,] tab)
        {
            List<List<Krawedz>> lista = new List<List<Krawedz>>();
            for (int i = 0; i < tab.GetLength(0); i++)
            {
                lista.Add(new List<Krawedz>());
                for (int j = 0; j < tab.GetLength(1); j++)
                {
                    if (tab[i, j] != 0)
                    {
                        lista[i].Add(new Krawedz(j, tab[i, j]));
                    }
                }
            }
            return lista;
        }

        static int[] Dijkstra(List<List<Krawedz>> lista)
        {
            //Inicjacja
            //L := {s}; R := V-{s};
            //w[s] := 0;
            int[] w = new int[lista.Count];
            bool[] b = new bool[lista.Count]; // domyslnie false czyli nalezy do R
            int s = 0;
            b[s] = true; //tylko s w zbiorze L
            w[s] = 0;

            //dla każdego v R wykonaj
            //jeżeli (v,s) E to
            //w[v] := w((v, s))
            //w przeciwnym przypadku
            //w[v] := ∞;
            for (int i = 0; i < w.Length; i++)
            {
                if (!b[i]) // nie nalezy do L
                {
                    w[i] = int.MaxValue; // niekonczonosc
                }
            }

            // modyfikujemy sasiadow s
            for (int i = 0; i < lista[s].Count; i++)
            {
                if (!b[lista[s][i].koniec]) // nie nalezy do L
                {
                    w[lista[s][i].koniec] = lista[s][i].waga;
                }
            }

            // wlasciwe oblizenia
            //dla i := 1 aż do n-1 wykonaj
            for (int i = 1; i < lista.Count; i++)
            {
                // poczatek bloku
                // szukamy wierzcholka w R o najmniejszym w
                int u = -1; // pierwszyw ierzcholek jeszcze nie jest wybrany
                // szukam minimum sposrod tych z R
                for (int j = 0; j < lista.Count; j++)
                {
                    if (!b[j] && ((u == -1) || (w[j] < w[u])))
                    {
                        u = j;
                    }
                }
                //teraz
                //u := wierzchołek z R o minimalnej wadze w[u];    
                b[u] = true; // znaleziony wierzcholek przenosimy do L
                             // czyli
                             //R := R - {u};
                             //L := L + {u};           

                // Modyfikujemy odpowiednio wszystkich sąsiadów u z R
                //dla każdego v N(u) ∩ R wykonaj
                for (int j = 0; j < lista[u].Count; j++)
                {
                    int v = lista[u][j].koniec;
                    if (!b[v] && (w[v] > w[u] + lista[u][j].waga))
                    {
                        w[v] = w[u] + lista[u][j].waga;
                    }
                }
            } // koniec bloku

            return w;
        }


        static void Main(string[] args)
        {
            //macierz sąsiedztwa
            int[,] tabA =  { { 0 ,1, 1, 0, 0 },
                         { 1, 0, 1, 1, 0 },
                         { 1, 1, 0, 0, 1 },
                         { 0, 1, 0, 0, 1 },
                         { 0, 0, 1, 1, 0 } };

            int[,] tabB = {  {1, 0, 0, 3, 0, 0, 7},
                         {0, 0, 2, 0, 4, 0, 1},
                         {0, 2, 0, 4, 1, 2, 3},
                         {3, 0, 4, 0, 5, 3, 3},
                         {0, 4, 1, 5, 0, 1, 2},
                         {0, 0, 2, 3, 1, 0, 2},
                         {7, 1, 3, 3, 2, 2, 0} };

            List<List<Krawedz>> lista = MacierzNaListe(tabA);
            int[] wagi = Dijkstra(lista);

            for (int i = 0; i < wagi.Length; i++)
                Console.WriteLine(i + " : " + wagi[i]);

            Console.WriteLine();

            lista = MacierzNaListe(tabB);
            wagi = Dijkstra(lista);

            for (int i = 0; i < wagi.Length; i++)
                Console.WriteLine(i + " : " + wagi[i]);

            Console.ReadKey();
        }
    }
}
