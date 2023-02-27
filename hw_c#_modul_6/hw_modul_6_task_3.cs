using static System.Console;

namespace charp
{
    class Program
    {
        static void Main()
        {
            Violin violin = new("Dame");

            violin.Sound();
            violin.Show();
            violin.Desc();
            violin.History();

            WriteLine();

            Ukulele ukulele = new("Saary");

            ukulele.Sound();
            ukulele.Show();
            ukulele.Desc();
            ukulele.History();

        }
    }

    abstract class MusicalInstrument
    {
        protected string _name;

        public MusicalInstrument(string name) { _name = name; }

        public abstract void Sound();
        public abstract void Show();
        public abstract void Desc();
        public abstract void History();

    }

    class Violin : MusicalInstrument
    {
        public Violin(string name) : base(name) { }
        public override void Sound()
        {
            WriteLine("Звук скрипки");
        }

        public override void Show()
        {
            WriteLine($"Название: {_name}");
        }

        public override void Desc()
        {
            WriteLine("Описание скрипки");
        }
        public override void History()
        {
            WriteLine("История скрипки");
        }
    }

    class Trombone : MusicalInstrument
    {
        public Trombone(string name) : base(name) { }

        public override void Sound()
        {
            WriteLine("Звук тромбона");
        }

        public override void Show()
        {
            WriteLine($"Название: {_name}");
        }

        public override void Desc()
        {
            WriteLine("Описание тромбона");
        }
        public override void History()
        {
            WriteLine("История тромбон");
        }
    }

    class Ukulele : MusicalInstrument
    {
        public Ukulele(string name) : base(name) { }

        public override void Sound()
        {
            WriteLine("Звук укулеле");
        }

        public override void Show()
        {
            WriteLine($"Название: {_name}");
        }

        public override void Desc()
        {
            WriteLine("Описание укулеле");
        }
        public override void History()
        {
            WriteLine("История укулеле");
        }
    }

    class Cello : MusicalInstrument
    {

        public Cello(string name) : base(name) { }
        public override void Sound()
        {
            WriteLine("Звук виолончели");
        }

        public override void Show()
        {
            WriteLine($"Название: {_name}");
        }
        public override void Desc()
        {
            WriteLine("Описание виолончели");
        }
        public override void History()
        {
            WriteLine("История виолончели");
        }
    }
}