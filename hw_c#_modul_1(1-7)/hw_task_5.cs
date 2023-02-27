﻿using static System.Console;

namespace Task5
{
    class Task5
    {
        static void Main()
        {
            DateTime dt;

            WriteLine("Введите дату(dd.mm.yyyy): ");
            dt = DateTime.Parse(ReadLine() ?? string.Empty);
            
            if (dt.Month < 3 || dt.Month == 12)
                Write("Winter ");

            else if (dt.Month < 6)
                Write("Spring ");

            else if (dt.Month < 9)
                Write("Summer ");

            else if (dt.Month < 12)
                Write("Autumn ");
                
            WriteLine(dt.DayOfWeek);

            return;
        }
    }
}