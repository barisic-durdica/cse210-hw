using System;

class Program
{
    static void Main(string[] args)
    {
        // Order 1 (USA)
        Address address1 = new Address("123 Main Street", "New York", "NY", "USA");
        Customer customer1 = new Customer("John Smith", address1);

        Order order1 = new Order(customer1);

        order1.AddProduct(new Product("Laptop", "L100", 800, 1));
        order1.AddProduct(new Product("Mouse", "M200", 25, 2));
        order1.AddProduct(new Product("Keyboard", "K300", 60, 1));

        // Order 2 (Outside USA)
        Address address2 = new Address("11 Liverpool Street", "London", "England", "United Kingdom");
        Customer customer2 = new Customer("Alex Jenkins", address2);

        Order order2 = new Order(customer2);

        order2.AddProduct(new Product("Desk", "D500", 250, 1));
        order2.AddProduct(new Product("Office Chair", "C600", 180, 1));

        DisplayOrder(order1);

        Console.WriteLine("-------------------------------------");

        DisplayOrder(order2);
    }

    static void DisplayOrder(Order order)
    {
        Console.WriteLine("PACKING LABEL");
        Console.WriteLine(order.GetPackingLabel());

        Console.WriteLine("SHIPPING LABEL");
        Console.WriteLine(order.GetShippingLabel());

        Console.WriteLine();

        Console.WriteLine($"TOTAL PRICE: ${order.GetTotalPrice():F2}");
        Console.WriteLine();
    }
}