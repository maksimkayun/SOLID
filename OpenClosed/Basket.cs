namespace OpenClosed;

public class Basket
{
    private List<PeriodicalProduct> PeriodicalProducts { get; set; } = new();
    private List<OneTimeProduct> OneTimeProducts { get; set; } = new();

    private void AddOneTimeProduct(OneTimeProduct product)
    {
        OneTimeProducts.Add(product);
    }

    private void AddPeriodicalProduct(PeriodicalProduct product)
    {
        PeriodicalProducts.Add(product);
        AddOneTimeProduct(product.OtProduct);
    }

    public void AddProduct(object product)
    {
        if (product is PeriodicalProduct perProd)
        {
            AddPeriodicalProduct(perProd);
        } 
        else if (product is OneTimeProduct otProd)
        {
            AddOneTimeProduct(otProd);
        }
    }
}