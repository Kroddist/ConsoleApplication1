using System;
using System.Collections.Generic;
using System.Linq;

abstract class Edition
{
    public string Title { get; set; }
    public string Author { get; set; }
    public abstract void Display();
    public bool IsAuthor(string name) => Author.Equals(name, StringComparison.OrdinalIgnoreCase);
}

class Book : Edition
{
    public int Year { get; set; }
    public string Publisher { get; set; }
    public override void Display() => Console.WriteLine($"Книга: {Title}, Автор: {Author}, Год: {Year}, Издательство: {Publisher}");
}

class Article : Edition
{
    public string Journal { get; set; }
    public int Number { get; set; }
    public int Year { get; set; }
    public override void Display() => Console.WriteLine($"Статья: {Title}, Автор: {Author}, Журнал: {Journal}, Номер: {Number}, Год: {Year}");
}

class Ebook : Edition
{
    public string Link { get; set; }
    public string Annotation { get; set; }
    public override void Display() => Console.WriteLine($"Электронный ресурс: {Title}, Автор: {Author}, Ссылка: {Link}, Аннотация: {Annotation}");
}

abstract class BaseArray
{
    protected int[] array;
    public BaseArray(int size) => array = new int[size];
    public int Size => array.Length;
    public abstract void Display();
    public int this[int index] { get => array[index]; set => array[index] = value; }
}

class DerivedArray : BaseArray
{
    public DerivedArray(int size) : base(size) { }
    public override void Display() => Console.WriteLine(string.Join(", ", array));
}

abstract class Figure : IComparable<Figure>
{
    public abstract double Area();
    public abstract double Perimeter();
    public abstract void Display();
    public int CompareTo(Figure other) => Area().CompareTo(other.Area());
}

class Rectangle : Figure
{
    public double Width { get; set; }
    public double Height { get; set; }
    public override double Area() => Width * Height;
    public override double Perimeter() => 2 * (Width + Height);
    public override void Display() => Console.WriteLine($"Прямоугольник: {Width}x{Height}, Площадь: {Area()}, Периметр: {Perimeter()}");
}

class Circle : Figure
{
    public double Radius { get; set; }
    public override double Area() => Math.PI * Radius * Radius;
    public override double Perimeter() => 2 * Math.PI * Radius;
    public override void Display() => Console.WriteLine($"Круг: Радиус {Radius}, Площадь: {Area()}, Периметр: {Perimeter()}");
}

class Triangle : Figure
{
    public double A { get; set; }
    public double B { get; set; }
    public double C { get; set; }
    public override double Area()
    {
        double s = Perimeter() / 2;
        return Math.Sqrt(s * (s - A) * (s - B) * (s - C));
    }
    public override double Perimeter() => A + B + C;
    public override void Display() => Console.WriteLine($"Треугольник: {A}, {B}, {C}, Площадь: {Area()}, Периметр: {Perimeter()}");
}

abstract class Function : IComparable<Function>
{
    public abstract double Compute(double x);
    public abstract void Display();
    public abstract double CoefficientA { get; }
    public int CompareTo(Function other) => CoefficientA.CompareTo(other.CoefficientA);
}

class Line : Function
{
    public double A { get; set; }
    public double B { get; set; }
    public override double Compute(double x) => A * x + B;
    public override void Display() => Console.WriteLine($"Линия: y = {A}x + {B}");
    public override double CoefficientA => A;
}

class Kub : Function
{
    public double A { get; set; }
    public double B { get; set; }
    public double C { get; set; }
    public override double Compute(double x) => A * x * x * x + B * x + C;
    public override void Display() => Console.WriteLine($"Кубическая функция: y = {A}x^3 + {B}x + {C}");
    public override double CoefficientA => A;
}

class Hyperbola : Function
{
    public double A { get; set; }
    public override double Compute(double x) => x == 0 ? double.NaN : A / x;
    public override void Display() => Console.WriteLine($"Гипербола: y = {A}/x");
    public override double CoefficientA => A;
}

class Program
{
    static void Main()
    {
        List<Edition> catalog = new List<Edition>
        {
            new Book { Title = "Book1", Author = "Author1", Year = 2020, Publisher = "Pub1" },
            new Article { Title = "Article1", Author = "Author2", Journal = "Journal1", Number = 1, Year = 2021 },
            new Ebook { Title = "Ebook1", Author = "Author1", Link = "http://example.com", Annotation = "Annotation1" }
        };
        catalog.ForEach(e => e.Display());
        Console.WriteLine("Поиск по автору Author1:");
        catalog.Where(e => e.IsAuthor("Author1")).ToList().ForEach(e => e.Display());

        DerivedArray arr = new DerivedArray(5);
        arr[0] = 10; arr[1] = 20;
        arr.Display();

        List<Figure> figures = new List<Figure>
        {
            new Rectangle { Width = 4, Height = 5 },
            new Circle { Radius = 3 },
            new Triangle { A = 3, B = 4, C = 5 }
        };
        figures.ForEach(f => f.Display());

        List<Function> functions = new List<Function>
        {
            new Line { A = 2, B = 3 },
            new Kub { A = 1, B = 0, C = -5 },
            new Hyperbola { A = 4 }
        };
        functions.ForEach(f => f.Display());
    }
}
