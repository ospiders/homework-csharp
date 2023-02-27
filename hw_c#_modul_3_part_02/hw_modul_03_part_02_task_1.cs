using static System.Console;
using static Calculator;

namespace charp
{
    class Program
    {
        static void Menu()
        {
            short choice;
            do
            {
                Write("Выберите направление перевода системы исчисления\n\n" +
                      "1 - Из десятичной в двоичную.\n" +
                      "2 - Из двоичной в десятичную.\n" +
                      "0 - Выход.\n> ");
                choice = short.Parse(ReadLine() ?? "0");

                switch (choice)
                {
                    case 0:
                        WriteLine("Выход");
                        break;
                    case 1:
                        WriteLine("Вы выбрали перевод числа из десятичной системы счисления в бинарную\n");
                        WriteLine($"Результат - {FromDecToBin()}\n");
                        break;
                    case 2:
                        WriteLine("Вы выбрали перевод числа из бинарной системы счисления в десятичную\n");
                        WriteLine($"Результат - {FromBinToDec()}\n");
                        break;
                }
            } while (choice != 0);
        }



        static void Main()
        {
            try { Menu(); }
            catch (Exception err) { WriteLine(err.Message); }
        }
    }
}

// Задание 1
class Calculator
{
    public static string FromDecToBin()
    {
        Write("Введите число десятичной системы счисления:\n> ");
        int input_dec_num = int.Parse(ReadLine() ?? "0");

        return Convert.ToString(input_dec_num, 2);
    }

    public static int FromBinToDec()
    {
        Write("Введите число двоичной системы счисления:\n> ");
        string input_bin_num = ReadLine() ?? "0";

        int result = 0;

        foreach (string str in input_bin_num.Split(' '))
        {
            if (str.Length > 8)
                throw new Exception("Выход за пределы двоичного числа");

            result += Convert.ToInt32(str, 2);
        }

        if (result > Int32.MaxValue)
            throw new Exception("Выход за пределы int");

        return result;
    }
}