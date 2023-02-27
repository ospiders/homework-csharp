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
                    Write("������� ������ �����: ");
                    input_num_left = int.Parse(ReadLine() ?? string.Empty);
                    Write("������� ������ �����: ");
                    input_num_right = int.Parse(ReadLine() ?? string.Empty);
                }
                catch (FormatException)
                {
                    WriteLine("�������� ������");
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