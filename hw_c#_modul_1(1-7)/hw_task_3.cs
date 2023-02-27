using static System.Console;

namespace Task3
{
    class Task3
    {
        static void Main()
        {
            int input_number = 0;
            do
            {
                try
                {
                    WriteLine("������� �����: ");
                    input_number = int.Parse(ReadLine() ?? string.Empty);
                }
                catch (FormatException)
                {
                    WriteLine("�������� ������");
                }

            } while (input_number == 0 || input_number > 9999);

            WriteLine("���������: " + input_number);

            return;
        }
    }
}