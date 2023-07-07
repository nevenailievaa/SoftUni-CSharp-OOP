namespace DetailPrinter;

public class DetailsPrinter
{
    //Fields
    private IList<Employee> employees;

    //Constructor
    public DetailsPrinter(IList<Employee> employees)
    {
        this.employees = employees;
    }

    //Methods
    public void PrintDetails()
    {
        foreach (Employee employee in this.employees)
        {
            Console.WriteLine(employee.ToString());
        }
    }

    private void PrintEmployee(Employee employee)
    {
        Console.WriteLine(employee.Name);
    }

    private void PrintManager(Manager manager)
    {
        Console.WriteLine(manager.Name);
        Console.WriteLine(string.Join(Environment.NewLine, manager.Documents));
    }
}