using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

public class XmlOrderManager
{
    private string _filePath;

    public XmlOrderManager(string filePath)
    {
        _filePath = filePath;
    }

    public void SaveOrdersToXml(List<Order> orders)
    {
        using (XmlTextWriter writer = new XmlTextWriter(_filePath, null))
        {
            writer.Formatting = Formatting.Indented;
            writer.WriteStartDocument();
            writer.WriteStartElement("Orders");

            foreach (var order in orders)
            {
                writer.WriteStartElement("Order");
                writer.WriteAttributeString("OrderId", order.OrderId.ToString());
                writer.WriteAttributeString("OrderDate", order.OrderDate.ToString("yyyy-MM-dd"));
                writer.WriteAttributeString("CustomerName", order.CustomerName);
                writer.WriteAttributeString("TotalAmount", order.TotalAmount.ToString());

                writer.WriteStartElement("Products");
                foreach (var product in order.Products)
                {
                    writer.WriteStartElement("Product");
                    writer.WriteAttributeString("ProductId", product.ProductId.ToString());
                    writer.WriteAttributeString("Name", product.Name);
                    writer.WriteAttributeString("Price", product.Price.ToString());
                    writer.WriteAttributeString("Quantity", product.Quantity.ToString());
                    writer.WriteAttributeString("Description", product.Description);
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
                writer.WriteEndElement();
            }

            writer.WriteEndElement();
            writer.WriteEndDocument();
        }
    }

    public List<Order> ReadOrdersFromXml()
    {
        List<Order> orders = new List<Order>();
        
        using (XmlTextReader reader = new XmlTextReader(_filePath))
        {
            Order currentOrder = null;
            Product currentProduct = null;

            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    switch (reader.Name)
                    {
                        case "Order":
                            currentOrder = new Order();
                            currentOrder.OrderId = int.Parse(reader.GetAttribute("OrderId"));
                            currentOrder.OrderDate = DateTime.Parse(reader.GetAttribute("OrderDate"));
                            currentOrder.CustomerName = reader.GetAttribute("CustomerName");
                            currentOrder.TotalAmount = decimal.Parse(reader.GetAttribute("TotalAmount"));
                            break;

                        case "Product":
                            currentProduct = new Product();
                            currentProduct.ProductId = int.Parse(reader.GetAttribute("ProductId"));
                            currentProduct.Name = reader.GetAttribute("Name");
                            currentProduct.Price = decimal.Parse(reader.GetAttribute("Price"));
                            currentProduct.Quantity = int.Parse(reader.GetAttribute("Quantity"));
                            currentProduct.Description = reader.GetAttribute("Description");
                            currentOrder.Products.Add(currentProduct);
                            break;
                    }
                }
                else if (reader.NodeType == XmlNodeType.EndElement && reader.Name == "Order")
                {
                    orders.Add(currentOrder);
                }
            }
        }

        return orders;
    }
} 