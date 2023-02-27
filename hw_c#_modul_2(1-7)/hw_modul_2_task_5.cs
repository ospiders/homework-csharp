/*Задание 5
Пользователь с клавиатуры вводит в строку арифметическое выражение.
Приложение должно посчитать его результат. 
Необходимо поддерживать только две операции: + и – */

using System.Data;
using System.Globalization;
using static System.Console; 

namespace charp
{
    internal class hw_modul_2_task_5
    {
        static void Main()
        {
            //string? res = null;
            //WriteLine("Введите в строку арифметическое выражение: ");
            //try
            //{
            //    res = new DataTable().Compute(ReadLine(), null).ToString();
            //}

            //catch(DataException e)
            //{
            //    WriteLine(e.Message);
            //}

            //WriteLine(res);

            string? input_text = null;
            int left_num = 0;
            char sign = ' ';
            int right_num = 0;
            string[]? arr = null;

            WriteLine("Введите в строку арифметическое выражение: ");
            do
            {
                try
                {
                    input_text = ReadLine() ?? string.Empty;

                    if (input_text.Contains('+'))
                        sign = '+';
                    else if (input_text.Contains('-'))
                        sign = '-';
                    else
                        throw new Exception("Поддерживаемые операторы: + -");

                    if(input_text.Contains('+') || input_text.Contains('-'))
                    {
                        arr = input_text.Split(" +-".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                        if (arr.Length < 2)
                            throw new Exception("Отсутствует один операнд");
                        else
                        {
                            left_num = int.Parse(arr[0]);
                            right_num = int.Parse(arr[1]);
                        }
                    }
                }
                catch (FormatException err)
                {
                    input_text = null;
                    WriteLine(err.Message);
                }
                catch (Exception e)
                {
                    input_text = null;
                    WriteLine(e.Message);
                }

            } while (input_text == null);

            switch (sign)
            {
                case '+':
                    WriteLine(left_num + right_num);
                    break;

                case '-':
                    WriteLine(left_num - right_num);
                    break;

                default:
                    break;
            }
        }
    }
}