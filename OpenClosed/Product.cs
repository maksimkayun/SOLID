namespace OpenClosed;

public abstract class Product
{
    public decimal Price { get; protected set; }
    public string Name { get; protected set; }

    public Product(string name, decimal price)
    {
        Name = name;
        Price = price;
    }
}