using static System.Console;

namespace Task6
{
    static class Task6
    {
        private static void Main()
        {
            WriteLine("������� ����������� � ������� ����� � ������� ��������� (23c ��� 5F): ");

            while (true)
            {
                string input = ReadLine() ?? string.Empty;
                int? number = null;
                char? temperature_pick = null;

                try
                {
                    number = int.Parse(input.Remove(input.Length - 1));
                    temperature_pick = char.ToLower(input[input.Length - 1]);
                }

                catch(ArgumentException)
                {
                    WriteLine("������ ���������");
                }
                catch (FormatException)
                {
                    WriteLine("������ �������");
                }

                switch (temperature_pick)
                {
                    case 'c':
                        WriteLine($"����������� ���������� ��� �������, ������� � ����������: {(number - 32) * 5 / 9}F");
                        break;
                    case 'f':
                        WriteLine($"����������� ���������� ��� ����������, ������� � �������: {(number * 9 / 5) + 32}C");
                        break;
                    default:
                        WriteLine("�� �� ����� ������� ��������� (C ��� F)");
                        break;
                }
            }
        }
    }
}
