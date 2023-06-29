namespace ShoppingSpree.Models;

public class Person
{
    //Fields
    private string name;
    private decimal money;
    private List<Product> products;

    //Constructor
    public Person(string name, decimal money)
    {
        Name = name;
        Money = money;
        products = new List<Product>();
    }

    //Properties
    public string Name
    {
        get => name;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Name cannot be empty");
            }
            name = value;
        }
    }
    public decimal Money
    {
        get => money;
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Money cannot be negative");
            }
            money = value;
        }
    }

    //Methods
    public string BuyProduct(Product product)
    {
        if (Money < product.Cost)
        {
            return $"{Name} can't afford {product.Name}";
        }

        products.Add(product);
        Money -= product.Cost;

        return $"{Name} bought {product.Name}";
    }

    public override string ToString()
    {
        if(products.Any())
        {
            return $"{Name} - {String.Join(", ", products.Select(p => p.Name))}";
        }
        else
        {
            return $"{Name} - Nothing bought";
        }
    }
}