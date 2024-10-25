using System.ComponentModel;
using System.Linq;
using System.Reflection;

class Programm
{
    public static void Main()
    {
       
        int I = int.MaxValue;
        int[][] mass = new int[][]
        { new int[] { I, I, I, I ,I, I, I, I, I},
                                //1  2  3  4  5  6  7  8
            /*1*/  new int[] { I, 0, 2, I ,8, 2, I, I, I},
            /*2*/  new int[] { I, 2, 0, 3, 10, 5, I, I, I},
            /*3*/  new int[] { I, I, 3, 0, I, 12, I, I, 7},
            /*4*/  new int[] { I, 8, 10, I, 0, 14, 3, 1, I},
            /*5*/  new int[] { I, 2, 5, 12, 14, 0, 11, 4, 8},
            /*6*/  new int[] { I, I, I, I, 3, 11, 0, 6, I},
            /*7*/  new int[] { I, I, I, I, 1, 4, 6, 0, 9},
            /*8*/  new int[] { I, I, I, 7, I, 8, I, 9, 0},
        };

        Console.WriteLine("Построение остовного дерева (Прима) ...");
        Prima(mass);
       // Kruskall.Programm1.call_kr();
    }

    public static void Prima(int[][] mass)
    {
        List<int> list = new List<int>();
        List<int> stolbs = new List<int>();
        List<(int elem, int i, int j)> list_elems = new List<(int, int, int)>();


        int I = int.MaxValue;
        int start_i = 0;
        int start_j = 0;
        int min = I;
        int rebers = 16;
        int tops = 8;
        for (int i = 1; i < mass.Length; i++)
        {
            for(int j = 1; j < mass[i].Length; j++) {
                if (mass[i][j] < min && mass[i][j] != 0)
                {
                    min = mass[i][j];
                    start_i = i;
                    start_j = j;
                }
            }
        }
        
        list_elems.Add((min, start_i, start_j));
        
        int Y = rebers - tops + 1;
        Console.WriteLine($"{Y} Вершины не будут соеденены между собой напрямую ");
        rebers = rebers - Y;
        Console.WriteLine($"Всего ребер в остовном дереве {rebers}");
        Console.WriteLine($"Позиция минимального элемента {start_i},{start_j} : {min}");
    
        while (stolbs.Count != tops) {

           
            
        for (int i = 1; i < mass.Length; i++)// Вычеркивание элементов строкп
        {

                if (!list_elems.Contains(mass[start_i][i])){ mass[start_i][i] = I;}
                if (!list_elems.Contains(mass[start_j][i])){ mass[start_j][i] = I;}
                
            
        }                                   // -----------------------------

            if (!stolbs.Contains(start_i)) { stolbs.Add(start_i); } 
            if (!stolbs.Contains(start_j)) { stolbs.Add(start_j); } 
            
            Console.WriteLine($"Выделили столбцы {start_i} и {start_j}");
            min = I - 1;
            for(int i = 0; i < stolbs.Count; i++)
            {
                for (int j = 1; j < mass.Length; j++)
                {
                    if (min > mass[j][stolbs[i]] && (list_elems.Contain(mass[j][stolbs[i]], j, stolbs[i]) == true))
                        {
                        min = mass[j][stolbs[i]];
                        start_i = j;
                        start_j = stolbs[i];
                    }
                }
            }
           
            
        

            list_elems.Add((min, start_i, start_j));
            Y--;

            //for (int i = 1; i < mass.Length; i++)
            //{
            //    for (int j = 1; j < mass.Length; j++)
            //    {
            //        if (mass[i][j] == int.MaxValue) { Console.Write(" 0 "); }
            //        else
            //        {
            //            Console.Write($"[{mass[i][j]}]");
            //        }

            //    }
            //    Console.WriteLine();
            //}

        }


        for (int i = 1; i < mass.Length; i++)
        {
            for (int j = 1; j < mass.Length; j++)
            {
                if (mass[i][j] == mass[j][i] && mass[i][j] < int.MaxValue) { mass[i][j] = 0; }
                if (mass[i][j] == int.MaxValue) { Console.Write(" 0 "); }
                else
                {
                    Console.Write($" {mass[i][j]} ");
                }

            }
            Console.WriteLine();
        }


    }


}


public static class Sever
{
    public static bool Contain(this List<(int elem, int i, int j)> list_elems, int elem, int i, int j)
    {
        foreach (var x in list_elems)
        {
            if (elem == x.elem && i == x.i && j == x.j)
            {
                return false;
            }
        }
        return true;
    }

    public static bool Contains(this List<(int elem, int i, int j)> list_elems, int x)
    {
        foreach (var item in list_elems)
        {
            if(item.elem == x) {  return true; }
        }
        return false;
    }
}







internal class Kruskall
{


    class Edge : IComparable<Edge>
    {
        public int Source { get; set; }
        public int Destination { get; set; }
        public int Weight { get; set; }

        public int CompareTo(Edge other)
        {
            return this.Weight.CompareTo(other.Weight);
        }
    }
    public class Programm1
    {
        static int Find(int[] parent, int i)
        {
            if (parent[i] == i)
                return i;
            return Find(parent, parent[i]);
        }

        static void Union(int[] parent, int[] rank, int x, int y)
        {
            int rootX = Find(parent, x);
            int rootY = Find(parent, y);

            if (rank[rootX] < rank[rootY])
            {
                parent[rootX] = rootY;
            }
            else if (rank[rootX] > rank[rootY])
            {
                parent[rootY] = rootX;
            }
            else
            {
                parent[rootY] = rootX;
                rank[rootX]++;
            }
        }

        static void Kruskal(int[][] graph)
        {
            int vertices = graph.Length;
            List<Edge> edges = new List<Edge>();

            // Создаём список рёбер из матрицы смежности
            for (int i = 0; i < vertices; i++)
            {
                for (int j = 0; j < vertices; j++)
                {
                    if (graph[i][j] != int.MaxValue && i != j)
                    {
                        edges.Add(new Edge { Source = i, Destination = j, Weight = graph[i][j] });
                    }
                }
            }

            // Сортируем рёбра по возрастанию веса
            edges.Sort();

            // Массив для хранения родительских вершин и рангов
            int[] parent = new int[vertices];
            int[] rank = new int[vertices];

            // Инициализируем родителей и ранги
            for (int i = 0; i < vertices; i++)
            {
                parent[i] = i;
                rank[i] = 0;
            }

            List<Edge> result = new List<Edge>();

            // Проходим по отсортированным рёбрам
            foreach (Edge edge in edges)
            {
                int x = Find(parent, edge.Source);
                int y = Find(parent, edge.Destination);

                // Если включение этого ребра не вызывает цикла
                if (x != y)
                {
                    result.Add(edge);
                    Union(parent, rank, x, y);
                }
            }

            // Выводим минимальное остовное дерево
            Console.WriteLine("Минимальное остовное дерево:");
            foreach (Edge edge in result)
            {
                Console.WriteLine($"Ребро: {edge.Source + 1} - {edge.Destination + 1}, Вес: {edge.Weight}");
            }
        }

        public static void call_kr ()
        {
            int I = int.MaxValue;
            int[][] graph = {
            new int[] { I, I, I, I ,I, I, I, I, I},
            new int[] { I, 0, 2, I ,8, 2, I, I, I},
            new int[] { I, 2, 0, 3, 10, 5, I, I, I},
            new int[] { I, I, 3, 0, I, 12, I, I, 7},
            new int[] { I, 8, 10, I, 0, 14, 3, 1, I},
            new int[] { I, 2, 5, 12, 14, 0, 11, 4, 8},
            new int[] { I, I, I, I, 3, 11, 0, 6, I},
            new int[] { I, I, I, I, 1, 4, 6, 0, 9},
            new int[] { I, I, I, 7, I, 8, I, 9, 0},
        };

            Kruskal(graph);
        }

    }

}
