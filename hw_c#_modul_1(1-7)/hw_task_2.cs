/*������� 2
������������ ������ � ���������� ��� �����. ������ 
����� ��� ��������, ������ ����� �������, ������� 
���������� ���������. ��������, �� ����� � ���������� 
90 � 10. ��������� ������� �� ����� 10 ��������� �� 90. 
���������: 9.*/
using static System.Console;

namespace Task2
{
    class Task2
    {
        static void Main()
        {
            double input_number = 0;
            double input_percent = 0;
            do
            {
                try
                {
                    WriteLine("������� �����: ");
                    input_number = double.Parse(ReadLine() ?? string.Empty);
                    WriteLine("������� �������: ");
                    input_percent = double.Parse(ReadLine() ?? string.Empty);
                }
                catch (FormatException)
                {
                    WriteLine("�������� ������");
                }

            } while (input_number == 0 || input_percent == 0);
            
            WriteLine("���������: " + (input_number * input_percent / 100).ToString());

            return;
        }
    }
}