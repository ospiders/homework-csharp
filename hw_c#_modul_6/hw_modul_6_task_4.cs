/*Задание 4
Создать абстрактный базовый класс Worker (работника) 
с методом Print(). Создайте четыре производных класса: 
President, Security, Manager, Engineer. Переопределите метод
Print() для вывода информации, соответствующей 
каждому типу работника*/

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

    class President : Worker { public override void Print() => WriteLine("Президент"); }

    class Security : Worker { public override void Print() => WriteLine("Охранник"); }

    class Manager : Worker { public override void Print() => WriteLine("Менеджер"); }

    class Engineer : Worker { public override void Print() => WriteLine("Инженер"); }
}