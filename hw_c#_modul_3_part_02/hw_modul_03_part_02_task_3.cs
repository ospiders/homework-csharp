using System.Text.RegularExpressions;
using static System.Console;

namespace charp
{
    class Program
    {
        static void Main()
        {
            TravelPassport travel_passport = new();

            try
            {
                Write("Введите фамилию: "); travel_passport.Lastname = ReadLine() ?? "Noname";
                Write("Введите имя: "); travel_passport.Name = ReadLine() ?? "Noname";
                Write("Введите отчество: "); travel_passport.Patromymic = ReadLine() ?? "Noname";
                Write("Введите номер паспорта: "); travel_passport.PassportNumber = ReadLine() ?? "RandomNumber";
                Write("Введите дату рождения: "); travel_passport.DateOfIssue = ReadLine() ?? "RandomData";
            }
            catch (Exception e) { WriteLine(e.Message); }

            WriteLine(travel_passport.Data);
        }
    }
}

class TravelPassport
{
    string _name;
    string _lastname;
    string _patronymic;
    string _passport_number;
    string _date_of_issue;

    public string Data
    {
        get
        {
            return $"Имя: {_name}\nФамилия: {_lastname}\nОтчество: {_patronymic}\n" +
                                      $"Номер пасспорта: {_passport_number}\nДата выдачи: {_date_of_issue}\n";
        }
    }
    public string Name
    {
        get { return _name; }
        set
        {
            if (Regex.IsMatch(value, "^[а-яА-Я]*?$"))
            {
                _name = value;
                return;
            }

            throw new Exception("Строка содержит недопустимые символы");
        }
    }
    public string Lastname
    {
        get { return _lastname; }
        set
        {
            if (Regex.IsMatch(value, "^[а-яА-Я]*?$"))
            {
                _lastname = value;
                return;
            }

            throw new Exception("Строка содержит недопустимые символы");
        }
    }
    public string Patromymic
    {
        get { return _patronymic; }
        set
        {
            if (Regex.IsMatch(value, "^[а-яА-Я]*?$"))
            {
                _patronymic = value;
                return;
            }

            throw new Exception("Строка содержит недопустимые символы");
        }
    }
    public string PassportNumber
    {
        get { return _passport_number; }
        set
        {
            if (Regex.IsMatch(value, "^[0-9]*?$"))
            {
                _passport_number = value;
                return;
            }

            throw new Exception("Строка содержит недопустимые символы");
        }
    }
    public string DateOfIssue
    {
        get { return _date_of_issue; }
        set
        {
            if (Regex.IsMatch(value, "^[0-9.]*?$"))
            {
                _date_of_issue = value;
                return;
            }

            throw new Exception("Строка содержит недопустимые символы");
        }
    }
}