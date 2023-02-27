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
                Write("������� �������: "); travel_passport.Lastname = ReadLine() ?? "Noname";
                Write("������� ���: "); travel_passport.Name = ReadLine() ?? "Noname";
                Write("������� ��������: "); travel_passport.Patromymic = ReadLine() ?? "Noname";
                Write("������� ����� ��������: "); travel_passport.PassportNumber = ReadLine() ?? "RandomNumber";
                Write("������� ���� ��������: "); travel_passport.DateOfIssue = ReadLine() ?? "RandomData";
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
            return $"���: {_name}\n�������: {_lastname}\n��������: {_patronymic}\n" +
                                      $"����� ���������: {_passport_number}\n���� ������: {_date_of_issue}\n";
        }
    }
    public string Name
    {
        get { return _name; }
        set
        {
            if (Regex.IsMatch(value, "^[�-��-�]*?$"))
            {
                _name = value;
                return;
            }

            throw new Exception("������ �������� ������������ �������");
        }
    }
    public string Lastname
    {
        get { return _lastname; }
        set
        {
            if (Regex.IsMatch(value, "^[�-��-�]*?$"))
            {
                _lastname = value;
                return;
            }

            throw new Exception("������ �������� ������������ �������");
        }
    }
    public string Patromymic
    {
        get { return _patronymic; }
        set
        {
            if (Regex.IsMatch(value, "^[�-��-�]*?$"))
            {
                _patronymic = value;
                return;
            }

            throw new Exception("������ �������� ������������ �������");
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

            throw new Exception("������ �������� ������������ �������");
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

            throw new Exception("������ �������� ������������ �������");
        }
    }
}