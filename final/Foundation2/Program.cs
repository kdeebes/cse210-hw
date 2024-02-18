//Name: Kerryann Deebes
//Class: CSE210
//Date: 2/18/2024

using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Creates addresses
        Address usaAddress = new Address("812 KAYAK AVE E", "Capitol Heights", "MD", "USA");
        Address canadaAddress = new Address("1493 Adelaide St", "Toronto", "ON", "Canada");

        // Creates customers
        Customer customer1 = new Customer("Kerryann Deebes", usaAddress);
        Customer customer2 = new Customer("Deorajie Sugrim", canadaAddress);

        // Creates products
        Product product1 = new Product("Widget", "W123", 10.00m, 2);
        Product product2 = new Product("Gadget", "G456", 20.00m, 1);

        // Creates orders
        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);

        Order order2 = new Order(customer2);
        order2.AddProduct(product2);

        // Displays order details
        Console.WriteLine("Order 1 Packing Label:");
        Console.WriteLine(order1.GetPackingLabel());

        Console.WriteLine("Order 1 Shipping Label:");
        Console.WriteLine(order1.GetShippingLabel());

        Console.WriteLine("Order 1 Total Price: $" + order1.GetTotalPrice());

        Console.WriteLine();

        Console.WriteLine("Order 2 Packing Label:");
        Console.WriteLine(order2.GetPackingLabel());

        Console.WriteLine("Order 2 Shipping Label:");
        Console.WriteLine(order2.GetShippingLabel());

        Console.WriteLine("Order 2 Total Price: $" + order2.GetTotalPrice());
    }
}

class Order
{
    private List<Product> products;
    private Customer customer;

    public Order(Customer customer)
    {
        this.customer = customer;
        products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    public decimal GetTotalPrice()
    {
        decimal totalPrice = 0;
        foreach (Product product in products)
        {
            totalPrice += product.TotalCost;
        }

        // Adds shipping cost based on customer location
        if (customer.Address.IsInUSA())
        {
            totalPrice += 5.00m;
        }
        else
        {
            totalPrice += 35.00m;
        }

        return totalPrice;
    }

    public string GetPackingLabel()
    {
        string packingLabel = "";
        foreach (Product product in products)
        {
            packingLabel += $"Name: {product.Name}, ID: {product.Id}\n";
        }
        return packingLabel;
    }

    public string GetShippingLabel()
    {
        return $"Name: {customer.Name}\n{customer.Address}";
    }
}

class Product
{
    private string name;
    private string id;
    private decimal price;
    private int quantity;

    public Product(string name, string id, decimal price, int quantity)
    {
        this.name = name;
        this.id = id;
        this.price = price;
        this.quantity = quantity;
    }

    public decimal TotalCost
    {
        get { return price * quantity; }
    }

    public string Name { get { return name; } }
    public string Id { get { return id; } }
}

class Customer
{
    private string name;
    private Address address;

    public Customer(string name, Address address)
    {
        this.name = name;
        this.address = address;
    }

    public string Name { get { return name; } }
    public Address Address { get { return address; } }
}

class Address
{
    private string streetAddress;
    private string city;
    private string stateProvince;
    private string country;

    public Address(string streetAddress, string city, string stateProvince, string country)
    {
        this.streetAddress = streetAddress;
        this.city = city;
        this.stateProvince = stateProvince;
        this.country = country;
    }

    public bool IsInUSA()
    {
        return country == "USA";
    }

    public override string ToString()
    {
        return $"{streetAddress}, {city}, {stateProvince}, {country}";
    }
}
