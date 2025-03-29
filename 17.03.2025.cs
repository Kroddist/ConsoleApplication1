using System;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        City city = new City("Москва", "Россия", 12615882, "495", new List<string> { "ЦАО", "САО", "ЮАО" });
        city.DisplayInfo();
        
        Employee employee = new Employee("Иван Иванов", new DateTime(1985, 6, 15), "+79001234567", "ivanov@example.com", "Менеджер", "Управление проектами");
        employee.DisplayInfo();
        
        Airplane airplane = new Airplane("Boeing 747", "Boeing", 1998, "Пассажирский");
        airplane.DisplayInfo();
        
        Matrix matrix = new Matrix(new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } });
        matrix.DisplayInfo();
        Console.WriteLine("Максимум: " + matrix.GetMax());
        Console.WriteLine("Минимум: " + matrix.GetMin());
    }
}

class City
{
    private string Name;
    private string Country;
    private int Population;
    private string PhoneCode;
    private List<string> Districts;
    
    public City(string name, string country, int population, string phoneCode, List<string> districts)
    {
        Name = name;
        Country = country;
        Population = population;
        PhoneCode = phoneCode;
        Districts = districts;
    }
    
    public void DisplayInfo()
    {
        Console.WriteLine($"Город: {Name}, Страна: {Country}, Население: {Population}, Код: {PhoneCode}, Районы: {string.Join(", ", Districts)}");
    }
}

class Employee
{
    private string FullName;
    private DateTime BirthDate;
    private string Phone;
    private string Email;
    private string Position;
    private string Duties;
    
    public Employee(string fullName, DateTime birthDate, string phone, string email, string position, string duties)
    {
        FullName = fullName;
        BirthDate = birthDate;
        Phone = phone;
        Email = email;
        Position = position;
        Duties = duties;
    }
    
    public void DisplayInfo()
    {
        Console.WriteLine($"Сотрудник: {FullName}, Дата рождения: {BirthDate.ToShortDateString()}, Телефон: {Phone}, Email: {Email}, Должность: {Position}, Обязанности: {Duties}");
    }
}

class Airplane
{
    private string Name;
    private string Manufacturer;
    private int Year;
    private string Type;
    
    public Airplane(string name, string manufacturer, int year, string type)
    {
        Name = name;
        Manufacturer = manufacturer;
        Year = year;
        Type = type;
    }
    
    public void DisplayInfo()
    {
        Console.WriteLine($"Самолёт: {Name}, Производитель: {Manufacturer}, Год выпуска: {Year}, Тип: {Type}");
    }
}

class Matrix
{
    private int[,] Data;
    
    public Matrix(int[,] data)
    {
        Data = data;
    }
    
    public void DisplayInfo()
    {
        for (int i = 0; i < Data.GetLength(0); i++)
        {
            for (int j = 0; j < Data.GetLength(1); j++)
                Console.Write(Data[i, j] + " ");
            Console.WriteLine();
        }
    }
    
    public int GetMax()
    {
        return Data.Cast<int>().Max();
    }
    
    public int GetMin()
    {
        return Data.Cast<int>().Min();
    }
}
