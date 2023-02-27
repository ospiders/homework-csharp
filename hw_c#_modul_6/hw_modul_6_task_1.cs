using static System.Console;

class Program
{
    static void Main()
    {
        Product prod = new(26, 15);

        prod.ReduceValue(14, 5);

        WriteLine(prod);
    }
}

class Money
{
    int _whole_part;
    int _decimal_places;

    protected int WholePart
    {
        get { return _whole_part; }
        set { _whole_part = value; }
    }
    protected int DecimalPlaces
    {
        get { return _decimal_places; }
        set { _decimal_places = value; }
    }

    public Money(int whole_part, int decimal_places)
    {
        _whole_part = whole_part;
        _decimal_places = decimal_places;
    }

    public override string ToString()
    {
        return $"{_whole_part}.{_decimal_places}";
    }
}

class Product : Money
{
    public Product(int whole_part, int decimal_places) : base(whole_part, decimal_places) { }

    public void ReduceValue(int whole_part, int decimal_place)
    {

        if (decimal_place >= 100)
        {
            whole_part += 1;
            decimal_place -= 100;
        }

        if (decimal_place > DecimalPlaces)
            decimal_place -= 100;

        WholePart -= whole_part;
        DecimalPlaces -= decimal_place;
    }
    public override string ToString()
    {
        return $"Цена {base.ToString()}";
    }
}