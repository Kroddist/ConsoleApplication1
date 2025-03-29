using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        int[][] intervals = { new int[] {1, 3}, new int[] {3, 7}, new int[] {8, 9} };
        Console.WriteLine(FindMinSetSize(intervals));

        int[,] array = { {1, 5, 3}, {7, 8, 2}, {4, 6, 9} };
        (int min, int max) = FindMinMax(array);
        Console.WriteLine($"Минимум: {min}, Максимум: {max}");

        string input1 = Console.ReadLine();
        Console.WriteLine(CountWords(input1));

        string input2 = Console.ReadLine();
        Console.WriteLine(ReverseWords(input2));

        string input3 = Console.ReadLine();
        Console.WriteLine(CountVowels(input3));

        string input4 = Console.ReadLine();
        string substring = Console.ReadLine();
        Console.WriteLine(CountSubstringOccurrences(input4, substring));
    }

    static int FindMinSetSize(int[][] intervals)
    {
        Array.Sort(intervals, (a, b) => a[1] - b[1]);
        HashSet<int> nums = new HashSet<int>();
        foreach (var interval in intervals)
        {
            int count = 0;
            for (int i = interval[1]; i >= interval[0] && count < 2; i--)
            {
                if (!nums.Contains(i))
                {
                    nums.Add(i);
                    count++;
                }
            }
        }
        return nums.Count;
    }

    static (int, int) FindMinMax(int[,] array)
    {
        int min = array[0, 0], max = array[0, 0];
        foreach (int num in array)
        {
            if (num < min) min = num;
            if (num > max) max = num;
        }
        return (min, max);
    }

    static int CountWords(string input)
    {
        return input.Split(new char[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries).Length;
    }

    static string ReverseWords(string input)
    {
        return string.Join(" ", input.Split(' ').Select(word => new string(word.Reverse().ToArray())));
    }

    static int CountVowels(string input)
    {
        return input.Count(c => "aeiouAEIOUаеёиоуыэюяАЕЁИОУЫЭЮЯ".Contains(c));
    }

    static int CountSubstringOccurrences(string text, string substring)
    {
        int count = 0, index = 0;
        while ((index = text.IndexOf(substring, index)) != -1)
        {
            count++;
            index += substring.Length;
        }
        return count;
    }
}