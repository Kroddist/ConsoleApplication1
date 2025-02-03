using System;

class Program
{
    static void Main()
    {
        Console.Write("Задача 1. Введите число: ");
        int num1 = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine($"Вы ввели число {num1}\n");

        Console.Write("Задача 2. Введите число: ");
        int num2 = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine($"{num2} - вот какое число Вы ввели\n");

        Console.Write("Задача 3. Введите длину стороны квадрата: ");
        double side = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine($"Периметр квадрата: {4 * side}\n");

        Console.Write("Задача 4. Введите радиус окружности: ");
        double radius = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine($"Диаметр окружности: {2 * radius}\n");

        Console.Write("Задача 5. Введите массу тела (кг): ");
        double mass = Convert.ToDouble(Console.ReadLine());
        Console.Write("Введите объем тела (м³): ");
        double volume = Convert.ToDouble(Console.ReadLine());
        if (volume == 0) Console.WriteLine("Ошибка: объем не может быть нулевым!");
        else Console.WriteLine($"Плотность материала: {mass / volume} кг/м³\n");

        Console.Write("Задача 6. Введите верхнее основание трапеции: ");
        double a = Convert.ToDouble(Console.ReadLine());
        Console.Write("Введите нижнее основание трапеции: ");
        double b = Convert.ToDouble(Console.ReadLine());
        Console.Write("Введите высоту трапеции: ");
        double h = Convert.ToDouble(Console.ReadLine());
        double leg = Math.Sqrt(Math.Pow((b - a)/2, 2) + Math.Pow(h, 2));
        Console.WriteLine($"Периметр трапеции: {a + b + 2 * leg}\n");

        Console.Write("Задача 7. Введите массу в килограммах: ");
        int kg = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine($"Полных тонн: {kg / 1000}\n");

        Console.Write("Задача 8. Введите расстояние в метрах: ");
        int meters = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine($"Полных километров: {meters / 1000}\n");

        Console.Write("Задача 9. Введите двузначное число: ");
        int twoDigit = Convert.ToInt32(Console.ReadLine());
        int tens = twoDigit / 10;
        int units = twoDigit % 10;
        Console.WriteLine($"а) Десятки: {tens}");
        Console.WriteLine($"б) Единицы: {units}");
        Console.WriteLine($"в) Сумма цифр: {tens + units}");
        Console.WriteLine($"г) Произведение цифр: {tens * units}\n");

        Console.Write("Задача 10. Введите трехзначное число: ");
        int threeDigit = Convert.ToInt32(Console.ReadLine());
        int reversed = (threeDigit % 10) * 100 + (threeDigit / 10 % 10) * 10 + threeDigit / 100;
        Console.WriteLine($"Обратное число: {reversed}");
    }
}