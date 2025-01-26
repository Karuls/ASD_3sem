using System;
using System.Collections.Generic;

public class Programm
{
    public static void Main(string[] args)
    {
        List<(string name, int weight, int coast)> list = new List<(string name, int weight, int coast)>();
        Console.WriteLine("Введите товары (название, вес товара и стоимость товара)");

        int backpack = 1;
        int key = 1;
        string NAME;
        int WEIGHT;
        int COAST;

        do
        {
            Console.WriteLine("Ввести товар - 0. Выход - 1");
            key = int.Parse(Console.ReadLine());

            switch (key)
            {
                case 0:
                    Console.Write("Введите название товара: ");
                    NAME = Console.ReadLine();
                    Console.Write("Введите вес товара: ");
                    WEIGHT = int.Parse(Console.ReadLine());
                    Console.Write("Введите цену товара: ");
                    COAST = int.Parse(Console.ReadLine());
                    list.Add((NAME, WEIGHT, COAST));
                    break;
                case 1:
                    key = -1;
                    break;
            }
        } while (key != -1);

        Console.WriteLine("Введите вместимость рюкзака");
        backpack = int.Parse(Console.ReadLine());

        int[,] result = new int[list.Count + 1, backpack + 1];

        
        for (int i = 1; i <= list.Count; i++)
        {
            for (int j = 1; j <= backpack; j++)
            {
                if (list[i - 1].weight <= j)
                {
                    result[i, j] = Math.Max(result[i - 1, j], result[i - 1, j - list[i - 1].weight] + list[i - 1].coast);
                }
                else
                {
                    result[i, j] = result[i - 1, j];
                }
            }
        }

        Console.WriteLine("Максимальная стоимость, которую можно унести в рюкзаке: " + result[list.Count, backpack]);

        // Если хотите вывести, какие предметы входят в оптимальное решение:
        
        int w = backpack;
        List<string> itemsIncluded = new List<string>();

        for (int i = list.Count; i > 0 && w > 0; i--)
        {
            if (result[i, w] != result[i - 1, w]) // предмет i включен
            {
                itemsIncluded.Add(list[i - 1].name);
                w -= list[i - 1].weight;
            }
        }

        Console.WriteLine("Включенные предметы: " + string.Join(", ", itemsIncluded));
    }
}
