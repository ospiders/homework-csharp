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
                    WriteLine("Введите число: ");
                    input_number = int.Parse(ReadLine() ?? string.Empty);
                    if (input_number > 999999)
                        throw new Exception("Введено больше 6 цифр");

                    WriteLine("Введите первый номер разряда числа: ");
                    iterator_start = int.Parse(ReadLine() ?? string.Empty);
                    if (input_number.ToString().Length < iterator_start || iterator_start < 1)
                    {
                        iterator_start = 0;
                        throw new Exception("Введено число меньше 1 или больше введенного числа");
                    }

                    WriteLine("Введите второй номер разряда числа: ");
                    iterator_end = int.Parse(ReadLine() ?? string.Empty);
                    if (input_number.ToString().Length < iterator_end || iterator_end < 1)
                    {
                        iterator_end = 0;
                        throw new Exception("Введено число меньше 1 или больше введенного числа");
                    }
                }
                catch (FormatException)
                {
                    WriteLine("Неверный формат");
                }
                catch (Exception err)
                {
                    WriteLine($"Ошибка: {err.Message}");
                }

            } while (input_number == 0 || iterator_start == 0 || iterator_end == 0);

            char[] temp = input_number.ToString().ToArray();
            char buf;

            buf = temp[iterator_start - 1];
            temp[iterator_start - 1] = temp[iterator_end - 1];
            temp[iterator_end - 1] = buf;

            WriteLine("Результат: ");
            foreach (char c in temp)
                Write(c);

            WriteLine();

            return;
        }
    }
}