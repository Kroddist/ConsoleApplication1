using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        string xmlFilePath = "orders.xml";
        var xmlManager = new XmlOrderManager(xmlFilePath);

        var orders = new List<Order>
        {
            new Order
            {
                OrderId = 1,
                OrderDate = DateTime.Now,
                CustomerName = "Иван Иванов",
                Products = new List<Product>
                {
                    new Product
                    {
                        ProductId = 1,
                        Name = "Ноутбук",
                        Price = 50000,
                        Quantity = 1,
                        Description = "Игровой ноутбук"
                    },
                    new Product
                    {
                        ProductId = 2,
                        Name = "Мышь",
                        Price = 1500,
                        Quantity = 2,
                        Description = "Игровая мышь"
                    }
                },
                TotalAmount = 53000
            }
        };

        xmlManager.SaveOrdersToXml(orders);
        Console.WriteLine("Заказы сохранены в XML файл");

        var loadedOrders = xmlManager.ReadOrdersFromXml();
        Console.WriteLine("\nЗагруженные заказы:");
        
        foreach (var order in loadedOrders)
        {
            Console.WriteLine($"\nЗаказ #{order.OrderId}");
            Console.WriteLine($"Дата: {order.OrderDate}");
            Console.WriteLine($"Клиент: {order.CustomerName}");
            Console.WriteLine($"Общая сумма: {order.TotalAmount}");
            Console.WriteLine("Товары:");
            
            foreach (var product in order.Products)
            {
                Console.WriteLine($"- {product.Name} (x{product.Quantity}) - {product.Price} руб.");
            }
        }

        Console.WriteLine("\nНажмите любую клавишу для выхода...");
        Console.ReadKey();
    }
}
