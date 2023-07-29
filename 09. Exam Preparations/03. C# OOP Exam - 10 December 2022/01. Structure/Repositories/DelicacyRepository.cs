using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories.Contracts;
using System.Collections.Generic;

namespace ChristmasPastryShop.Repositories
{
    public class DelicacyRepository : IRepository<IDelicacy>
    {
        //Fields
        private readonly List<IDelicacy> delicacies;

        //Constructor
        public DelicacyRepository()
        {
            delicacies = new List<IDelicacy>();
        }

        //Properties
        public IReadOnlyCollection<IDelicacy> Models => delicacies;

        //Methods
        public void AddModel(IDelicacy model)
        {
            delicacies.Add(model);
        }
    }
}