namespace SingleResponsibility;

public static class Program
{
    public static void Main()
    {
        var product = new Product(name: "Книга", price: 10.0);

        Console.WriteLine($"Имя товара: {product.Name}");
        Console.WriteLine($"Цена товара: {product.Price}");
        Console.WriteLine($"Итоговая цена за 5 единиц: {product.CalculateTotalPrice(5)}");
    }
}