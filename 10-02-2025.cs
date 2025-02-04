using System;

class Program
{
    static void Main()
    {
        int x = 1, y = 2;
        Console.WriteLine("Задание 1:");
        Console.WriteLine($"а) {x < 2 && y < 3}");     // true
        Console.WriteLine($"б) {!(x < 2)}");           // false
        Console.WriteLine($"в) {x < 1 || y < 2}");     // false
        Console.WriteLine($"г) {!(x < 0 && x < 5)}");  // true
        Console.WriteLine($"д) {x < 0 && y > 5}");     // false
        Console.WriteLine($"е) {x > 10 && x < 20}");   // false
        Console.WriteLine($"ж) {x > 3 || x < 1}");     // true
        Console.WriteLine($"з) {y > 0 && y < 4 && x < 5}"); // true
        Console.WriteLine($"и) {x > 3 && x < 10}\n");  // false

        int X = 3, Y = 5, Z = 10;
        Console.WriteLine("Задание 2:");
        Console.WriteLine($"а) {X % 2 != 0 && Y % 2 != 0}");   // true
        Console.WriteLine($"б) {(X < 20) ^ (Y < 20)}");        // false
        Console.WriteLine($"в) {X == 0 || Y == 0}");           // false
        Console.WriteLine($"г) {X < 0 && Y < 0 && Z < 0}");    // false
        Console.WriteLine($"д) {(X%5==0?1:0)+(Y%5==0?1:0)+(Z%5==0?1:0) == 1}"); // true
        Console.WriteLine($"е) {X > 100 || Y > 100 || Z > 100}\n"); // false

        double x3 = 1.5;
        Console.WriteLine("Задание 3:");
        Console.WriteLine($"y = {(x3 > 0 ? Math.Sin(x3) : Math.Cos(x3))}\n"); // 0.997...

        int a = 3, b = 9;
        Console.WriteLine("Задание 4:");
        Console.WriteLine($"{a} {(b % a == 0 ? "является" : "не является")} делителем {b}\n"); // является

        int num = 27;
        Console.WriteLine("Задание 5:");
        Console.WriteLine($"а) {num % 2 == 0}");    // false
        Console.WriteLine($"б) {num % 10 == 7}\n"); // true

        double km = 2, feet = 6000;
        Console.WriteLine("Задание 6:");
        Console.WriteLine($"{(km*1000 < feet*0.305 ? "Километровое" : "Футовое")} расстояние меньше\n"); // Футовое

        double a7 = 1, b7 = -4, c7 = 4;
        Console.WriteLine("Задание 7:");
        Console.WriteLine($"{(b7*b7 - 4*a7*c7 >= 0 ? "Имеет" : "Не имеет")} вещественные корни\n"); // Имеет

        double circleArea = 10, squareArea = 20;
        Console.WriteLine("Задание 8:");
        Console.WriteLine($"а) Круг в квадрате: {2*Math.Sqrt(circleArea/Math.PI) <= Math.Sqrt(squareArea)}"); // false
        Console.WriteLine($"б) Квадрат в круге: {Math.Sqrt(squareArea)*Math.Sqrt(2) <= 2*Math.Sqrt(circleArea/Math.PI)}\n"); // true

        Console.WriteLine("Задание 9:");
        Console.Write("Введите число: ");
        double input = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine($"Принадлежит интервалу (-5, 3): {input > -5 && input < 3}\n");

        double a10 = 5, b10 = 5, c10 = 5;
        Console.WriteLine("Задание 10:");
        Console.WriteLine($"Треугольник {(a10 == b10 && b10 == c10 ? "равносторонний" : "не равносторонний")}");
    }
}