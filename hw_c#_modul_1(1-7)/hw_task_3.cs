/*Задание 3
Пользователь вводит с клавиатуры четыре цифры. 
Необходимо создать число, содержащее эти цифры. 
Например, если с клавиатуры введено 1, 5, 7, 8 тогда нужно 
сформировать число 1578.*/
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
                    WriteLine("Введите число: ");
                    input_number = int.Parse(ReadLine() ?? string.Empty);
                }
                catch (FormatException)
                {
                    WriteLine("Неверный формат");
                }

            } while (input_number == 0 || input_number > 9999);

            WriteLine("Результат: " + input_number);

            return;
        }
    }
}