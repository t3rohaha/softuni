using System.Reflection;
using System.Text;

namespace ReflectionAndAttributes.P00_Stealer.Models;
public class Spy
{
    public string StealFieldInfo(string typeName, params string[] requestedFields)
    {
        var type = GetType(typeName);

        var fields = type
        .GetFields(
            BindingFlags.Instance |
            BindingFlags.Static |
            BindingFlags.NonPublic |
            BindingFlags.Public)
        .Where(x => requestedFields.Contains(x.Name));

        var output = new StringBuilder();
        output.AppendLine($"Class under investigation: {type.FullName}");

        var instance = Activator.CreateInstance(type);
        foreach (var f in fields)
            output.AppendLine($"{f.Name} = {f.GetValue(instance)}");

        return output.ToString().Trim();
    }

    // Returns access modifier recommendations on fields and properties.
    public string AnalyzeAccessModifiers(string typeName)
    {
        var type = GetType(typeName);

        var publicFields = type.GetFields(BindingFlags.Instance | BindingFlags.Public);
        var privateMethods = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
        var publicMethods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public);

        var sb = new StringBuilder();

        // Append public fields recommendation.
        foreach (FieldInfo i in publicFields)
            sb.AppendLine($"{i.Name} must be private!");

        // Append private getters recommendation.
        foreach (MethodInfo i in privateMethods)
            if (i.Name.StartsWith("get_"))
                sb.AppendLine($"{i.Name} have to be public!");

        // Append public setters recommendation.
        foreach (MethodInfo i in publicMethods)
            if (i.Name.StartsWith("set_"))
                sb.AppendLine($"{i.Name} have to be private!");

        return sb.ToString().Trim();
    }

    public string RevealPrivateMethods(string typeName)
    {
        var type = GetType(typeName);

        var privateMethods = type.GetMethods(
            BindingFlags.Static |
            BindingFlags.Instance |
            BindingFlags.NonPublic);

        var sb = new StringBuilder();
        sb.AppendLine($"All Private Methods of class: {typeName}");
        sb.AppendLine($"Base Class: {type.BaseType!.Name}");

        foreach (MethodInfo i in privateMethods) sb.AppendLine(i.Name);

        return sb.ToString().Trim();
    }

    public string CollectGettersAndSetters(string typeName)
    {
        var type = GetType(typeName);

        var methods = type.GetMethods(
            BindingFlags.Instance |
            BindingFlags.Public |
            BindingFlags.NonPublic);

        var sb = new StringBuilder();
        foreach (MethodInfo i in methods)
            if (i.Name.StartsWith("get_") || i.Name.StartsWith("set_"))
                sb.AppendLine($"{i.Name} will return {i.ReturnType.FullName}");
        
        return sb.ToString().Trim();
    }

    private Type GetType(string typeName)
    {
        var type = Type.GetType(typeName);
        if (type == null)
            throw new ArgumentException($"Type {typeName} not found!");
        else
            return type;
    }
}