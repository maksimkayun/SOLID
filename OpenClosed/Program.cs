// See https://aka.ms/new-console-template for more information

using OpenClosed;

var otProd = new OneTimeProduct(name: "p1", price: 5);
var perProd = new PeriodicalProduct(name: "p2", price: 10, otProduct: otProd);

var otProd2 = new OneTimeProduct(name: "p3", price: 15);

var basket = new Basket();
basket.AddProduct(perProd);
basket.AddProduct(otProd2);
