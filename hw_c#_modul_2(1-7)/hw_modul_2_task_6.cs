/*Задание 6
Пользователь с клавиатуры вводит некоторый текст. 
Приложение должно изменять регистр первой буквы 
каждого предложения на букву в верхнем регистре.
Например, если пользователь ввёл: 
«today is a good day for walking. i will try to walk near the sea».
Результат работы приложения: 
«Today is a good day for walking. I will try to walk near the sea».*/

using static System.Console;

namespace charp
{
    internal class hw_modul_2_task_6
    {
        static void Main()
        {

            StringBuilder str = new("today. is a good day for walking. i will try to walk. near the sea");

            WriteLine("Старая строка: " + str);

            for (int i = 0; i < str.Length - 2; i++)
            {
                if (str[i] == '.' && str[i + 1] == ' ')
                    str[i + 2] = char.ToUpper(str[i + 2]);
            }

            WriteLine("Новая строка: " + str);
        }
    }
}