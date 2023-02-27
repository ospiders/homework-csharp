/*Задание 4
Создайте приложение, которое производит операции 
над матрицами:
■ Умножение матрицы на число;
■ Сложение матриц;
■ Произведение матриц.*/

using static System.Console;

namespace charp
{
    internal class hw_modul_2_task_4
    {
        static void MultMatrixByMatrix(int[,] mat1, int[,] mat2)
        {
            int R1 = mat1.GetLength(0);
            int C1 = mat1.GetLength(1);
            int R2 = mat2.GetLength(0);
            int C2 = mat2.GetLength(1);

            try
            {
                if (C1 != R2)
                {
                    throw new Exception("Количество столбцов в Матрице-1 должно быть равно количеству строк в Матрице-2.\n");
                }
            }
            catch (Exception err)
            {
                WriteLine(err.Message);
                return;
            }


            int[,] rslt = new int[R1, C2];
            WriteLine("\nПеремножение двух матриц:");

            for (int i = 0; i < R1; i++)
            {
                for (int j = 0; j < C2; j++)
                {
                    for (int k = 0; k < R2; k++)
                    {
                        rslt[i, j] += mat1[i, k] * mat2[k, j];

                        Write(mat1[i, k] + " * " + mat2[k, j]);

                        if (k != R2 - 1)
                            Write(" + ");
                    }
                    Write(" = " + rslt[i, j] + "\t");
                }
                WriteLine();
            }
        }

        static void MultMatrixByNumber(int[,] mat1, int number)
        {
            int R1 = mat1.GetLength(0);
            int C1 = mat1.GetLength(1);

            int[,] rslt = new int[R1, C1];

            WriteLine("\nПеремножение матрицы на число:");

            for (int i = 0; i < R1; i++)
            {
                for (int j = 0; j < C1; j++)
                {
                    for (int k = 0; k < R1; k++)
                    {
                        rslt[i, j] += mat1[i, k] * number;

                        Write(mat1[i, k] + " * " + number);

                        if (k != R1 - 1)
                            Write(" + ");
                    }
                    Write(" = " + rslt[i, j] + "\t");
                }
                WriteLine();
            }
        }

        static void AddMatrixByMatrix(int[,] mat1, int[,] mat2)
        {
            int R1 = mat1.GetLength(0);
            int C1 = mat1.GetLength(1);
            int R2 = mat2.GetLength(0);
            int C2 = mat2.GetLength(1);

            try
            {
                if (C1 != R2 || C2 != R1)
                {
                    throw new Exception("Матрицы должны быть одного размера.\n");
                }
            }
            catch (Exception err)
            {
                WriteLine(err.Message);
                return;
            }


            int[,] rslt = new int[R1, C2];
            WriteLine("\nСложение двух матриц:");

            for (int i = 0; i < R1; i++)
            {
                for (int j = 0; j < C2; j++)
                {
                    for (int k = 0; k < R2; k++)
                    {
                        rslt[i, j] += mat1[i, k] + mat2[k, j];

                        Write(mat1[i, k] + " + " + mat2[k, j]);

                        if (k != R2 - 1)
                            Write(" + ");
                    }
                    Write(" = " + rslt[i, j] + "\t");
                }
                WriteLine();
            }
        }

        static void Main()
        {
            int[,] mat1 = { { 1, 2 },
                            { 4, 3 } };

            int[,] mat2 = { { 7, 1 , 4},
                            { 2, 0 , 5} };

            MultMatrixByMatrix(mat1, mat2);

            MultMatrixByNumber(mat1, 5);

            AddMatrixByMatrix(mat1, mat2);
        }
    }
}