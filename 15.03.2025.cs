using System;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int MultiplyRange(int start, int end)
        {
            int result = 1;
            for (int i = start; i <= end; i++)
                result *= i;
            return result;
        }
        Console.WriteLine("Произведение чисел от 2 до 5: " + MultiplyRange(2, 5));
        
        City city = new City("Москва", "Россия", 12615882, "495", new List<string> { "ЦАО", "САО", "ЮАО" });
        city.DisplayInfo();
        
        Employee employee = new Employee("Иван Иванов", new DateTime(1985, 6, 15), "+79001234567", "ivanov@example.com", "Менеджер", "Управление проектами");
        employee.DisplayInfo();
        
        string sentence = "Сегодня хороший день";
        int minWordLength = sentence.Split(' ').Min(w => w.Length);
        Console.WriteLine("Длина самого короткого слова: " + minWordLength);
        
        var words = sentence.Split(' ');
        var uniqueWords = words.Where(w => words.Count(x => x == w) == 1);
        Console.WriteLine("Уникальные слова: " + string.Join(", ", uniqueWords));
    }
}

class City
{
    public string Name { get; set; }
    public string Country { get; set; }
    public int Population { get; set; }
    public string PhoneCode { get; set; }
    public List<string> Districts { get; set; }
    
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
    public string FullName { get; set; }
    public DateTime BirthDate { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Position { get; set; }
    public string Duties { get; set; }
    
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
