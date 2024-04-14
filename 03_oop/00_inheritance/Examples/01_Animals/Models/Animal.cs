namespace Animals.Models;

public abstract class Animal
{
    private string _name = "Default";
    private int _age;
    private string _gender = "Default";

    public Animal(string name, int age, string gender)
    {
        Name = name;
        Age = age;
        Gender = gender;
    }

    public string Name
    {
        get { return _name; }
        set
        {
            if (string.IsNullOrEmpty(value))
                throw new Exception("Name cannot be null or empty.");
            else
                _name = value;
        }
    }

    public int Age
    {
        get { return _age; }
        set
        {
            if (value < 0)
                throw new Exception("Age cannot be less than zero.");
            else
                _age = value;
        }
    }

    public string Gender
    {
        get { return _gender; }
        set
        {
            if (string.IsNullOrEmpty(value))
                throw new Exception("Gender cannot be null or empty.");
            else
                _gender = value;
        }
    }

    public abstract string ProduceSound();

    public override string ToString()
    {
        var output = 
            $"{this.GetType().Name}\n" +
            $"{_name} {_age} {_gender}\n" +
            $"{ProduceSound()}";

        return output;
    }
}
