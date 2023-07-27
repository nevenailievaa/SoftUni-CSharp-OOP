using EDriveRent.Models;
using EDriveRent.Models.Contracts;
using EDriveRent.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace EDriveRent.Repositories;

public class RouteRepository : IRepository<IRoute>
{
    //Fields
    private readonly List<IRoute> routes;

    //Constructor
    public RouteRepository()
    {
        routes = new List<IRoute>();
    }

    //Methods
    public void AddModel(IRoute model)
    {
        routes.Add(model);
    }

    public IRoute FindById(string identifier) => routes.FirstOrDefault(r => r.RouteId == int.Parse(identifier));

    public IReadOnlyCollection<IRoute> GetAll() => routes;

    public bool RemoveById(string identifier)
        => routes.Remove(routes.FirstOrDefault(r => r.RouteId == int.Parse(identifier)));
}