using System;

class Program
{
    static void Main()
    {
        // Задача 1
        Console.Write("Задача 1: Введите предложение: ");
        string sentence1 = Console.ReadLine();
        int wordCount = sentence1.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Length;
        Console.WriteLine($"Количество слов в предложении: {wordCount}");

        // Задача 2
        Console.Write("Задача 2: Введите предложение: ");
        string sentence2 = Console.ReadLine();
        string[] words = sentence2.Split(' ');
        for (int i = 0; i < words.Length; i++)
        {
            char[] wordArray = words[i].ToCharArray();
            Array.Reverse(wordArray);
            words[i] = new string(wordArray);
        }
        Console.WriteLine("После переворота каждого слова: " + string.Join(" ", words));

        // Задача 3
        Console.Write("Задача 3: Введите предложение: ");
        string sentence3 = Console.ReadLine();
        int vowelCount = 0;
        string vowels = "aeiouAEIOU";
        foreach (char c in sentence3)
        {
            if (vowels.Contains(c))
            {
                vowelCount++;
            }
        }
        Console.WriteLine($"Количество гласных букв: {vowelCount}");

        // Задача 4
        Console.Write("Задача 4: Введите исходную строку: ");
        string sourceString = Console.ReadLine();
        Console.Write("Введите подстроку для поиска: ");
        string substring = Console.ReadLine();
        int occurrenceCount = 0;
        int index = 0;
        while ((index = sourceString.IndexOf(substring, index)) != -1)
        {
            occurrenceCount++;
            index += substring.Length;
        }
        Console.WriteLine($"Количество вхождений подстроки: {occurrenceCount}");

        // Задача 5
        Console.Write("Задача 5: Введите предложение: ");
        string sentence5 = Console.ReadLine();
        int maxSpaces = 0, currentSpaces = 0;
        foreach (char c in sentence5)
        {
            if (c == ' ')
            {
                currentSpaces++;
                if (currentSpaces > maxSpaces)
                    maxSpaces = currentSpaces;
            }
            else
            {
                currentSpaces = 0;
            }
        }
        Console.WriteLine($"Наибольшее количество идущих подряд пробелов: {maxSpaces}");

        // Задача 6
        Console.Write("Задача 6: Введите текст: ");
        string text6 = Console.ReadLine();
        int maxRepeatedChars = 1, currentCount = 1;
        for (int i = 1; i < text6.Length; i++)
        {
            if (text6[i] == text6[i - 1])
            {
                currentCount++;
                if (currentCount > maxRepeatedChars)
                    maxRepeatedChars = currentCount;
            }
            else
            {
                currentCount = 1;
            }
        }
        Console.WriteLine($"Наибольшее количество подряд одинаковых символов: {maxRepeatedChars}");

        // Задача 7
        Console.Write("Задача 7: Введите слово: ");
        string word7 = Console.ReadLine();
        var distinctLetters = new HashSet<char>(word7.ToLower());
        Console.WriteLine($"Количество различных букв в слове: {distinctLetters.Count}");

        // Задача 8
        Console.Write("Задача 8: Введите слово: ");
        string word8 = Console.ReadLine();
        var letterCounts = new Dictionary<char, int>();
        foreach (char letter in word8)
        {
            if (letterCounts.ContainsKey(letter))
                letterCounts[letter]++;
            else
                letterCounts[letter] = 1;
        }
        var repeatedLetters = letterCounts.Where(x => x.Value == 2).Select(x => x.Key);
        Console.WriteLine($"Буквы, которые встречаются дважды: {string.Join(", ", repeatedLetters)}");
    }
}
