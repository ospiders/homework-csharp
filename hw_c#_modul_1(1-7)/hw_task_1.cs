using static System.Console;

namespace Task1
{
    class Task1
    {
        static bool MultOfThree(int? number)
        {
            return number % 3 == 0;
        }
        static bool MultOfFive(int? number)
        {
            return number % 5 == 0;
        }


        static void Main()
        {
            int input_number = 0;
            do
            {                    
                WriteLine("Введите число в диапазоне от 1 до 100: ");

                try
                {
                    input_number = int.Parse(ReadLine() ?? string.Empty);
                }
                catch(FormatException)
                {
                    WriteLine("Неверный формат");
                }

            } while (input_number < 1 || input_number > 100);


            if (MultOfThree(input_number) && MultOfFive(input_number))
                WriteLine("Fizz Buzz");

            else if (MultOfThree(input_number))
                WriteLine("Fizz");

            else if (MultOfFive(input_number))
                WriteLine("Buzz");

            else
                WriteLine(input_number);

            return;
        }
    }
}