using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int[,] matrix = {
            { 1, -2, 0 },
            { -4, 5, -6 },
            { 0, 8, 9 }
        };
        int positiveCount = 0, negativeCount = 0;
        Console.WriteLine("Координаты нулевых элементов:");
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] > 0) positiveCount++;
                else if (matrix[i, j] < 0) negativeCount++;
                else Console.WriteLine($"({i}, {j})");
            }
        }
        Console.WriteLine($"Положительных: {positiveCount}, Отрицательных: {negativeCount}\n");
        
        string firstWord = "Программирование";
        string secondWord = "Код";
        secondWord = firstWord.Substring(0, secondWord.Length);
        Console.WriteLine("Новое второе слово: " + secondWord + "\n");
        
        string sentence = "Анна написала длинное сочинение.";
        var nnMatches = System.Text.RegularExpressions.Regex.Matches(sentence, "нн");
        Console.WriteLine("Буквосочетания 'нн' найдены: " + nnMatches.Count + " раз\n");
        
        string text = "Текст с разными буквами";
        int lastS = text.LastIndexOf('с');
        int lastT = text.LastIndexOf('Т');
        Console.WriteLine(lastS > lastT ? "'с' встречается позже." : "'Т' встречается позже." + "\n");
        
        string checkText = "ааааабвгд";
        bool hasFiveInRow = System.Text.RegularExpressions.Regex.IsMatch(checkText, "(.)\\1{4}");
        Console.WriteLine(hasFiveInRow ? "Есть пять подряд одинаковых символов." : "Нет пяти подряд одинаковых символов.");
    }
}