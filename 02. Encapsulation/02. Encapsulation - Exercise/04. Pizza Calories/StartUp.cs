using PizzaCalories.Models;

//Input
string command = string.Empty;

//Testing
try
{
    string[] pizzaInfo = Console.ReadLine().Split();
    string[] doughInfo = Console.ReadLine().Split();

    Dough dough = new Dough(doughInfo[1], doughInfo[2], double.Parse(doughInfo[3]));
    Pizza pizza = new Pizza(pizzaInfo[1], dough);

    while ((command = Console.ReadLine()) != "END")
    {
        string[] ingredientInfo = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
        string typeIngraedient = ingredientInfo[0].ToLower();

        Topping topping = new Topping(ingredientInfo[1], double.Parse(ingredientInfo[2]));
        pizza.AddTopping(topping);
    }

    //Output
    Console.WriteLine(pizza.ToString());
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}