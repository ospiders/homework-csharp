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

        //    WriteLine("Кол-во персонала " + journal.PersonsCount);
        //    WriteLine(journal.Equals(journal2));

        //    WriteLine("Площадь магазина " + store1.StoreSquare);
        //    WriteLine(store1.Equals(store1));
        //}
        //catch(Exception err)
        //{
        //    WriteLine($"Ошибка: { err.Message}!");
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
        get { return _store_name ?? "Не задано"; }
        set { _store_name = value; }
    }
    public string? StoreAdress
    {
        get { return _store_adress ?? "Не задано"; }
        set { _store_adress = value; }
    }
    public string? StoreProfile
    {
        get { return _store_profile ?? "Не задано"; }
        set { _store_profile = value; }
    }
    public string? StorePhone
    {
        get { return _store_phone ?? "Не задано"; }
        set { _store_phone = value; }
    }
    public string? StoreMail
    {
        get { return _store_mail ?? "Не задано"; }
        set { _store_mail = value; }
    }
    public int StoreSquare
    {
        get { return _store_square; }
        set
        {
            if (value > 0) _store_square = value;
            else
                throw new Exception("Значение площади магазина отрицательное!");
        }
    }

    public void Read()
    {
        Write("Введите название магазина: ");
        StoreName = ReadLine();

        Write("Введите адрес магазина: ");
        StoreAdress = ReadLine();

        Write("Введите профиль магазина: ");
        StoreProfile = ReadLine();

        Write("Введите телефонный номер магазина: ");
        StorePhone = ReadLine();

        Write("Введите email магазина: ");
        StoreMail = ReadLine();

        WriteLine();
    }
    public void Print()
    {
        WriteLine(
            "Название магазина: {0}\n" +
            "Адрес магазина: {1}\n" +
            "Профиль магазина: {2}\n" +
            "Телефонный номер магазина: {3}\n" +
            "Email магазина: {4}\n",
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