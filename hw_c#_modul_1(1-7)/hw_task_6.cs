using static System.Console;

namespace Task6
{
    static class Task6
    {
        private static void Main()
        {
            WriteLine("Введите температуру в формате число и единица измерения (23c или 5F): ");

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
                    WriteLine("Ошибка аргумента");
                }
                catch (FormatException)
                {
                    WriteLine("Ошибка формата");
                }

                switch (temperature_pick)
                {
                    case 'c':
                        WriteLine($"Температура определена как Цельсий, перевод в Фаренгейты: {(number - 32) * 5 / 9}F");
                        break;
                    case 'f':
                        WriteLine($"Температура определена как Фаренгейты, перевод в Цельсий: {(number * 9 / 5) + 32}C");
                        break;
                    default:
                        WriteLine("Вы не ввели единицы измерения (C или F)");
                        break;
                }
            }
        }
    }
}
