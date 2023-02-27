/* Дан двумерный массив размерностью 5×5, заполненный случайными
 * числами из диапазона от –100 до 100. Определить сумму элементов
 * массива, расположенных между минимальным и максимальным элементами.*/

using static System.Console;

namespace charp
{
    class hw_modul_2_task_2
    {
        static void Main()
        {
            int[,] ints = new int[5, 5];
            int sum_of_ints = 0;
            Random rand = new();

            for (int i = 0; i < ints.GetLength(0); i++)
            {
                for (int j = 0; j < ints.GetLength(1); j++)
                {
                    ints[i, j] = rand.Next(-100, 100);
                    Write("{0, -5} ", ints[i, j]);
                }
                WriteLine();
            }

            foreach (int i in ints)
                sum_of_ints += i;

            WriteLine("Сумма всех значений в массиве {0}", sum_of_ints);
        }
    }
}