using System.Text;

namespace SingleResponsibility;

public class Basket
{
    public List<Product> Products { get; set; } = new();
    public Dictionary<string, int> QuantityOfProducts { get; set; } = new();

    public void AddProduct(Product product, int quantity)
    {
        Products.Add(product);
        QuantityOfProducts.Add(product.Name, quantity);
    }

    public string GetTotalDescriptionOfProducts()
    {
        var stringBuilder = new StringBuilder();
        foreach (var p in Products)
        {
            stringBuilder.AppendLine($"Продукт: {p.Name}");
            stringBuilder.AppendLine($"Цена за единицу: {p.Price}");
            stringBuilder.AppendLine($"Количетсво единиц: {QuantityOfProducts[p.Name]}");
            stringBuilder.AppendLine($"Цена за данный тип продукта: {CalculateTotalPriceByProductName(p.Name)}");
            stringBuilder.AppendLine();
        }

        stringBuilder.AppendLine($"Итоговая цена за все продукты: {CalculateTotalPrice()}");

        return stringBuilder.ToString().TrimEnd();
    }

    public double CalculateTotalPriceByProductName(string productName)
    {
        var fullPrice = QuantityOfProducts[productName] * Products.SingleOrDefault(p => p.Name == productName)?.Price ?? 0.0;
        return fullPrice;
    }
    
    public double CalculateTotalPrice()
    {
        var fullPrice = 0.0;
        foreach (var p in Products)
        {
            if (QuantityOfProducts[p.Name] <= 0)
            {
                throw new Exception("Количество товара должно быть положительным числом.");
            }

            fullPrice += QuantityOfProducts[p.Name] * p.Price;
        }

        return fullPrice;
    }
}