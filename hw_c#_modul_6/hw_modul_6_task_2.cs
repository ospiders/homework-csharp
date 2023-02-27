using static System.Console;

namespace charp
{
    class Program
    {
        static void Main()
        {
            Kettle kettle = new("Samsung");

            kettle.Sound();
            kettle.Show();
            kettle.Desc();

            WriteLine();

            Automobile automobile = new("Lada");

            automobile.Sound();
            automobile.Show();
            automobile.Desc();

        }
    }

    abstract class Device
    {
        protected string _name;
        public Device(string name) { _name = name; }
        public abstract void Sound();
        public abstract void Show();
        public abstract void Desc();
    }

    class Kettle : Device
    {
        public Kettle(string name) : base(name) { }

        public override void Sound()
        {
            WriteLine("Звук чайника");
        }
        public override void Show()
        {
            WriteLine($"Название: {_name}");
        }
        public override void Desc()
        {
            WriteLine("Металлический, электрический, термоизолированный");
        }
    }

    class Microwave : Device
    {
        public Microwave(string name) : base(name) { }

        public override void Sound()
        {
            WriteLine("Звук микроволновки");
        }
        public override void Show()
        {
            WriteLine($"Название: {_name}");
        }
        public override void Desc()
        {
            WriteLine("Большое меню, пароочистка");
        }
    }

    class Automobile : Device
    {
        public Automobile(string name) : base(name) { }

        public override void Sound()
        {
            WriteLine("Звук автомобиля");
        }
        public override void Show()
        {
            WriteLine($"Название: {_name}");
        }
        public override void Desc()
        {
            WriteLine("Стильный дизайн, полная проходимость");
        }
    }

    class Steamship : Device
    {
        public Steamship(string name) : base(name) { }

        public override void Sound()
        {
            WriteLine("Звук парохода");
        }
        public override void Show()
        {
            WriteLine($"Название: {_name}");
        }
        public override void Desc()
        {
            WriteLine("Большой, вместительный");
        }
    }
}