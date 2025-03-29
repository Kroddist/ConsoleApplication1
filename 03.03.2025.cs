using System;
using System.Collections.Generic;


abstract class GeometricFigure
{
    public abstract double GetArea();
    public abstract double GetPerimeter();
}


class Triangle : GeometricFigure
{
    private double a, b, c;
    public Triangle(double a, double b, double c)
    {
        this.a = a;
        this.b = b;
        this.c = c;
    }
    public override double GetArea()
    {
        double s = (a + b + c) / 2;
        return Math.Sqrt(s * (s - a) * (s - b) * (s - c));
    }
    public override double GetPerimeter() => a + b + c;
}

class Square : GeometricFigure
{
    private double side;
    public Square(double side) { this.side = side; }
    public override double GetArea() => side * side;
    public override double GetPerimeter() => 4 * side;
}

class Circle : GeometricFigure
{
    private double radius;
    public Circle(double radius) { this.radius = radius; }
    public override double GetArea() => Math.PI * radius * radius;
    public override double GetPerimeter() => 2 * Math.PI * radius;
}


class CompositeFigure
{
    private List<GeometricFigure> figures = new List<GeometricFigure>();
    public void AddFigure(GeometricFigure figure) => figures.Add(figure);
    public double GetTotalArea()
    {
        double totalArea = 0;
        foreach (var figure in figures) totalArea += figure.GetArea();
        return totalArea;
    }
}


class Car
{
    public string Brand { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public string Color { get; set; }
    public double EngineCapacity { get; set; }
    
    public Car(string brand, string model, int year, string color, double engineCapacity)
    {
        Brand = brand;
        Model = model;
        Year = year;
        Color = color;
        EngineCapacity = engineCapacity;
    }
    
    public override string ToString()
    {
        return $"Автомобиль: {Brand} {Model}, Год: {Year}, Цвет: {Color}, Объем двигателя: {EngineCapacity} л";
    }
}

class Program
{
    static void Main()
    {
        Triangle triangle = new Triangle(3, 4, 5);
        Square square = new Square(4);
        Circle circle = new Circle(5);
        
        CompositeFigure composite = new CompositeFigure();
        composite.AddFigure(triangle);
        composite.AddFigure(square);
        composite.AddFigure(circle);
        
        Console.WriteLine("Общая площадь составной фигуры: " + composite.GetTotalArea());
        
        Car myCar = new Car("Toyota", "Camry", 2020, "Черный", 2.5);
        Console.WriteLine(myCar);
    }
}
