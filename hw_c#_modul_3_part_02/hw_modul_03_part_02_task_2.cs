/*Задание 2
Пользователь вводит словами цифру от 0 до 9.
Приложение должно перевести слово в цифру. 
Например, если пользователь ввёл five, приложение должно вывести на 
экран 5. */

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