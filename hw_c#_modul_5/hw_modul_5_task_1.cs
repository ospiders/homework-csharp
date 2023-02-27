using static System.Console;

class Program
{
    static void Main()
    {
        Journal journal = new();
        Journal journal2 = new();

        journal += 6;
        try
        {
            journal2 += 6;
            //journal2 -= 12;

            WriteLine("Кол-во персонала " + journal.PersonsCount);
            WriteLine(journal.Equals(journal2));

        }
        catch (Exception err)
        {
            WriteLine($"Ошибка: {err.Message}!");
        }
    }
}

class Journal
{
    string? _journal_name;
    int? _journal_year;
    string? _journal_description;
    string? _journal_phone;
    string? _journal_mail;
    int _persons_count = 0;

    public string? JournalName
    {
        get { return _journal_name ?? "Не задано"; }
        set { _journal_name = value; }
    }
    public int? JournalYear
    {
        get { return _journal_year ?? 0; }
        set
        {
            _journal_year = (value >= 2022 || value < 1900)
                ? 0 : value;
        }
    }
    public string? JournalDescription
    {
        get { return _journal_description ?? "Не задано"; }
        set { _journal_description = value; }
    }
    public string? JournalPhone
    {
        get { return _journal_phone ?? "Не задано"; }
        set { _journal_phone = value; }
    }
    public string? JournalMail
    {
        get { return _journal_mail ?? "Не задано"; }
        set { _journal_mail = value; }
    }
    public int PersonsCount
    {
        get { return _persons_count; }
        set
        {
            if (value > 0) _persons_count = value;
            else
                throw new Exception("Отрицательное значение количества сотрудников");
        }
    }

    public void Read()
    {
        Write("Введите название журнала: ");
        JournalName = ReadLine();

        Write("Введите год основания журнала: ");
        JournalYear = int.Parse(ReadLine() ?? "0");

        Write("Введите описание журнала: ");
        JournalDescription = ReadLine();

        Write("Введите телефонный номер журнала: ");
        JournalPhone = ReadLine();

        Write("Введите email журнала: ");
        JournalMail = ReadLine();

        WriteLine();
    }
    public void Print()
    {
        WriteLine(
            "Название журнала: {0}\n" +
            "Год основания журнала: {1}\n" +
            "Описание журнала: {2}\n" +
            "Телефонный номер журнала: {3}\n" +
            "Email журнала: {4}\n",
            JournalName, JournalYear, JournalDescription, JournalPhone, JournalMail);
    }

    public static Journal operator +(Journal obj, int number)
    {
        obj.PersonsCount += number;
        return obj;
    }
    public static Journal operator -(Journal obj, int number)
    {
        obj.PersonsCount -= number;
        return obj;
    }
    public static bool operator ==(Journal obj1, Journal obj2)
    {
        return obj1.PersonsCount == obj2.PersonsCount;
    }
    public static bool operator !=(Journal obj1, Journal obj2)
    {
        return !(obj1 == obj2);
    }
    public static bool operator >(Journal obj1, Journal obj2)
    {
        return obj1.PersonsCount > obj2.PersonsCount;
    }
    public static bool operator <(Journal obj1, Journal obj2)
    {
        return !(obj1 > obj2);
    }
    public override bool Equals(object? obj)
    {
        return base.Equals((Journal?)obj);
    }
    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}