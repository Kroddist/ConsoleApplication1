using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

class Journal
{
    public int Employees { get; set; }
    public Journal(int employees) => Employees = employees;
    public static Journal operator +(Journal j, int value) => new Journal(j.Employees + value);
    public static Journal operator -(Journal j, int value) => new Journal(j.Employees - value);
    public static bool operator ==(Journal j1, Journal j2) => j1.Employees == j2.Employees;
    public static bool operator !=(Journal j1, Journal j2) => j1.Employees != j2.Employees;
    public static bool operator <(Journal j1, Journal j2) => j1.Employees < j2.Employees;
    public static bool operator >(Journal j1, Journal j2) => j1.Employees > j2.Employees;
    public override bool Equals(object obj) => obj is Journal j && Employees == j.Employees;
    public override int GetHashCode() => Employees.GetHashCode();
}

class Shop
{
    public double Area { get; set; }
    public Shop(double area) => Area = area;
    public static Shop operator +(Shop s, double value) => new Shop(s.Area + value);
    public static Shop operator -(Shop s, double value) => new Shop(s.Area - value);
    public static bool operator ==(Shop s1, Shop s2) => s1.Area == s2.Area;
    public static bool operator !=(Shop s1, Shop s2) => s1.Area != s2.Area;
    public static bool operator <(Shop s1, Shop s2) => s1.Area < s2.Area;
    public static bool operator >(Shop s1, Shop s2) => s1.Area > s2.Area;
    public override bool Equals(object obj) => obj is Shop s && Area == s.Area;
    public override int GetHashCode() => Area.GetHashCode();
}

class BookList
{
    private List<string> books = new List<string>();
    public void Add(string book) => books.Add(book);
    public void Remove(string book) => books.Remove(book);
    public bool Contains(string book) => books.Contains(book);
    public string this[int index] => books[index];
}

class Program
{
    static void Main()
    {
        try
        {
            string expression = Console.ReadLine();
            Console.WriteLine(expression.Split('*').Select(int.Parse).Aggregate((a, b) => a * b));
        }
        catch { Console.WriteLine("Ошибка ввода"); }

        try
        {
            string input = Console.ReadLine();
            Console.WriteLine(int.Parse(input));
        }
        catch { Console.WriteLine("Выход за пределы int"); }

        int size = int.Parse(Console.ReadLine());
        char symbol = Console.ReadKey().KeyChar;
        for (int i = 0; i < size; i++)
            Console.WriteLine(new string(symbol, size));

        int number = int.Parse(Console.ReadLine());
        Console.WriteLine(number.ToString() == new string(number.ToString().Reverse().ToArray()));

        try
        {
            int num = int.Parse(Console.ReadLine());
            Console.WriteLine(Convert.ToString(num, 2));
        }
        catch { Console.WriteLine("Ошибка перевода"); }
    }
}
