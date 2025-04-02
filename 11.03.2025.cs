using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public enum Frequency { Weekly, Monthly, Yearly }
public interface IRateAndCopy { double Rating { get; } object DeepCopy(); }

public class Person
{
    public string Name { get; set; }
    public Person(string name) => Name = name;
    public override bool Equals(object obj) => obj is Person p && p.Name == Name;
    public override int GetHashCode() => Name.GetHashCode();
    public virtual object DeepCopy() => new Person(Name);
}

public class Article : IRateAndCopy
{
    public Person Author { get; set; }
    public string Title { get; set; }
    public double Rating { get; set; }

    public Article(Person author, string title, double rating) => (Author, Title, Rating) = (author, title, rating);
    public override string ToString() => $"{Author.Name}, {Title}, Rating: {Rating}";
    public object DeepCopy() => new Article((Person)Author.DeepCopy(), Title, Rating);
}

public class Edition
{
    protected string Name;
    protected DateTime ReleaseDate;
    protected int Copies;
    
    public Edition(string name, DateTime date, int copies) => (Name, ReleaseDate, Copies) = (name, date, copies);
    public int CopiesCount {
        get => Copies;
        set { if (value < 0) throw new ArgumentException("Copies must be non-negative"); Copies = value; }
    }
    public override bool Equals(object obj) => obj is Edition e && e.Name == Name && e.ReleaseDate == ReleaseDate && e.Copies == Copies;
    public override int GetHashCode() => HashCode.Combine(Name, ReleaseDate, Copies);
    public virtual object DeepCopy() => new Edition(Name, ReleaseDate, Copies);
}

public class Magazine : Edition, IRateAndCopy, IEnumerable
{
    private Frequency Periodicity;
    private ArrayList Editors = new();
    private ArrayList Articles = new();

    public Magazine(string name, Frequency freq, DateTime date, int copies) : base(name, date, copies) => Periodicity = freq;
    public void AddArticles(params Article[] articles) => Articles.AddRange(articles);
    public void AddEditors(params Person[] editors) => Editors.AddRange(editors);
    public double Rating => Articles.Count > 0 ? Articles.Cast<Article>().Average(a => a.Rating) : 0;
    public object DeepCopy()
    {
        Magazine copy = new(Name, Periodicity, ReleaseDate, Copies);
        copy.Editors.AddRange(Editors.Cast<Person>().Select(e => (Person)e.DeepCopy()));
        copy.Articles.AddRange(Articles.Cast<Article>().Select(a => (Article)a.DeepCopy()));
        return copy;
    }
    public override string ToString() => $"{Name}, {Periodicity}, {ReleaseDate}, Copies: {Copies}, Rating: {Rating}\nArticles: {string.Join(", ", Articles.Cast<Article>())}";
    public IEnumerator GetEnumerator() => Articles.Cast<Article>().Where(a => !Editors.Contains(a.Author)).GetEnumerator();
}

public class CountAndSay
{
    public static string GetSequence(int n)
    {
        if (n == 1) return "1";
        string prev = GetSequence(n - 1);
        string result = "";
        int count = 1;
        for (int i = 1; i <= prev.Length; i++)
        {
            if (i == prev.Length || prev[i] != prev[i - 1])
            {
                result += count.ToString() + prev[i - 1];
                count = 1;
            }
            else count++;
        }
        return result;
    }
}

public class Program
{
    public static void Main()
    {
        Magazine mag = new("Tech Weekly", Frequency.Weekly, DateTime.Now, 5000);
        mag.AddEditors(new Person("John Doe"));
        mag.AddArticles(new Article(new Person("Alice"), "AI Revolution", 4.5), new Article(new Person("Bob"), "Quantum Computing", 3.8));
        Console.WriteLine(mag);
        
        Magazine copy = (Magazine)mag.DeepCopy();
        Console.WriteLine("Deep Copy:\n" + copy);
        
        Console.WriteLine("Count and Say sequence for n=5: " + CountAndSay.GetSequence(5));
    }
}

