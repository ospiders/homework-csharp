/*«адание 7
ѕользователь вводит с клавиатуры два числа. Ќужно показать все
четные числа в указанном диапазоне. ≈сли границы диапазона 
указаны неправильно требуетс€ произвести нормализацию границ.
Ќапример, пользователь ввел 20 и 11, требуетс€ нормализаци€,
после которой начало диапазона станет равно 11, а конец 20*/
using static System.Console;

namespace Task7
{
    class Task7
    {
        static void Main()
        {
            int? input_num_left = null;
            int? input_num_right = null;
            do {
                try
                {
                    Write("¬ведите первое число: ");
                    input_num_left = int.Parse(ReadLine() ?? string.Empty);
                    Write("¬ведите второе число: ");
                    input_num_right = int.Parse(ReadLine() ?? string.Empty);
                }
                catch (FormatException)
                {
                    WriteLine("Ќеверный формат");
                }
            } while(input_num_left == null || input_num_right == null);

            if(input_num_left > input_num_right)
               (input_num_left, input_num_right) = (input_num_right, input_num_left);

            while(input_num_left != input_num_right + 1)
            {
                Write(input_num_left++ + " ");
            }
            return;
        }
    }
}