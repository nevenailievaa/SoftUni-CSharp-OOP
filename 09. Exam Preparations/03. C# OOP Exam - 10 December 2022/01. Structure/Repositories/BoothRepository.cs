using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Repositories.Contracts;
using System.Collections.Generic;

namespace ChristmasPastryShop.Repositories
{
    public class BoothRepository : IRepository<IBooth>
    {
        //Fields
        private readonly List<IBooth> booths;

        //Constructor
        public BoothRepository()
        {
            booths = new List<IBooth>();
        }

        //Properties
        public IReadOnlyCollection<IBooth> Models => booths;

        //Methods
        public void AddModel(IBooth model)
        {
            booths.Add(model);
        }
    }
}
