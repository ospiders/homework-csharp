using static System.Console;

namespace Task4
{
    class Task4
    {
        static void Main()
        {
            int input_number = 0;
            int iterator_start = 0;
            int iterator_end = 0;
            do
            {
                try
                {
                    WriteLine("������� �����: ");
                    input_number = int.Parse(ReadLine() ?? string.Empty);
                    if (input_number > 999999)
                        throw new Exception("������� ������ 6 ����");

                    WriteLine("������� ������ ����� ������� �����: ");
                    iterator_start = int.Parse(ReadLine() ?? string.Empty);
                    if (input_number.ToString().Length < iterator_start || iterator_start < 1)
                    {
                        iterator_start = 0;
                        throw new Exception("������� ����� ������ 1 ��� ������ ���������� �����");
                    }

                    WriteLine("������� ������ ����� ������� �����: ");
                    iterator_end = int.Parse(ReadLine() ?? string.Empty);
                    if (input_number.ToString().Length < iterator_end || iterator_end < 1)
                    {
                        iterator_end = 0;
                        throw new Exception("������� ����� ������ 1 ��� ������ ���������� �����");
                    }
                }
                catch (FormatException)
                {
                    WriteLine("�������� ������");
                }
                catch (Exception err)
                {
                    WriteLine($"������: {err.Message}");
                }

            } while (input_number == 0 || iterator_start == 0 || iterator_end == 0);

            char[] temp = input_number.ToString().ToArray();
            char buf;

            buf = temp[iterator_start - 1];
            temp[iterator_start - 1] = temp[iterator_end - 1];
            temp[iterator_end - 1] = buf;

            WriteLine("���������: ");
            foreach (char c in temp)
                Write(c);

            WriteLine();

            return;
        }
    }
}