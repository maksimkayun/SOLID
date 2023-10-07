namespace SingleResponsibility;

public static class Program
{
    public static void Main()
    {
        var basket = new Basket();
        
        var product1 = new Product(name: "Книга", price: 10.0);
        var product2 = new Product(name: "Журнал", price: 5.0);
        

        basket.AddProduct(product: product1, quantity: 5);
        basket.AddProduct(product: product2, quantity: 8);
        
        Console.WriteLine(basket.GetTotalDescriptionOfProducts());
    }
}