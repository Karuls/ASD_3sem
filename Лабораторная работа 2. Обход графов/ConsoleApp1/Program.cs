using System;
using System.Collections.Generic;
using System.Collections.Specialized;

class Program
{
    static void BFS(int[][] arr, int num){

        Queue<int> q = new Queue<int>();
        int[] visited = new int[10];
        int temp_now = 0;
        int? temp_next = null;
        q.Enqueue(num);
        Console.WriteLine($"Добавили в очередь {num}");
        //
        while (q.Count != 0) {
            bool flag = false;
            bool same_digits = false;
            temp_now = q.Peek();
            q.Dequeue(); 
            if( q.Count > 0) { temp_next = q.Peek(); }
            //----------------------------------------------> Запись в просещение
            for (int i = 0; i < visited.Length; i++){
                if (visited[i] == temp_now) {
                    flag = true;
                    break;
                }
            }
            if (!flag) { 
            for (int i = 0; i < visited.Length; i++){
                    if (visited[i] == 0) {
                        visited[i] = temp_now; break;
                    }
            }
             }
            //----------------------------------------------> Запись смежных вершнин в очередь
            for (int i = 0; i < arr[temp_now].Length; i++){

                for(int j = 0; j < visited.Length; j++)
                {
                    if (arr[temp_now][i] == visited[j] || arr[temp_now][i] == temp_next)
                    {
                        same_digits = true ; break;
                    }
                }
                if(!same_digits) {
                    q.Enqueue((int)arr[temp_now][i]);
                    Console.WriteLine($"Добавили в очередь {arr[temp_now][i]}");
                }
                
                    same_digits = false;
            }
            
            
        }
        Console.WriteLine("Аль-хамду ли-Ллях, работает");

    }//------------------------------------------------------

   static void DFS(int[][] arr, int num){
        Stack<int> q = new Stack<int>();
        int[] visited = new int[10];
        int temp_now = 0; 
        int? temp_next = null;
        q.Push(num);
        Console.WriteLine($"Добавили в stack {num}");
        //
        while (q.Count != 0)
        {
            bool flag = false;
            bool same_digits = false;
            temp_now = q.Peek();
            q.Pop();
            if (q.Count > 0) { temp_next = q.Peek(); }
            //----------------------------------------------> Запись в посещение
            for (int i = 0; i < visited.Length; i++)
            {
                if (visited[i] == temp_now)
                {
                    flag = true;
                    break;
                }
            }
            if (!flag)
            {
                for (int i = 0; i < visited.Length; i++)
                {
                    if (visited[i] == 0)
                    {
                        visited[i] = temp_now; break;
                    }
                }
            }
            //----------------------------------------------> Запись смежных вершнин в очередь
            for (int i = 0; i < arr[temp_now].Length; i++)
            {

                for (int j = 0; j < visited.Length; j++)
                {
                    if (arr[temp_now][i] == visited[j] || arr[temp_now][i] == temp_next)
                    {
                        same_digits = true; break;
                    }
                }
                if (!same_digits)
                {
                    q.Push((int)arr[temp_now][i]);
                    Console.WriteLine($"Добавили в stack {arr[temp_now][i]}");
                }

                same_digits = false;
            }


        }
        Console.WriteLine("Аль-хамду ли-Ллях");

    }

    static void BFS_matrix(int[][] matrix, int num)
    {
        Queue<int> q = new Queue<int>();
        int[] visited = new int[matrix.Length];
        int temp_now = 0; 
        int? temp_next = null;
        q.Enqueue(num);
        Console.WriteLine($"Добавили в очередь {num}");

        while(q.Count != 0) {
            int count_temp = 0;
            bool flag = false;
            bool same_digits = false;
            temp_now = q.Peek();
            q.Dequeue();
            if (q.Count > 0) { 
                temp_next = q.Peek();
            }
            //----------------------------------------------> Запись в просещение
            for (int i = 0; i < visited.Length; i++)
            {
                if (visited[i] == temp_now)
                {
                    flag = true;
                    break;
                }
            }
            if (!flag)
            {
                for (int i = 0; i < visited.Length; i++)
                {
                    if (visited[i] == 0)
                    {
                        visited[i] = temp_now; break;
                    }
                }
            }
            //----------------------------------------------> Запись смежных вершнин в очередь
            for (int i = 1; i < 11; i++)
            {
                if (matrix[i][temp_now] == 0) { continue; }
                else if (matrix[i][temp_now] == 1)
                {
                    for (int j = 0; j < visited.Length; j++)
                    {
                        if (i == visited[j] || i == temp_next) {
                            same_digits = true;
                            break;
                        }
                    }
                    if (!same_digits)
                    {
                        q.Enqueue(i);
                        Console.WriteLine($"Добавили в очередь {i}");
                    }
                    same_digits = false;

                }
                
            }
        }

    }
    //--
    static void DFS_matrix(int[][] matrix, int num)
    {
        
        Stack<int> q = new Stack<int>();
        int[] visited = new int[matrix.Length];
        int temp_now = 0;
        int? temp_next = null;
        q.Push(num);
        Console.WriteLine($"Добавили в stack {num}");

        while (q.Count != 0)
        {
            int count_temp = 0;
            bool flag = false;
            bool same_digits = false;
            temp_now = q.Peek();
            q.Pop();
            if (q.Count > 0)
            {
                temp_next = q.Peek();
            }
            //----------------------------------------------> Запись в просещение
            for (int i = 0; i < visited.Length; i++)
            {
                if (visited[i] == temp_now)
                {
                    flag = true;
                    break;
                }
            }
            if (!flag)
            {
                for (int i = 0; i < visited.Length; i++)
                {
                    if (visited[i] == 0)
                    {
                        visited[i] = temp_now; break;
                    }
                }
            }
            //----------------------------------------------> Запись смежных вершнин в очередь
            for (int i = 1; i < 11; i++)
            {
                if (matrix[i][temp_now] == 0) { continue; }
                else if (matrix[i][temp_now] == 1)
                {
                    for (int j = 0; j < visited.Length; j++)
                    {
                        if (i == visited[j] || i == temp_next)
                        {
                            same_digits = true;
                            break;
                        }
                    }
                    if (!same_digits)
                    {
                        q.Push(i);
                        Console.WriteLine($"Добавили в stack {i}");
                    }
                    same_digits = false;

                }




            }



        }
        Console.WriteLine();
    }

    static void BFS_rebers(int[][] list1, int[][] list2, int num)
    {
        Queue<int> q = new Queue<int>();
        int[] visited = new int[10];
        int temp_now = 0;
        int? temp_next = null;
        q.Enqueue(num); Console.WriteLine($"Добавили в очередь {num}");
        //
        while (q.Count != 0)
        {
            bool flag = false;
            bool same_digits = false;
            temp_now = q.Peek();
            q.Dequeue();
            if (q.Count > 0) { temp_next = q.Peek(); }
            //----------------------> Запись в просещение
            for (int i = 0; i < visited.Length; i++)
            {
                if (visited[i] == temp_now)
                {
                    flag = true;
                    break;
                }
            }
            if (!flag)
            {
                for (int i = 0; i < visited.Length; i++)
                {
                    if (visited[i] == 0)
                    {
                        visited[i] = temp_now; break;
                    }
                }
            }
            //-> Запись смежных вершнин в очередь
            for (int i = temp_now; i < list1.Length; i++)
            {
                if (list1[i][0] != temp_now) {
                    continue;
                }

                for (int j = 0; j < visited.Length; j++)
                {
                    if (list1[i][1] == visited[j] || list1[i][1] == temp_next)
                    {
                        same_digits = true;
                        break;
                    }
                }
                if (!same_digits)
                {
                    q.Enqueue(list1[i][1]);
                    Console.WriteLine($"Добавили в очередь {list1[i][1]}");
                }
                same_digits = false;

                


            }


        }
        Console.WriteLine("");
    }

    static void DFS_rebers(int[][] list1, int[][] list2, int num)
    {
        Stack<int> q = new Stack<int>();
        int[] visited = new int[10];
        int temp_now = 0;
        int? temp_next = null;
        q.Push(num); Console.WriteLine($"Добавили в stack {num}");
        //
        while (q.Count != 0)
        {
            bool flag = false;
            bool same_digits = false;
            temp_now = q.Peek();
            q.Pop();
            if (q.Count > 0) { temp_next = q.Peek(); }
            //----------------------> Запись в просещение
            for (int i = 0; i < visited.Length; i++)
            {
                if (visited[i] == temp_now)
                {
                    flag = true;
                    break;
                }
            }
            if (!flag)
            {
                for (int i = 0; i < visited.Length; i++)
                {
                    if (visited[i] == 0)
                    {
                        visited[i] = temp_now; break;
                    }
                }
            }
            //-> Запись смежных вершнин в очередь
            for (int i = temp_now; i < list1.Length; i++)
            {
                if (list1[i][0] != temp_now)
                {
                    continue;
                }

                for (int j = 0; j < visited.Length; j++)
                {
                    if (list1[i][1] == visited[j] || list1[i][1] == temp_next)
                    {
                        same_digits = true;
                        break;
                    }
                }
                if (!same_digits)
                {
                    q.Push(list1[i][1]);
                    Console.WriteLine($"Добавили в очередь {list1[i][1]}");
                }
                same_digits = false;




            }


        }
        Console.WriteLine("");
    }



    static void Main(string[] args)
    {
        int[][] teeth_array = { // список смежности
            /*0*/ new int[0] { },
            /*1*/ new int[2] { 2, 5 },
            /*2*/ new int[2] { 7, 8 },
            /*3*/ new int[1] { 8 },
            /*4*/ new int[2] { 6, 9 },
            /*5*/ new int[2] { 1, 6 },
            /*6*/ new int[3] { 5, 4, 9 },
            /*7*/ new int[2] { 2, 8 },
            /*8*/ new int[2] { 3, 7 },
            /*9*/ new int[3] { 4, 6, 10 },
            /*10*/new int[1] { 9 }  
        };
      
        //-----------------> список смежности

        int[][] list1_of_connections_1 =
        {
            /*0*/ new int[0] { },
            /*1*/ new int[2] {1, 2},
            /*2*/ new int[2] {1, 5},
            /*3*/ new int[2] {2, 7},
            /*4*/ new int[2] {2, 8},
            /*5*/ new int[2] {3, 8},
            /*6*/ new int[2] {4, 6},
            /*7*/ new int[2] {4, 9},
            /*8*/ new int[2] {5, 1},
            /*9*/ new int[2] {5, 6},
            /*10*/ new int[2] {6, 4},
            /*11*/ new int[2] {6, 9},
            /*12*/ new int[2] {7, 2},
            /*13*/ new int[2] {7, 8},
            /*14*/ new int[2] {8, 7},
            /*15*/ new int[2] {8, 3},
            /*16*/ new int[2] {9, 4},
            /*17*/ new int[2] {9, 6},
            /*18*/ new int[2] {9, 10},
            /*19*/ new int[2] {10, 9},
        };

        int[][] list1_of_connections_2 =
       {
            /*0*/ new int[0] { },
            /*1*/ new int[2] {2, 1},
            /*2*/ new int[2] {5, 1},
            /*3*/ new int[2] {7, 2},
            /*4*/ new int[2] {8, 2},
            /*5*/ new int[2] {8, 3},
            /*6*/ new int[2] {6, 4},
            /*7*/ new int[2] {9, 4},
            /*8*/ new int[2] {1, 5},
            /*9*/ new int[2] {6, 5},
            /*10*/ new int[2] {4, 6},
            /*11*/ new int[2] {9, 6},
            /*12*/ new int[2] {2, 7},
            /*13*/ new int[2] {8, 7},
            /*14*/ new int[2] {7, 8},
            /*15*/ new int[2] {3, 8},
            /*16*/ new int[2] {4, 9 },
            /*17*/ new int[2] {6, 9 },
            /*18*/ new int[2] {10, 9 },
            /*19*/ new int[2] {9, 10 },
        };

        int[][] matrix =
        {
            /*0*/ new int[0] { },
                                //1  2  3  4  5  6  7  8  9  10
            /*1*/ new int[11] {0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0 },
            /*2*/ new int[11] {0, 1, 0, 0, 0, 0, 0, 1, 1, 0, 0 },
            /*3*/ new int[11] {0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0 },
            /*4*/ new int[11] {0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0 },
            /*5*/ new int[11] {0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0 },
            /*6*/ new int[11] {0, 0, 0, 0, 1, 1, 0, 0, 0, 1, 0 },
            /*7*/ new int[11] {0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0 },
            /*8*/ new int[11] {0, 0, 1, 1, 0, 0, 0, 1, 0, 0, 0 },
            /*9*/ new int[11] {0, 0, 0, 0, 1, 0, 1, 0, 0, 1, 0 },
            /*10*/new int[11] {0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0 },
        };
        int? count = 999;
        int? digit = null;
        int V = 10;
        int E = 11;
        Console.WriteLine(" 1 - «Поиска в ширину» C помощью списка смежности");
        Console.WriteLine(" 2 - «Поиска в ширину» C помощью списка ребер");
        Console.WriteLine(" 3 - «Поиска в ширину» C помощью матрицы смежности ");
        Console.WriteLine(" 4 - «Поиска в глубину» C помощью списка смежности");
        Console.WriteLine(" 5 - «Поиска в глубину» C помощью списка ребер");
        Console.WriteLine(" 6 - «Поиска в глубину» C помощью матрицы смежности");
        do
        {
            Console.WriteLine("Выберите способ обхода графа: (0 - Выход )");
       count = int.Parse(Console.ReadLine());
            switch (count){
                case 1:
                    BFS(teeth_array, 1); 
                    Console.WriteLine($"O() = {V+E}");
                    break;
                case 2:
                     BFS_rebers(list1_of_connections_1, list1_of_connections_2, 1);
                    Console.WriteLine($"O() = {V + E}"); 
                    break;
                case 3:
                     BFS_matrix(matrix, 1);
                    Console.WriteLine($"O() = {V * V}");
                    break;
                case 4:
                    DFS(teeth_array, 1); break;
                case 5:
                    DFS_rebers(list1_of_connections_1, list1_of_connections_2, 1);
                    Console.WriteLine($"O() = {V + E}");
                    break;
                case 6:
                    BFS_matrix(matrix, 1);
                    Console.WriteLine($"O() = {V * V}");
                    break;


            }

        } while (count != 0);
       
        return;

    }
}
