using System;
using System.Linq;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string s1 = "программирование";
        string s2 = new string(s1.Where((c, i) => i % 2 == 0).ToArray());
        Console.WriteLine("Слово s2: " + s2);
        
        string text = "Тест + текст + с * разными * символами+*+";
        int plusCount = text.Count(c => c == '+');
        int starCount = text.Count(c => c == '*');
        Console.WriteLine($"Символ '+' встречается {plusCount} раз, символ '*' - {starCount} раз");
        
        string sentence = "Это пример, текста с запятой.";
        int commaIndex = sentence.IndexOf(',');
        if (commaIndex != -1)
            Console.WriteLine("До первой запятой: " + sentence.Substring(0, commaIndex));
        else
            Console.WriteLine("Запятых нет");
        
        string sentence2 = "  Образование очень важно.".Trim();
        int firstSpace = sentence2.IndexOf(' ');
        string firstWord = firstSpace == -1 ? sentence2 : sentence2.Substring(0, firstSpace);
        int oCount = firstWord.Count(c => c == 'о' || c == 'О');
        Console.WriteLine("Количество 'о' в первом слове: " + oCount);
        
        string paragraph = "Это первое предложение. А это второе! И третье?";
        int sentenceCount = Regex.Matches(paragraph, "[.!?]").Count;
        Console.WriteLine("Количество предложений: " + sentenceCount);
        
        string sentence3 = "Летнее небо очень красивое.";
        string replacedE = sentence3.Replace('е', 'и');
        Console.WriteLine("Замененный текст: " + replacedE);
        
        string sentence4 = "Махаон - красивый бабочка.";
        string replacedAx = sentence4.Replace("ах", "ух");
        Console.WriteLine("Измененный текст: " + replacedAx);
        
        string word = "программирование";
        char[] wordArray = word.ToCharArray();
        Array.Reverse(wordArray, 2, 8);
        string newWord = new string(wordArray);
        Console.WriteLine("Новое слово: " + newWord);
    }
}
