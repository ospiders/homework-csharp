using static System.Console;

class Program
{
    static void Main()
    {
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


class Library
{
    readonly List<string>? _list_of_books = new();

    public string ListOfBooks
    {
        get
        {
            if (_list_of_books != null)
            {
                string data = "";
                for (int i = 0; i < _list_of_books.Count; i++)
                    data += _list_of_books[i] + "\n";

                return data;
            }
            throw new Exception("Библеотека пуста");
        }
        set
        {
            if (_list_of_books != null)
                _list_of_books.Add(value);
        }
    }
    public static Library operator +(Library obj, string newbook)
    {
        obj.ListOfBooks = newbook;
        return obj;
    }
    public static Library operator -(Library obj, string deletebook)
    {
        if (obj._list_of_books == null)
            throw new Exception("Библеотека пуста");

        if (obj._list_of_books.Contains(deletebook))
        {
            obj._list_of_books.Remove(deletebook);
            return obj;
        }

        throw new Exception("Книга не найдена");
    }
    public static bool operator ==(Library obj1, string bookname)
    {
        if (obj1._list_of_books == null)
            return false;

        if (obj1._list_of_books.Contains(bookname))
            return true;
        else
            return false;
    }
    public static bool operator !=(Library obj1, string bookname)
    {
        return !(obj1 == bookname);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(this, obj))
        {
            return true;
        }

        if (obj is null)
        {
            return false;
        }

        throw new NotImplementedException();
    }
    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}

