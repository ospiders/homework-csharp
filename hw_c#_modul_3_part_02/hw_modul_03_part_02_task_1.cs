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
                Write("�������� ����������� �������� ������� ����������\n\n" +
                      "1 - �� ���������� � ��������.\n" +
                      "2 - �� �������� � ����������.\n" +
                      "0 - �����.\n> ");
                choice = short.Parse(ReadLine() ?? "0");

                switch (choice)
                {
                    case 0:
                        WriteLine("�����");
                        break;
                    case 1:
                        WriteLine("�� ������� ������� ����� �� ���������� ������� ��������� � ��������\n");
                        WriteLine($"��������� - {FromDecToBin()}\n");
                        break;
                    case 2:
                        WriteLine("�� ������� ������� ����� �� �������� ������� ��������� � ����������\n");
                        WriteLine($"��������� - {FromBinToDec()}\n");
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

// ������� 1
class Calculator
{
    public static string FromDecToBin()
    {
        Write("������� ����� ���������� ������� ���������:\n> ");
        int input_dec_num = int.Parse(ReadLine() ?? "0");

        return Convert.ToString(input_dec_num, 2);
    }

    public static int FromBinToDec()
    {
        Write("������� ����� �������� ������� ���������:\n> ");
        string input_bin_num = ReadLine() ?? "0";

        int result = 0;

        foreach (string str in input_bin_num.Split(' '))
        {
            if (str.Length > 8)
                throw new Exception("����� �� ������� ��������� �����");

            result += Convert.ToInt32(str, 2);
        }

        if (result > Int32.MaxValue)
            throw new Exception("����� �� ������� int");

        return result;
    }
}