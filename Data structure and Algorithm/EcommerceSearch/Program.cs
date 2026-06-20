using System;

class Program
{
    static void Main()
    {
        Product[] products =
{
    new Product(1, "Laptop", "Electronics"),
    new Product(2, "Phone", "Electronics"),
    new Product(3, "Shoes", "Fashion"),
    new Product(4, "Watch", "Accessories"),
    new Product(5, "Bag", "Fashion"),
    new Product(6, "Tablet", "Electronics"),
    new Product(7, "Headphones", "Electronics"),
    new Product(8, "Smart TV", "Electronics"),
    new Product(9, "Keyboard", "Computers"),
    new Product(10, "Mouse", "Computers"),
    new Product(11, "Printer", "Office Supplies"),
    new Product(12, "Camera", "Electronics"),
    new Product(13, "Refrigerator", "Home Appliances"),
    new Product(14, "Microwave", "Home Appliances"),
    new Product(15, "Coffee Maker", "Kitchen"),
    new Product(16, "Water Bottle", "Sports"),
    new Product(17, "Backpack", "Travel"),
    new Product(18, "Gaming Console", "Gaming"),
    new Product(19, "Desk Lamp", "Furniture"),
    new Product(20, "Office Chair", "Furniture")
};

        // 🔹 Linear Search
        Console.WriteLine("Linear Search:");
        Product result1 = LinearSearch.Search(products, "camera");

        if (result1 != null)
            result1.Display();
        else
            Console.WriteLine("Product not found");

        // 🔹 Sort array for Binary Search
        Array.Sort(products, (a, b) => 
            string.Compare(a.ProductName, b.ProductName, true));

        // 🔹 Binary Search
        Console.WriteLine("\nBinary Search:");
        Product result2 = BinarySearch.Search(products, "tablet");

        if (result2 != null)
            result2.Display();
        else
            Console.WriteLine("Product not found");
    }
}