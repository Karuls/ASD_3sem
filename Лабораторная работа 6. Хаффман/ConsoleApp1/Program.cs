using System;
using System.Collections.Generic;

class Program
{

    static Node BuildHuffmanTree(List<(string symbol, int repeats)> list)
    {
        List<Node> nodes = new List<Node>();


        foreach (var item in list)
        {
            nodes.Add(new Node(item.symbol, item.repeats));
        }

        
        while (nodes.Count > 1)
        {
            
            nodes.Sort((x, y) =>
            {
                int result = x.rate.CompareTo(y.rate);
                if (result == 0)
                {
                    
                    if (x.Symbol != "" && y.Symbol != "" && x.Symbol != null && y.Symbol != null)
                    {
                        
                        return x.Symbol.CompareTo(y.Symbol);
                    }
                    // Ставим узлы с null символами после узлов с символами
                    if (x.HasVal()) return -1;
                    if (y.HasVal()) return 1;
                }
                return result;
            });

            
            var left = nodes[0];
            var right = nodes[1];
            
        
            Node parent = new Node(null, left.rate + right.rate)
            {
                Left = left,
                Right = right
            };

            
            nodes.RemoveAt(0);
            nodes.RemoveAt(0);
            nodes.Add(parent);
        }

        
        return nodes[0];
    }


    public static void Main(string[] args)
    {
        Console.Write("Введите строку: ");
        string user_enter_string = Console.ReadLine();

        
        List<(string symbol, int repeats)> list = new List<(string symbol, int repeats)>();

        foreach (char elem1 in user_enter_string)
        {
            string elem = elem1.ToString();
            var index = list.FindIndex(item => item.symbol == elem);
            if (index != -1)
            {
                list[index] = (list[index].symbol, list[index].repeats + 1);
            }
            else
            {
                list.Add((elem, 1));
            }
        }
        foreach (var item in list)
        {
            Console.WriteLine($"{item.symbol} : {item.repeats} ({Math.Round(item.repeats / (float)(user_enter_string.Length), 2)})");
        }
        
        Node root = BuildHuffmanTree(list);

        
        Dictionary<string, string> huffmanCodes = new Dictionary<string, string>();
        GenerateCodes(root, "", huffmanCodes);

        
        Console.WriteLine("\nКоды Хаффмана для символов:");
        foreach (var item in huffmanCodes)
        {
            Console.WriteLine($"{item.Key}: {item.Value}");
        }

        
        string encodedString = EncodeString(user_enter_string, huffmanCodes);
        Console.WriteLine("\nЗакодированная строка:");
        Console.WriteLine(encodedString);
        Decodirovka(encodedString, huffmanCodes);




    }

    
    static void GenerateCodes(Node node, string code, Dictionary<string, string> huffmanCodes)
    {
        if (node == null)
            return;

        
        if (node.Symbol != null)
        {
            huffmanCodes[node.Symbol] = code;
        }

        
        GenerateCodes(node.Left, code + "0", huffmanCodes);
        GenerateCodes(node.Right, code + "1", huffmanCodes);
    }

    
    static string EncodeString(string input, Dictionary<string, string> huffmanCodes)
    {
        string encoded = "";
        foreach (char c1 in input)
        {
            string c = c1.ToString();
            encoded += huffmanCodes[c];
        }
        return encoded;
    }

    static void Decodirovka(string input, Dictionary<string, string> huffmanCodes)
    {
        
        var reverseHuffmanCodes = new Dictionary<string, string>();
        foreach (var kvp in huffmanCodes)
        {
            reverseHuffmanCodes[kvp.Value] = kvp.Key;
        }

        string currentCode = "";
        string decodedString = "";

        foreach (var bit in input)
        {
            currentCode += bit; 

            if (reverseHuffmanCodes.ContainsKey(currentCode))
            {
                
                decodedString += reverseHuffmanCodes[currentCode];
                currentCode = ""; 
            }
        }

        Console.WriteLine("\nДекодированная строка:");
        Console.WriteLine(decodedString);
    }

}


class Node
{
    public string? Symbol { get; }
    public int rate { get; }
    public Node Left { get; set; }
    public Node Right { get; set; }

    public Node(string? symbol, int frequency)
    {
        Symbol = symbol;
        rate = frequency;
    }

   
    
}


static class Metods
{
    public static bool Contains(this List<(char symbol, int repeats)> list, char elem)
    {
        foreach (var item in list)
        {
            if (item.symbol == elem)
            {
                return true;
            }
        }
        return false;
    }

    public static void Add_repeat(this List<(char symbol, int repeats)> list, char elem)
    {
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i].symbol == elem)
            {
                var updatedItem = (list[i].symbol, list[i].repeats + 1);
                list[i] = updatedItem;
                break;
            }
        }
    }

    public static bool HasVal(this Node elme)
    {
        if(elme.Symbol == null)
        {
            return false;
        }
        else { return true; }
    }
}
