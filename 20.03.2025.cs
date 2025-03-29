using System;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Website website = new Website("Example", "www.example.com", "Demo website", "192.168.1.1");
        website.DisplayInfo();
        
        Journal journal = new Journal("Наука и жизнь", 1922, "Научно-популярный журнал", "+7 495 123-45-67", "info@science-life.ru");
        journal.DisplayInfo();
        
        Store store = new Store("Tech Store", "ул. Ленина, 10", "Магазин электроники", "+7 495 987-65-43", "contact@techstore.ru");
        store.DisplayInfo();
    }
}

class Website
{
    private string Name;
    private string URL;
    private string Description;
    private string IP;
    
    public Website(string name, string url, string description, string ip)
    {
        Name = name;
        URL = url;
        Description = description;
        IP = ip;
    }
    
    public void DisplayInfo()
    {
        Console.WriteLine($"Сайт: {Name}, URL: {URL}, Описание: {Description}, IP: {IP}");
    }
}

class Journal
{
    private string Name;
    private int Year;
    private string Description;
    private string Phone;
    private string Email;
    
    public Journal(string name, int year, string description, string phone, string email)
    {
        Name = name;
        Year = year;
        Description = description;
        Phone = phone;
        Email = email;
    }
    
    public void DisplayInfo()
    {
        Console.WriteLine($"Журнал: {Name}, Год основания: {Year}, Описание: {Description}, Телефон: {Phone}, Email: {Email}");
    }
}

class Store
{
    private string Name;
    private string Address;
    private string Profile;
    private string Phone;
    private string Email;
    
    public Store(string name, string address, string profile, string phone, string email)
    {
        Name = name;
        Address = address;
        Profile = profile;
        Phone = phone;
        Email = email;
    }
    
    public void DisplayInfo()
    {
        Console.WriteLine($"Магазин: {Name}, Адрес: {Address}, Профиль: {Profile}, Телефон: {Phone}, Email: {Email}");
    }
}