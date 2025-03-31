using System;
using System.Linq;
using System.Collections.Generic;

namespace NumberGenerators
{
    class EvenNumbers
    {
        public static IEnumerable<int> Generate(int limit)
        {
            for (int i = 0; i <= limit; i += 2)
                yield return i;
        }
    }
    
    class OddNumbers
    {
        public static IEnumerable<int> Generate(int limit)
        {
            for (int i = 1; i <= limit; i += 2)
                yield return i;
        }
    }
    
    class PrimeNumbers
    {
        public static IEnumerable<int> Generate(int limit)
        {
            return Enumerable.Range(2, limit - 1).Where(IsPrime);
        }
        
        private static bool IsPrime(int number)
        {
            if (number < 2) return false;
            for (int i = 2; i * i <= number; i++)
                if (number % i == 0) return false;
            return true;
        }
    }
    
    class FibonacciNumbers
    {
        public static IEnumerable<int> Generate(int limit)
        {
            int a = 0, b = 1;
            while (a <= limit)
            {
                yield return a;
                int temp = a;
                a = b;
                b = temp + b;
            }
        }
    }
}

namespace Shapes
{
    class Triangle
    {
        public void Draw() => Console.WriteLine("Рисуем треугольник");
    }
    
    class Rectangle
    {
        public void Draw() => Console.WriteLine("Рисуем прямоугольник");
    }
    
    class Square
    {
        public void Draw() => Console.WriteLine("Рисуем квадрат");
    }
}

namespace GuessNumberGame
{
    class Game
    {
        public static void Start(int min, int max)
        {
            Random rand = new Random();
            int guess;
            int low = min, high = max;
            string response;
            do
            {
                guess = (low + high) / 2;
                Console.WriteLine($"Ваше число {guess}? (меньше/больше/да)");
                response = Console.ReadLine();
                if (response == "меньше") high = guess - 1;
                else if (response == "больше") low = guess + 1;
            } while (response != "да");
            Console.WriteLine("Компьютер угадал число!");
        }
    }
}

namespace ProductManagement
{
    class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
    }
    
    class HouseholdChemicals : Product { }
    class FoodProducts : Product { }
    
    class InventoryManager
    {
        public void Receive(Product product) => Console.WriteLine($"Получен товар: {product.Name}");
        public void Sell(Product product) => Console.WriteLine($"Продан товар: {product.Name}");
        public void WriteOff(Product product) => Console.WriteLine($"Списан товар: {product.Name}");
        public void Transfer(Product product) => Console.WriteLine($"Передан товар: {product.Name}");
    }
}

class Program
{
    static void Main()
    {
        foreach (var num in NumberGenerators.EvenNumbers.Generate(10))
            Console.Write(num + " ");
        Console.WriteLine();
        
        Shapes.Triangle triangle = new Shapes.Triangle();
        triangle.Draw();
        
        GuessNumberGame.Game.Start(1, 100);
        
        ProductManagement.InventoryManager manager = new ProductManagement.InventoryManager();
        ProductManagement.Product apple = new ProductManagement.FoodProducts { Name = "Яблоко", Price = 1.2 };
        manager.Receive(apple);
    }
}

