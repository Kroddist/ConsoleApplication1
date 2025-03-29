using System;

class Program
{
    static void Main()
    {
        try
        {
            Console.WriteLine("Введите три стороны треугольника:");
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());

            if (!IsValidTriangle(a, b, c))
            {
                Console.WriteLine("Треугольник с такими сторонами не существует.");
            }
            else
            {
                Console.WriteLine("Тип треугольника: " + GetTriangleType(a, b, c));
                Console.WriteLine("Периметр: " + GetPerimeter(a, b, c));
                Console.WriteLine("Площадь: " + GetArea(a, b, c));
            }

            Console.WriteLine("Введите число для проверки четности:");
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine(IsEven(number) ? "Число четное" : "Число нечетное");

            Console.WriteLine("Введите год для проверки на високосность:");
            int year = int.Parse(Console.ReadLine());
            Console.WriteLine(IsLeapYear(year) ? "Год високосный" : "Год не високосный");

            Console.WriteLine("Введите три числа для поиска максимального:");
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());
            Console.WriteLine("Максимальное число: " + GetMax(num1, num2, num3));

            Console.WriteLine("Введите коэффициенты квадратного уравнения (ax^2 + bx + c = 0):");
            double A = double.Parse(Console.ReadLine());
            double B = double.Parse(Console.ReadLine());
            double C = double.Parse(Console.ReadLine());
            SolveQuadraticEquation(A, B, C);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ошибка ввода: " + ex.Message);
        }
    }



    static bool IsValidTriangle(int a, int b, int c) => a > 0 && b > 0 && c > 0 && (a + b > c) && (a + c > b) && (b + c > a);
    static string GetTriangleType(int a, int b, int c) => a == b && b == c ? "Равносторонний" : a == b || b == c || a == c ? "Равнобедренный" : a * a + b * b == c * c || a * a + c * c == b * b || b * b + c * c == a * a ? "Прямоугольный" : a * a + b * b > c * c && a * a + c * c > b * b && b * b + c * c > a * a ? "Остроугольный" : "Тупоугольный";
    static int GetPerimeter(int a, int b, int c) => a + b + c;
    static double GetArea(int a, int b, int c) { double s = (a + b + c) / 2.0; return Math.Sqrt(s * (s - a) * (s - b) * (s - c)); }
    static bool IsEven(int number) => number % 2 == 0;
    static bool IsLeapYear(int year) => (year % 4 == 0 && year % 100 != 0) || (year % 400 == 0);
    static int GetMax(int x, int y, int z) => Math.Max(x, Math.Max(y, z));

    static void SolveQuadraticEquation(double a, double b, double c)
    {
        if (a == 0) { Console.WriteLine("Коэффициент a не может быть 0."); return; }
        double D = b * b - 4 * a * c;
        if (D > 0) { Console.WriteLine($"Два корня: x1 = {(-b + Math.Sqrt(D)) / (2 * a)}, x2 = {(-b - Math.Sqrt(D)) / (2 * a)}"); }
        else if (D == 0) { Console.WriteLine($"Один корень: x = {-b / (2 * a)}"); }
        else { Console.WriteLine("Нет действительных корней."); }
    }

}
