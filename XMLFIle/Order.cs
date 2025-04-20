using System;
using System.Collections.Generic;

public class Order
{
    public int OrderId { get; set; }
    public DateTime OrderDate { get; set; }
    public string CustomerName { get; set; }
    public List<Product> Products { get; set; }
    public decimal TotalAmount { get; set; }

    public Order()
    {
        Products = new List<Product>();
    }
} 