using System;
using System.Collections.Generic;
using System.Linq;
class CountryDictionary
{
    private Dictionary<string, string> engToRus;
    private Dictionary<string, string> rusToEng;

    public CountryDictionary()
    {
        engToRus = new Dictionary<string, string>
        {
            {"Russia", "Россия"},
            {"USA", "США"},
            {"Germany", "Германия"},
            {"France", "Франция"},
            {"Italy", "Италия"}
        };

        rusToEng = new Dictionary<string, string>
        {
            {"Россия", "Russia"},
            {"США", "USA"},
            {"Германия", "Germany"},
            {"Франция", "France"},
            {"Италия", "Italy"}
        };
    }

    public string Translate(string word, bool fromEnglish)
    {
        if (fromEnglish)
        {
            return engToRus.TryGetValue(word, out string translation) ? translation : "Перевод не найден";
        }
        else
        {
            return rusToEng.TryGetValue(word, out string translation) ? translation : "Translation not found";
        }
    }
}
class Point2D<T>
{
    public T X { get; set; }
    public T Y { get; set; }

    public Point2D(T x, T y)
    {
        X = x;
        Y = y;
    }

    public override string ToString()
    {
        return $"({X}, {Y})";
    }
}

class Point3D : Point2D<int>
{
    public int Z { get; set; }

    public Point3D(int x, int y, int z) : base(x, y)
    {
        Z = z;
    }

    public override string ToString()
    {
        return $"({X}, {Y}, {Z})";
    }
}
class Line<T>
{
    public Point2D<T> Point1 { get; set; }
    public Point2D<T> Point2 { get; set; }

    public Line(Point2D<T> point1, Point2D<T> point2)
    {
        Point1 = point1;
        Point2 = point2;
    }

    public Line(T x1, T y1, T x2, T y2)
    {
        Point1 = new Point2D<T>(x1, y1);
        Point2 = new Point2D<T>(x2, y2);
    }

    public override string ToString()
    {
        return $"Линия проходит через точки {Point1} и {Point2}";
    }
}
class WordCounter
{
    public static Dictionary<string, int> CountWords(string text)
    {
        var words = text.ToLower()
                       .Split(new[] { ' ', '.', ',', '!', '?', ';', ':', '-', '\n', '\r' }, 
                             StringSplitOptions.RemoveEmptyEntries);
        
        var wordCount = new Dictionary<string, int>();
        
        foreach (var word in words)
        {
            if (wordCount.ContainsKey(word))
            {
                wordCount[word]++;
            }
            else
            {
                wordCount[word] = 1;
            }
        }
        
        return wordCount;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Задание 1: Словарь стран");
        var dictionary = new CountryDictionary();
        Console.WriteLine(dictionary.Translate("Russia", true));
        Console.WriteLine(dictionary.Translate("Россия", false));
        Console.WriteLine();

        Console.WriteLine("Задание 2: Точка в 3D пространстве");
        var point3D = new Point3D(1, 2, 3);
        Console.WriteLine(point3D);
        Console.WriteLine();

        Console.WriteLine("Задание 3: Прямая на плоскости");
        var line1 = new Line<int>(new Point2D<int>(0, 0), new Point2D<int>(1, 1));
        var line2 = new Line<double>(0.0, 0.0, 1.0, 1.0);
        Console.WriteLine(line1);
        Console.WriteLine(line2);
        Console.WriteLine();

        Console.WriteLine("Задание 4: Подсчет слов в тексте");
        string text = "Hello world! Hello C#! World is beautiful.";
        var wordCount = WordCounter.CountWords(text);
        foreach (var pair in wordCount)
        {
            Console.WriteLine($"{pair.Key}: {pair.Value}");
        }
    }
}
