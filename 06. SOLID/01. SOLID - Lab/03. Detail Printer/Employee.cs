namespace DetailPrinter;

public class Employee
{
    public Employee(string name)
    {
        this.Name = name;
    }

    public string Name { get; set; }

    public virtual string ToString()
    {
        return Name;
    }
}