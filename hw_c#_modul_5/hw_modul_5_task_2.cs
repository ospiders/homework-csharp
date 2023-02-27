using static System.Console;

class Program
{
    static void Main()
    {
        //Journal journal = new();
        //Journal journal2 = new();

        //Store store1 = new();
        //Store store2 = new();

        //journal += 6;
        //store1 += 35;
        //try
        //{
        //    store2 += 12;
        //    //store2 -= 14;

        //    journal2 += 6;
        //    //journal2 -= 12;

        //    WriteLine("���-�� ��������� " + journal.PersonsCount);
        //    WriteLine(journal.Equals(journal2));

        //    WriteLine("������� �������� " + store1.StoreSquare);
        //    WriteLine(store1.Equals(store1));
        //}
        //catch(Exception err)
        //{
        //    WriteLine($"������: { err.Message}!");
        //}

        Library library = new();
        try
        {

            library.ListOfBooks = "Dada";
            library.ListOfBooks = "Rada";

            library += "Fada";

            library -= "Lada";

            WriteLine(library == "Dada");

            WriteLine(library.ListOfBooks);
        }
        catch (Exception err) { WriteLine(err.Message); }
    }
}


class Store
{
    string? _store_name;
    string? _store_adress;
    string? _store_profile;
    string? _store_phone;
    string? _store_mail;
    int _store_square = 0;

    public string? StoreName
    {
        get { return _store_name ?? "�� ������"; }
        set { _store_name = value; }
    }
    public string? StoreAdress
    {
        get { return _store_adress ?? "�� ������"; }
        set { _store_adress = value; }
    }
    public string? StoreProfile
    {
        get { return _store_profile ?? "�� ������"; }
        set { _store_profile = value; }
    }
    public string? StorePhone
    {
        get { return _store_phone ?? "�� ������"; }
        set { _store_phone = value; }
    }
    public string? StoreMail
    {
        get { return _store_mail ?? "�� ������"; }
        set { _store_mail = value; }
    }
    public int StoreSquare
    {
        get { return _store_square; }
        set
        {
            if (value > 0) _store_square = value;
            else
                throw new Exception("�������� ������� �������� �������������!");
        }
    }

    public void Read()
    {
        Write("������� �������� ��������: ");
        StoreName = ReadLine();

        Write("������� ����� ��������: ");
        StoreAdress = ReadLine();

        Write("������� ������� ��������: ");
        StoreProfile = ReadLine();

        Write("������� ���������� ����� ��������: ");
        StorePhone = ReadLine();

        Write("������� email ��������: ");
        StoreMail = ReadLine();

        WriteLine();
    }
    public void Print()
    {
        WriteLine(
            "�������� ��������: {0}\n" +
            "����� ��������: {1}\n" +
            "������� ��������: {2}\n" +
            "���������� ����� ��������: {3}\n" +
            "Email ��������: {4}\n",
            StoreName, StoreAdress, StoreProfile, StorePhone, StoreMail);
    }

    public static Store operator +(Store obj, int number)
    {
        obj.StoreSquare += number;
        return obj;
    }
    public static Store operator -(Store obj, int number)
    {
        obj.StoreSquare -= number;
        return obj;
    }
    public static bool operator ==(Store obj1, Store obj2)
    {
        return obj1.StoreSquare == obj2.StoreSquare;
    }
    public static bool operator !=(Store obj1, Store obj2)
    {
        return !(obj1 == obj2);
    }
    public static bool operator >(Store obj1, Store obj2)
    {
        return obj1.StoreSquare > obj2.StoreSquare;
    }
    public static bool operator <(Store obj1, Store obj2)
    {
        return !(obj1 > obj2);
    }
    public override bool Equals(object? obj)
    {
        return base.Equals((Store?)obj);
    }
    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}