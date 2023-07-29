using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Repositories.Contracts;
using System.Collections.Generic;

namespace ChristmasPastryShop.Repositories
{
    public class CocktailRepository : IRepository<ICocktail>
    {
        //Fields
        private readonly List<ICocktail> cocktails;

        //Constructor
        public CocktailRepository()
        {
            cocktails = new List<ICocktail>();
        }

        //Properties
        public IReadOnlyCollection<ICocktail> Models => cocktails;

        //Methods
        public void AddModel(ICocktail model)
        {
            cocktails.Add(model);
        }
    }
}