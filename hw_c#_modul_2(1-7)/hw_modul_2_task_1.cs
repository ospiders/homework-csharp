using static System.Console;

namespace System
{
    static class hw_modul_2_task_1
    {
        static void Main()
        {
            double[] A = new double[5];
            double[,] B = new double[4, 3];

            Random rand = new Random();

            for (int i = 0; i < A.Length; i++)
                A[i] = double.Parse(ReadLine() ?? string.Empty);

            for (int i = 0; i < B.GetLength(0); i++)
                for (int j = 0; j < B.GetLength(1); j++)
                    B[i, j] = Math.Round((rand.NextDouble() * (10 - 1) + 1), 1);

            for (int i = 0; i < A.Length; i++)
                Write("{0, -10} ", A[i]);

            WriteLine();

            for (int i = 0; i < B.GetLength(0); i++)
            {
                for (int j = 0; j < B.GetLength(1); j++)
                    Write("{0, -10} ", B[i, j]);

                WriteLine();
            }

            WriteLine();


            if (A.Max() == B.Cast<double>().Max())
            {
                WriteLine("Найдено совпадение в максимальном значении {0}", A.Max());
            }

            if (A.Min() == B.Cast<double>().Min())
            {
                WriteLine("Найдено совпадение в минимальном значении {0}", A.Max());

            }

            double all_sum = 0.0;
            double all_mult = 1.0;
            double all_even = 0.0;
            double all_in_odd_col = 0.0;

            foreach (double i in B)
            {
                all_sum += i;
                all_mult *= i;
            }

            foreach(double i in A)
            {
                all_sum += i;
                all_mult *= i;
                if (i % 2 == 0)
                    all_even += i;
            }

            for (int i = 0; i < B.GetLength(0); i++)
            {
                for (int j = 0; j < B.GetLength(1); j++)
                {
                    if(j % 2 == 1)
                        all_in_odd_col += B[i, j];

                }
            }

            WriteLine("Сумма значений массива A и В {0}\n" +
                "Произведение значений массива A и B {1}\n" +
                "Сумма четных значений массива A {2}\n" +
                "Сумма нечетных столбцов массива В {3}",
                all_sum, all_mult, all_even, all_in_odd_col);
        }
    }
}