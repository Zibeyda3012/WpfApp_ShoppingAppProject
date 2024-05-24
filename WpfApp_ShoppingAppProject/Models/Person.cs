using System.Text.RegularExpressions;
using System.Windows;
using WpfApp_ShoppingAppProject.Services;

namespace WpfApp_ShoppingAppProject.Models;

public abstract class Person : NotificationService, IEquatable<Person>
{
    private Guid id;
    private string? person_name;
    private string? surname;
    private string? email;
    private string? phoneNumber;
    private DateTime birthday;
    private string? password;

    public Guid ID { get => id; set => id = value; }
    public string PersonName
    {
        get => person_name;
        set
        {
            person_name = value;
            OnPropertyChanged();
        }
    }

    public string Surname
    {
        get => surname;
        set
        {
            surname = value;
            OnPropertyChanged();
        }
    }

    public string Email
    {
        get => email;
        set
        {
            //string pattern = @"^[A-Za-z0-9_.]+@gmail\.[A-Za-z]+$";
            //Regex regex = new Regex(pattern);

            if (value is not null/* && regex.IsMatch(value)*/)
                email = value;
            OnPropertyChanged();
        }
    }

    public string PhoneNumber
    {
        get => phoneNumber;
        set
        {
            //Regex regex = new Regex(@"^\(\+994\)\d{9}$", RegexOptions.IgnoreCase);

             /*&& regex.IsMatch(value)*/
                phoneNumber = value;

            OnPropertyChanged();
        }
    }

    public DateTime Birthday { get => birthday; set { birthday = value; OnPropertyChanged(); } }


    public string Password { get => password; set { password = value; OnPropertyChanged(); } }

    public Person()
    { ID = Guid.NewGuid(); }
    public Person(string PersonName, string Surname, string Email, string PhoneNumber, DateTime Birthday, string Password) : this()
    {
        this.PersonName = PersonName;
        this.Surname = Surname;
        this.Email = Email;
        this.PhoneNumber = PhoneNumber;
        this.Birthday = Birthday;
        this.Password = Password;
    }

    public bool Equals(Person? other)
    {
        if (other is null)
            return false;

        return this.PersonName == other.PersonName && this.Surname == other.Surname && this.Email == other.Email && this.PhoneNumber == other.PhoneNumber && this.Birthday == other.Birthday && this.Password == other.Password;
    }

    public void SetValue(Person? person)
    {
        this.ID = person.ID;
        this.PersonName = person.PersonName;
        this.Surname = person.Surname;
        this.Email = person.Email;
        this.PhoneNumber = person.PhoneNumber;
        this.Birthday = person.Birthday;
        this.Password = person.Password;
    }
}
