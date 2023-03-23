using System.Xml.Linq;

class Order<TProduct>
where TProduct : Product
{
    public TProduct[] Products { get; private set;}
    public string OrderId { get; private set;}
    public Order(TProduct[] products, string orderId)
    {
        Products = products;
        OrderId = orderId;
    }

    public int CalculateOrderCost()
    {
        int Sum = 0;
        for(int i=0; i<Products.Length; i++)
        {
            Sum = Sum + Products[i].Cost;
        } 
        return Sum;
    }
    public void PrintOrder()
    {
        Console.WriteLine($"Номер заказа: {OrderId}");

        for (int i = 0; i < Products.Length; i++)
        {
            Console.WriteLine($"{i}. {Products[i].GetShortDescription()}");
        }
        Console.WriteLine($"Общая сумма заказа: {CalculateOrderCost()}");
    }

}
abstract class Product
{
    public string Name { get; private set;}
    public int Cost { get; private set;}
    public Product(string name, int cost)
    {
        Name = name;
        Cost = cost;
    }

    public string GetShortDescription ()
    { 
        return $"{Name} {Cost} р.";
    }
    public abstract string GetFullDescription();

}
class Food  : Product
{
    public int Calories { get; private set;}
    public int Proteins { get; private set;}
    public int Fats { get; private set;}
    public int Carbohydrates { get; private set;}

    public Food(string name, int cost, int calories, int proteins, int fats, int carbohydrates):base(name, cost)
    {
        Calories = calories;
        Proteins = proteins;
        Fats = fats;
        Carbohydrates = carbohydrates;
    }

    public override string GetFullDescription()
    {
        var shortDescription = GetShortDescription();
        return $"{shortDescription} {Calories} калл. {Proteins} б. {Fats} ж. {Carbohydrates} у.";

    }
}
class Appliances : Product
{
    public string EnergyEfficiency { get; private set;}
    public Dimension Dimension { get; private set;}

    public Appliances(string name, int cost, string energyEfficiency, Dimension dimension) : base(name, cost)
    {
        EnergyEfficiency = energyEfficiency;
        Dimension = dimension;
    }

    public override string GetFullDescription()
    {
        var shortDescription = GetShortDescription();
        var dimension = Dimension.GetDimension();
        return $"{shortDescription} Энергоэфективность {EnergyEfficiency} Размер {dimension}";
    }

}
class Dimension
{ 
    public int Height { get; private set;}
    public int Length { get; private set;}
    public int Width { get; private set;}

    public Dimension(int height, int length, int width)
    {
        Height = height;
        Length = length;
        Width = width;
    }
    public string GetDimension()
    {
        return $"{Height}x{Length}x{Width}";
    }
}


