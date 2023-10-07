namespace OpenClosed;

public class Basket
{
    private List<Product> Products { get; set; } = new();

    public void AddProduct(Product product)
    {
        Products.Add(product);
    }

    public List<OneTimeProduct> GetOneTimeProducts =>
        Products.OfType<OneTimeProduct>().ToList();
    
    public List<PeriodicalProduct> GetPeriodicalProducts =>
        Products.OfType<PeriodicalProduct>().ToList();
}