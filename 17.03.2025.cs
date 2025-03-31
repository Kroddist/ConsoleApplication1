using System;
using System.Linq;
using System.Text.RegularExpressions;

class Program
{
    static void BubbleSort(int[] arr)
    {
        int n = arr.Length;
        for (int i = 0; i < n - 1; i++)
            for (int j = 0; j < n - i - 1; j++)
                if (arr[j] > arr[j + 1])
                    (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
    }

    static void QuickSort(int[] arr, int left, int right)
    {
        if (left < right)
        {
            int pivot = arr[right], i = left - 1;
            for (int j = left; j < right; j++)
                if (arr[j] < pivot)
                    (arr[++i], arr[j]) = (arr[j], arr[i]);
            (arr[i + 1], arr[right]) = (arr[right], arr[i + 1]);
            QuickSort(arr, left, i);
            QuickSort(arr, i + 2, right);
        }
    }

    static int StringLength(string str)
    {
        int length = 0;
        foreach (char c in str) length++;
        return length;
    }

    static string ReverseString(string str)
    {
        return new string(str.Reverse().ToArray());
    }

    static int WordCount(string str)
    {
        return str.Split(new[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries).Length;
    }

    static bool CompareStrings(string str1, string str2)
    {
        if (StringLength(str1) != StringLength(str2)) return false;
        for (int i = 0; i < str1.Length; i++)
            if (str1[i] != str2[i]) return false;
        return true;
    }

    static (int alphabets, int digits, int specials) CountCharacters(string str)
    {
        int alphabets = 0, digits = 0, specials = 0;
        foreach (char c in str)
        {
            if (char.IsLetter(c)) alphabets++;
            else if (char.IsDigit(c)) digits++;
            else specials++;
        }
        return (alphabets, digits, specials);
    }

    static string CopyString(string str)
    {
        char[] copy = new char[str.Length];
        for (int i = 0; i < str.Length; i++)
            copy[i] = str[i];
        return new string(copy);
    }

    static (int vowels, int consonants) CountVowelsConsonants(string str)
    {
        int vowels = 0, consonants = 0;
        foreach (char c in str.ToLower())
        {
            if ("aeiou".Contains(c)) vowels++;
            else if (char.IsLetter(c)) consonants++;
        }
        return (vowels, consonants);
    }

    static void SortStrings(string[] arr)
    {
        Array.Sort(arr, StringComparer.Ordinal);
    }

    static void Main()
    {
        int[] arr = { 64, 34, 25, 12, 22, 11, 90 };
        BubbleSort(arr);
        Console.WriteLine("Bubble Sort: " + string.Join(", ", arr));

        int[] arr2 = { 64, 34, 25, 12, 22, 11, 90 };
        QuickSort(arr2, 0, arr2.Length - 1);
        Console.WriteLine("Quick Sort: " + string.Join(", ", arr2));

        string str = "Hello, World!";
        Console.WriteLine("String Length: " + StringLength(str));
        Console.WriteLine("Reversed: " + ReverseString(str));
        Console.WriteLine("Word Count: " + WordCount(str));
        Console.WriteLine("Compare Strings: " + CompareStrings("test", "test"));

        var counts = CountCharacters(str);
        Console.WriteLine($"Alphabets: {counts.alphabets}, Digits: {counts.digits}, Specials: {counts.specials}");

        Console.WriteLine("Copied String: " + CopyString(str));
        var vc = CountVowelsConsonants(str);
        Console.WriteLine($"Vowels: {vc.vowels}, Consonants: {vc.consonants}");

        string[] words = { "banana", "apple", "cherry" };
        SortStrings(words);
        Console.WriteLine("Sorted Strings: " + string.Join(", ", words));
    }
}
