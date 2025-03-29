using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Random rand = new Random();
        double[] numbers = Enumerable.Range(0, 20).Select(_ => rand.NextDouble() * 400 - 200).ToArray();
        Console.WriteLine(numbers.Count(n => n >= -100 && n <= 100));

        char ch = Console.ReadKey().KeyChar;
        Console.WriteLine(char.IsDigit(ch));

        string text = Console.ReadLine();
        Console.WriteLine(string.Concat(text.Where(char.IsDigit)));

        string numberText = Console.ReadLine();
        Console.WriteLine(numberText.Where(char.IsDigit).Sum(c => c - '0'));

        string mixedText = Console.ReadLine();
        Console.WriteLine(Regex.Matches(mixedText, "-?\d+").Sum(m => int.Parse(m.Value)));

        string sentence = Console.ReadLine();
        Console.WriteLine(sentence.Split(new[] {' '}, StringSplitOptions.None).Max(s => s.Length - s.Trim().Length));

        string word = Console.ReadLine();
        Console.WriteLine(word.Distinct().Count());

        string firstWord = Console.ReadLine();
        string secondWord = Console.ReadLine();
        Console.WriteLine(string.Join(" ", firstWord.Select(c => secondWord.Contains(c) ? "да" : "нет")));

        string word1 = Console.ReadLine();
        string word2 = Console.ReadLine();
        string word3 = Console.ReadLine();
        Console.WriteLine(string.Concat((word1 + word2 + word3).GroupBy(c => c).Where(g => g.Count() == 1).Select(g => g.Key)));

        string sentenceInput = Console.ReadLine();
        string[] wordsArray = sentenceInput.Split(' ');
        Console.WriteLine(string.Join(", ", wordsArray.Take(10)));
    }
}
