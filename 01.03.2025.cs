using System;
using System.Collections.Generic;

enum ArticleType { Electronics, Clothing, Food, Household }
struct Article
{
    public int Code;
    public string Name;
    public double Price;
    public ArticleType Type;
}

enum ClientType { Regular, VIP, Wholesale }
struct Client
{
    public int Code;
    public string FullName;
    public string Address;
    public string Phone;
    public int OrderCount;
    public double TotalOrderSum;
    public ClientType Type;
}

struct RequestItem
{
    public Article Product;
    public int Quantity;
}

enum PayType { Cash, CreditCard, BankTransfer }
struct Request
{
    public int OrderCode;
    public Client Customer;
    public DateTime OrderDate;
    public List<RequestItem> Items;
    public PayType PaymentType;
    public double TotalSum => CalculateTotalSum();
    private double CalculateTotalSum()
    {
        double sum = 0;
        foreach (var item in Items)
            sum += item.Product.Price * item.Quantity;
        return sum;
    }
}

class Student
{
    public string FirstName;
    public string LastName;
    public string MiddleName;
    public string Group;
    public int Age;
    public int[][] Grades;
    public void SetGrade(int subjectIndex, int[] grades) => Grades[subjectIndex] = grades;
    public double GetAverageGrade(int subjectIndex) => Grades[subjectIndex].Length == 0 ? 0 : (double)Grades[subjectIndex].Sum() / Grades[subjectIndex].Length;
    public void PrintInfo() => Console.WriteLine($"{LastName} {FirstName} {MiddleName}, Группа: {Group}, Возраст: {Age}");
}

namespace WondersOfTheWorld
{
    class Wonder { public string Name; public Wonder(string name) => Name = name; }
    class SevenWonders
    {
        public static void ShowWonders()
        {
            var wonders = new List<Wonder> { new Wonder("Great Wall of China"), new Wonder("Machu Picchu") };
            wonders.ForEach(w => Console.WriteLine(w.Name));
        }
    }
}

namespace CountryPopulation
{
    namespace Russia { class Moscow { public int Population = 12600000; } }
    namespace USA { class Washington { public int Population = 692000; } }
    namespace UK { class London { public int Population = 8982000; } }
}

class Program
{
    static void Main()
    {
        WondersOfTheWorld.SevenWonders.ShowWonders();
        var moscow = new CountryPopulation.Russia.Moscow();
        var washington = new CountryPopulation.USA.Washington();
        var london = new CountryPopulation.UK.London();
        Console.WriteLine($"Москва: {moscow.Population}, Вашингтон: {washington.Population}, Лондон: {london.Population}");
    }
}
