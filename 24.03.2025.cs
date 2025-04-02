using System;
using System.Text;
using System.Collections.Generic;

namespace Geometry
{
    abstract class Shape
    {
        public abstract void Draw();
    }
    
    class Triangle : Shape
    {
        public override void Draw() => Console.WriteLine("Рисуем треугольник");
    }
    
    class Rectangle : Shape
    {
        public override void Draw() => Console.WriteLine("Рисуем прямоугольник");
    }
    
    class Square : Shape
    {
        public override void Draw() => Console.WriteLine("Рисуем квадрат");
    }
}

namespace Game
{
    class GuessNumber
    {
        public void Play()
        {
            Console.Write("Введите загаданное число: ");
            int secretNumber = int.Parse(Console.ReadLine());
            int low = 1, high = 100, guess;
            
            while (true)
            {
                guess = (low + high) / 2;
                Console.WriteLine($"Компьютер предполагает: {guess}");
                
                if (guess == secretNumber)
                {
                    Console.WriteLine("Компьютер угадал!");
                    break;
                }
                else if (guess > secretNumber)
                    high = guess - 1;
                else
                    low = guess + 1;
            }
        }
    }
}

namespace TextGenerator
{
    class PseudoText
    {
        private static Random random = new Random();
        public string Generate(int vowels, int consonants, int maxWordLength)
        {
            string vowelSet = "аеёиоуыэюя";
            string consonantSet = "бвгджзйклмнпрстфхцчшщ";
            StringBuilder text = new StringBuilder();
            
            for (int i = 0; i < vowels + consonants; i++)
            {
                int wordLength = random.Next(1, maxWordLength + 1);
                for (int j = 0; j < wordLength; j++)
                {
                    if (random.Next(2) == 0 && vowels > 0)
                    {
                        text.Append(vowelSet[random.Next(vowelSet.Length)]);
                        vowels--;
                    }
                    else if (consonants > 0)
                    {
                        text.Append(consonantSet[random.Next(consonantSet.Length)]);
                        consonants--;
                    }
                }
                text.Append(' ');
            }
            return text.ToString();
        }
    }
}

namespace Financial
{
    class Money
    {
        public int Rubles { get; private set; }
        public int Kopecks { get; private set; }

        public Money(int rubles, int kopecks)
        {
            Rubles = rubles + kopecks / 100;
            Kopecks = kopecks % 100;
            if (Rubles < 0 || Kopecks < 0) throw new Exception("Банкрот");
        }

        public static Money operator +(Money a, Money b) => new Money(a.Rubles + b.Rubles, a.Kopecks + b.Kopecks);
        public static Money operator -(Money a, Money b)
        {
            int totalA = a.Rubles * 100 + a.Kopecks;
            int totalB = b.Rubles * 100 + b.Kopecks;
            if (totalA < totalB) throw new Exception("Банкрот");
            return new Money(0, totalA - totalB);
        }
        public static Money operator *(Money a, int factor) => new Money(a.Rubles * factor, a.Kopecks * factor);
        public static Money operator /(Money a, int divisor) => new Money(a.Rubles / divisor, a.Kopecks / divisor);
        public static Money operator ++(Money a) => new Money(a.Rubles, a.Kopecks + 1);
        public static Money operator --(Money a) => a.Kopecks == 0 ? new Money(a.Rubles - 1, 99) : new Money(a.Rubles, a.Kopecks - 1);
        public static bool operator <(Money a, Money b) => (a.Rubles * 100 + a.Kopecks) < (b.Rubles * 100 + b.Kopecks);
        public static bool operator >(Money a, Money b) => (a.Rubles * 100 + a.Kopecks) > (b.Rubles * 100 + b.Kopecks);
        public static bool operator ==(Money a, Money b) => a.Rubles == b.Rubles && a.Kopecks == b.Kopecks;
        public static bool operator !=(Money a, Money b) => !(a == b);

        public override string ToString() => $"{Rubles} руб. {Kopecks} коп.";
    }
}

class Program
{
    static void Main()
    {
        Geometry.Shape triangle = new Geometry.Triangle();
        Geometry.Shape rectangle = new Geometry.Rectangle();
        Geometry.Shape square = new Geometry.Square();
        triangle.Draw();
        rectangle.Draw();
        square.Draw();
        
        Game.GuessNumber game = new Game.GuessNumber();
        game.Play();
        
        TextGenerator.PseudoText generator = new TextGenerator.PseudoText();
        Console.WriteLine(generator.Generate(5, 5, 7));
        
        Financial.Money money1 = new Financial.Money(10, 50);
        Financial.Money money2 = new Financial.Money(5, 75);
        Console.WriteLine(money1 + money2);
    }
}