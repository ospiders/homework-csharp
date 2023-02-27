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
                    WriteLine("Введите число: ");
                    input_number = double.Parse(ReadLine() ?? string.Empty);
                    WriteLine("Введите процент: ");
                    input_percent = double.Parse(ReadLine() ?? string.Empty);
                }
                catch (FormatException)
                {
                    WriteLine("Неверный формат");
                }

            } while (input_number == 0 || input_percent == 0);
            
            WriteLine("Результат: " + (input_number * input_percent / 100).ToString());

            return;
        }
    }
}