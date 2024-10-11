
class Program
{
    public static void Dijkstra(int count, int[][] matrix)
    {
        int D = int.MaxValue;
        List<int> list = new List<int>();
        int[][] final_matrix = {
            /*0*/ new int[0] { },// 1  2  3  4  5  6  7  8  9 
            /*A*/ new int[2] {D, D},
            /*B*/ new int[2] {D, D},
            /*C*/ new int[2] {D, D},
            /*D*/ new int[2] {D, D},
            /*E*/ new int[2] {D, D},
            /*F*/ new int[2] {D, D},
            /*G*/ new int[2] {D, D},
            /*H*/ new int[2] {D, D},
            /*I*/ new int[2] {D, D},
        };

        int[] previous = new int[10]; 
        for (int i = 0; i < 10; i++) previous[i] = -1;

        final_matrix[count][1] = 0;
        int way_before = final_matrix[count][1];

        list.Add(count);

        while (list.Count < 10)
        {
            int min_neighbor_weigh = D;
            int min_neighbor = D;

            for (int i = 1; i < 10; i++)
            {
                if (matrix[count][i] == D) { continue; }

                if (matrix[count][i] > 0 && matrix[count][i] < D && list.Contains(i) == false)
                {
                    int new_weight = matrix[count][i] + way_before;
                    if (new_weight < final_matrix[i][1])
                    {
                        final_matrix[i][1] = new_weight;
                        previous[i] = count; // Сохраняем предыдущую вершину
                    }

                    if (min_neighbor_weigh > matrix[count][i])
                    {
                        min_neighbor_weigh = matrix[count][i];
                        min_neighbor = i;
                    }
                }
            }

            if (count != int.MaxValue)
            {
                Console.Write($"-> {Convert.ToChar(64 + count)} ");
            }

            list.Add(count);
            way_before += min_neighbor_weigh;

            for (int i = 1; i < 10; i++)
            {
                if (way_before > final_matrix[i][1] && list.Contains(i) == false)
                {
                    way_before = final_matrix[i][1];
                    min_neighbor = i;
                }
            }
            count = min_neighbor;
        }

        Console.WriteLine();
        for (int i = 1; i < 10; i++)
        {
            Console.Write($"До вершины {Convert.ToChar(64 + i)}: {final_matrix[i][1]}. Путь: ");
            PrintPath(i, previous); // Выводим путь к каждой вершине
            Console.WriteLine();
        }

        for (int i = 1; i < 4; i++)
        {
            Console.WriteLine();
        }
    }

    // Вспомогательный метод для вывода пути
    public static void PrintPath(int vertex, int[] previous)
    {
        Stack<int> path = new Stack<int>();
        while (vertex != -1)
        {
            path.Push(vertex);
            vertex = previous[vertex];
        }
        while (path.Count > 0)
        {
            Console.Write($"{Convert.ToChar(64 + path.Pop())} ");
        }
    }

    public static void Main()
    {
        int M = int.MaxValue;
        Console.WriteLine("Введите вершину  ");
        char user_choice = char.Parse(Console.ReadLine());
        int int_user_choice = Convert.ToInt32((char)user_choice) - 64;

        int[][] matrix =
       {
            /*0*/ new int[0] { },
                                 //A   B   C   D   E   F   G   H   I 
            /*A1*/ new int[10] {0, M,  7 , 10, M,  M , M , M , M , M },
            /*B2*/ new int[10] {0, 7 , M , M , M , M , 9 , 27, M , M },
            /*C3*/ new int[10] {0, 10 , M , M , M ,31, 8 , M , M , M },
            /*D4*/ new int[10] {0, M , M , M , M , 32, M , M , 17, 21},
            /*E5*/ new int[10] {0, M , M , 31, 32, M , M , M , M , M },
            /*F6*/ new int[10] {0, M , 9 , 8 , M , M , M , M , 11, M },
            /*G7*/ new int[10] {0, M , 27, M , M , M , M , M , M , 15},
            /*H8*/ new int[10] {0, M , M , M , 17 , M , 11, M ,M , 15},
            /*I9*/ new int[10] {0, M , M , M , 21, M , M , 15, 15, M },
       };
        Dijkstra(int_user_choice, matrix);
    }
}
