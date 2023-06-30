using System.Security.Cryptography.X509Certificates;

namespace BirthdayCelebrations.Models.Interfaces;

public interface IBirthable
{
    public string Name { get; }
    public string Birthdate { get; }
}
