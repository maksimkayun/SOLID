namespace OpenClosed;

public class PeriodicalProduct : Product
{
    public OneTimeProduct OtProduct { get; set; }

    public PeriodicalProduct(string name, decimal price, OneTimeProduct otProduct) : base(name, price)
    {
        OtProduct = otProduct;
    }
}