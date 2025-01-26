using System;
using System.Collections.Generic;

class Program
{
    static List<int> LongestIncreasingSubsequence(int[] arr)
    {
        int n = arr.Length;
        int[] dp = new int[n];
        int[] prev = new int[n];


        for (int i = 0; i < n; i++)
        {
            dp[i] = 1;
            prev[i] = -1;
        }

        int maxLengthIndex = 0;


        for (int i = 1; i < n; i++)
        {
            for (int j = 0; j < i; j++)
            {
                if (arr[i] >= arr[j] && dp[i] <= dp[j] + 1)
                {
                    dp[i] = dp[j] + 1;
                    prev[i] = j;
                }
            }


            if (dp[i] > dp[maxLengthIndex])
            {
                maxLengthIndex = i;
            }
        }


        List<int> list = new List<int>();
        int k = maxLengthIndex;
        while (k != -1)
        {
            list.Add(arr[k]);
            k = prev[k];
        }

        list.Reverse();
        return list;
    }

    static void Main()
    {
        Console.WriteLine("Введите числа через пробел:");
        string input = Console.ReadLine();
        int[] arr = Array.ConvertAll(input.Split(), int.Parse);

        List<int> lis = LongestIncreasingSubsequence(arr);
        Console.WriteLine("Наибольшая возрастающая подпоследовательность:");
        Console.WriteLine(string.Join(" ", lis));
    }
}
