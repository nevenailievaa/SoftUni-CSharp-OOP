namespace Restaurant;
public class Product
{
    //Constructor
    public Product(string name, decimal price)
    {
        Name = name;
        Price = price;
    }

    //Properties
    public string Name { get; private set; }
    public decimal Price { get; private set; }
}
