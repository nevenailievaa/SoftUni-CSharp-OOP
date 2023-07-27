using EDriveRent.Models;
using EDriveRent.Models.Contracts;
using EDriveRent.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace EDriveRent.Repositories;

public class UserRepository : IRepository<IUser>
{
    //Fields
    private readonly List<IUser> users;

    //Constructor
    public UserRepository()
    {
        users = new List<IUser>();
    }

    //Methods
    public void AddModel(IUser model)
    {
        users.Add(model);
    }

    public IUser FindById(string identifier) => users.FirstOrDefault(u => u.DrivingLicenseNumber == identifier);

    public IReadOnlyCollection<IUser> GetAll() => users;

    public bool RemoveById(string identifier) => users.Remove(users.FirstOrDefault(u => u.DrivingLicenseNumber == identifier));
}