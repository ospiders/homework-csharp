using static System.Console;

namespace charp
{
    class Program
    {
        static bool BoolStringExpression(string expression)
        {
            string[] toCheck = { "<", ">", "<=", ">=", "!=", "==" };
            string[] operands;

            if (toCheck.Any(expression.Contains))
            {
                operands = expression.Split(toCheck, StringSplitOptions.TrimEntries);
            }
            else
            {
                throw new Exception("ÍÅÒÓ ÎÏÅÐÀÒÎÐÀ");
            }

            int l_operand = int.Parse(operands[0]);
            int r_operand = int.Parse(operands[1]);


            if (expression.Contains(">="))
                return l_operand >= r_operand;

            else if (expression.Contains("<="))
                return l_operand <= r_operand;

            else if (expression.Contains(">"))
                return l_operand > r_operand;

            else if (expression.Contains("<"))
                return l_operand < r_operand;

            else if (expression.Contains("=="))
                return l_operand == r_operand;

            else if (expression.Contains("!="))
                return l_operand != r_operand;

            return false;
        }
        static void Main()
        { 
            try
            {
                if (BoolStringExpression("32<2"))
                    WriteLine("TRUE");
                else
                    WriteLine("FALSE");
            }
            catch (Exception er)
            {
                WriteLine(er.Message);
            }

        }
    }
}
