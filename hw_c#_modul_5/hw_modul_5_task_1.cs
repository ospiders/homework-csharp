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

            WriteLine("���-�� ��������� " + journal.PersonsCount);
            WriteLine(journal.Equals(journal2));

        }
        catch (Exception err)
        {
            WriteLine($"������: {err.Message}!");
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
        get { return _journal_name ?? "�� ������"; }
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
        get { return _journal_description ?? "�� ������"; }
        set { _journal_description = value; }
    }
    public string? JournalPhone
    {
        get { return _journal_phone ?? "�� ������"; }
        set { _journal_phone = value; }
    }
    public string? JournalMail
    {
        get { return _journal_mail ?? "�� ������"; }
        set { _journal_mail = value; }
    }
    public int PersonsCount
    {
        get { return _persons_count; }
        set
        {
            if (value > 0) _persons_count = value;
            else
                throw new Exception("������������� �������� ���������� �����������");
        }
    }

    public void Read()
    {
        Write("������� �������� �������: ");
        JournalName = ReadLine();

        Write("������� ��� ��������� �������: ");
        JournalYear = int.Parse(ReadLine() ?? "0");

        Write("������� �������� �������: ");
        JournalDescription = ReadLine();

        Write("������� ���������� ����� �������: ");
        JournalPhone = ReadLine();

        Write("������� email �������: ");
        JournalMail = ReadLine();

        WriteLine();
    }
    public void Print()
    {
        WriteLine(
            "�������� �������: {0}\n" +
            "��� ��������� �������: {1}\n" +
            "�������� �������: {2}\n" +
            "���������� ����� �������: {3}\n" +
            "Email �������: {4}\n",
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