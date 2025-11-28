using System;

namespace DeliverySystem.Dish;

public class DefaultDish : IDish
{
    public string Name { get; set; }
    public float Price { get; set; }
    public float Weight { get; set; }
    public string Category { get; set; }
    public float Calorage { get; set; }

    public DefaultDish(string name, float price, float weight, string category, float calorage)
    {
        Name = name;
        Price = price;
        Weight = weight;
        Category = category;
        Calorage = calorage;
    }
}
