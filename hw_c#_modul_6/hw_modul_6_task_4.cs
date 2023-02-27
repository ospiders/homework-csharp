using static System.Console;

namespace charp
{
    class Program
    {
        static void Main()
        {
            Security security = new();

            security.Print();

            Engineer engineer = new();

            engineer.Print();
        }
    }

    abstract class Worker { public abstract void Print(); }

    class President : Worker { public override void Print() => WriteLine("���������"); }

    class Security : Worker { public override void Print() => WriteLine("��������"); }

    class Manager : Worker { public override void Print() => WriteLine("��������"); }

    class Engineer : Worker { public override void Print() => WriteLine("�������"); }
}