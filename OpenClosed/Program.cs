// See https://aka.ms/new-console-template for more information

using OpenClosed;

var otProd = new OneTimeProduct();
var perProd = new PeriodicalProduct
{
    OtProduct = otProd
};

var otProd2 = new OneTimeProduct();

var basket = new Basket();
basket.AddProduct(perProd);
basket.AddProduct(otProd2);
