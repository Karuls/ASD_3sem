class Programm
{

    public static void Main(string[] args)
    {
        int IN = int.MaxValue;
        int[][] matrix = {
            new int[]{0, 28, 21, 59, 12, 27},
            new int[]{7, 0, 24, IN, 21, 9},
            new int[]{9, 32, 0, 13, 11, IN},
            new int[]{8, IN, 5,  0, 16, IN},
            new int[]{14, 13, 15, 10, 0, 22},
            new int[]{15, 18, IN, IN,  6,  0},
        };

        int[][] S =
        {
            new int[] {0, 2, 3, 4, 5, 6},
            new int[] {1, 0, 3, 4, 5, 6},
            new int[] {1, 2, 0, 4, 5, 6},
            new int[] {1, 2, 3, 0, 5, 6},
            new int[] {1, 2, 3, 4, 0, 6},
            new int[] {1, 2, 3, 4, 5, 0},

        };
        int temp;
        int N = matrix.Length;
        for(int k = 0; k < N; k++){
            for(int i = 0; i < N; i++){
                for (int j = 0; j < N;  j++) {
                    temp = matrix[i][j];
                    matrix[i][j] = int.Min(matrix[i][j], matrix[i][k] + matrix[k][j]);
                    if (temp != matrix[i][j]){
                        S[i][j] = k+1; 
                    }
                }
            }
        }

        for(int i = 0;i < N; i++) {
            for (int j = 0; j < N; j++)
            {
                Console.Write($"[{matrix[i][j]}]" );
            }
        Console.WriteLine();
      }
        Console.WriteLine();

        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                Console.Write($"[{S[i][j]}]");
            }
            Console.WriteLine();
        }

        int i = int.Parse( Console.ReadLine() ) - 1;
        int j = int.Parse( Console.ReadLine() ) - 1;
        if()

    }
}