using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Задание 1а. Введите x:");
        double x = Convert.ToDouble(Console.ReadLine());
        double y = 7 * Math.Pow(x, 2) + 3 * x + 6;
        Console.WriteLine($"y = {y}");

        Console.WriteLine("Задание 1б. Введите a:");
        double a = Convert.ToDouble(Console.ReadLine());
        double x_result = 12 * Math.Pow(a, 2) + 7 * a + 12;
        Console.WriteLine($"x = {x_result}\n");

        Console.WriteLine("Задание 2. Введите a и b:");
        double a2 = Convert.ToDouble(Console.ReadLine());
        double b2 = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine($"x = {-b2 / a2}\n");

        Console.WriteLine("Задание 3. Введите катеты:");
        double leg1 = Convert.ToDouble(Console.ReadLine());
        double leg2 = Convert.ToDouble(Console.ReadLine());
        double hypotenuse = Math.Sqrt(leg1 * leg1 + leg2 * leg2);
        Console.WriteLine($"Периметр: {leg1 + leg2 + hypotenuse}\n");

        Console.WriteLine("Задание 4. Введите основания и высоту:");
        double base1 = Convert.ToDouble(Console.ReadLine());
        double base2 = Convert.ToDouble(Console.ReadLine());
        double height = Convert.ToDouble(Console.ReadLine());
        double leg = Math.Sqrt(Math.Pow((base2 - base1) / 2, 2) + height * height);
        Console.WriteLine($"Периметр: {base1 + base2 + 2 * leg}\n");

        Console.WriteLine("Задание 5. Введите координаты вершин (x1 y1 x2 y2 x3 y3):");
        double x1 = Convert.ToDouble(Console.ReadLine());
        double y1 = Convert.ToDouble(Console.ReadLine());
        double x2 = Convert.ToDouble(Console.ReadLine());
        double y2 = Convert.ToDouble(Console.ReadLine());
        double x3 = Convert.ToDouble(Console.ReadLine());
        double y3 = Convert.ToDouble(Console.ReadLine());

        double sideA = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
        double sideB = Math.Sqrt(Math.Pow(x3 - x2, 2) + Math.Pow(y3 - y2, 2));
        double sideC = Math.Sqrt(Math.Pow(x1 - x3, 2) + Math.Pow(y1 - y3, 2));
        double perimeter = sideA + sideB + sideC;
        double semiPerimeter = perimeter / 2;
        double area = Math.Sqrt(semiPerimeter * (semiPerimeter - sideA) * (semiPerimeter - sideB) * (semiPerimeter - sideC));
        Console.WriteLine($"Периметр: {perimeter}\nПлощадь: {area}\n");

        int result = 237;
        int lastDigit = result / 100;
        int remaining = result % 100;
        int originalNumber = remaining * 10 + lastDigit;
        Console.WriteLine($"Задача 6. Исходное число: {originalNumber}\n");

        bool A = true, B = false, C = false;

        Console.WriteLine("Задание 7:");
        Console.WriteLine($"а) {A || B}");  
        Console.WriteLine($"б) {A && B}");
        Console.WriteLine($"в) {B || C}\n"); 

        Console.WriteLine("Задание 8:");
        Console.WriteLine($"а) {!A && B}");  
        Console.WriteLine($"б) {A || !B}");  
        Console.WriteLine($"в) {A && B || C}\n"); 

        Console.WriteLine("Задание 9:");
        Console.WriteLine($"а) {A || B && !C}");       
        Console.WriteLine($"б) {!A && !B}");        
        Console.WriteLine($"в) {!(A && C) || B}");    
        Console.WriteLine($"г) {A && !B || C}");     
        Console.WriteLine($"д) {A && (!B || C)}");   
        Console.WriteLine($"е) {A || (!(B && C))}\n"); 

        Console.WriteLine("Задача 10. Примеры выражений:");
        Console.WriteLine("а) (x < 2) && (y < 3)");
        Console.WriteLine("б) !(x < 2)");
        Console.WriteLine("в) (x < 1) || (y < 2)");
        Console.WriteLine("г) !(x < 0 && x < 5)");
        Console.WriteLine("д) (x < 0) && (y > 5)");
        Console.WriteLine("е) (x > 10) && (x < 20)");
        Console.WriteLine("ж) (x > 3) || (x < 1)");
        Console.WriteLine("з) (y > 0 && y < 4) && (x < 5)");
        Console.WriteLine("и) (x > 3) && (x < 10)");
    }
}