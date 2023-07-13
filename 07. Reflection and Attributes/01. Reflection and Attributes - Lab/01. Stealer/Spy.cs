using System.Reflection;
using System.Text;

namespace Stealer;

public class Spy
{
    public string StealFieldInfo(string investigatedClass, params string[] fields)
    {
        Type classType = Type.GetType(investigatedClass);
        FieldInfo[] classFields = classType.GetFields((BindingFlags)60);
        StringBuilder sb = new StringBuilder();
        Object classInstance = Activator.CreateInstance(classType, new object[] { });

        sb.AppendLine($"Class under investigation: {investigatedClass}");

        foreach (FieldInfo field in classFields.Where(f => fields.Contains(f.Name)))
        {
            sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
        }

        return sb.ToString().Trim();
    }
}