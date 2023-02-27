using static System.Console;

namespace charp
{
    class Program
    {
        static void Main()
        {
            Write(IntToWord.ToString(2));
        }
    }
}
class IntToWord
{
    enum StringNumbers { zero, one, two, three, four, five, six, seven, eight, nine }
    public static string ToString(int number)
    {
        return Enum.GetName(typeof(StringNumbers), number) ?? "error";
    }
}