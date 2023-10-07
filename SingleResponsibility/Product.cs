namespace SingleResponsibility;

public class Product
{
    public Product(string name, double price)
    {
        Name = name;
        Price = price;
    }

    public string Name { get; set; }
    public double Price { get; set; }

    public double CalculateTotalPrice(int quantity)
    {
        if (quantity <= 0)
        {
            throw new Exception("Количество товара должно быть положительным числом.");
        }

        return Price * quantity;
    }
}