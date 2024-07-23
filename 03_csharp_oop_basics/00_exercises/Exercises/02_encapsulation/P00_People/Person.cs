namespace Encapsulation.P00_People;
public class Person
{
    private string _firstName = "";
    private string _lastName = "";
    private int _age;
    private decimal _salary;

    public Person(string firstName, string lastName, int age, decimal salary)
    {
        FirstName = firstName;
        LastName = lastName;
        Age = age;
        Salary = salary;
    }
    
    public string FirstName
    {
        get => _firstName;
        private set
        {
            ValidateFirstName(value);
            _firstName = value;
        }
    }

    public string LastName
    {
        get => _lastName;
        private set
        {
            ValidateLastName(value);
            _lastName = value;
        }
    }

    public int Age
    {
        get => _age;
        private set
        {
            ValidateAge(value);
            _age = value;
        }
    }

    public decimal Salary
    {
        get => _salary;
        private set
        {
            ValidateSalary(value);
            _salary = value;
        }
    }

    public override string ToString()
    {
        return $"{FirstName} {LastName} receives {Salary:0.00} leva.";
    }

    public void IncreaseSalary(decimal percentage)
    {
        if (Age < 30) percentage /= 2;

        Salary += Salary * percentage / 100;
    }

    private void ValidateFirstName(string firstName)
    {
        if (firstName.Length < 3)
            throw new ArgumentException("First name cannot contain fewer than 3 symbols!");
    }

    private void ValidateLastName(string lastName)
    {
        if (lastName.Length < 3)
            throw new ArgumentException("Last name cannot contain fewer than 3 symbols!");
    }

    private void ValidateAge(int age)
    {
        if (age < 1)
            throw new ArgumentException("Age cannot be zero or a negative integer!");
    }

    private void ValidateSalary(decimal salary)
    {
        if (salary < 650)
            throw new ArgumentException("Salary cannot be less than 650 leva!");
    }
}