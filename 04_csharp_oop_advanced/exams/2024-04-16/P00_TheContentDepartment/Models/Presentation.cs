namespace TheContentDepartment.Models;

public class Presentation : Resource
{
    private const int PRIORITY = 3;
    public Presentation(string name, string creator) : base(name, creator, PRIORITY)
    {
    }
}