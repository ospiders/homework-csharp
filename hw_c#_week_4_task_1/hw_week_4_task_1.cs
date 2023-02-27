/*Задание 1. Игра «Автомобильные гонки»
Разработать игру "Автомобильные гонки" с использованием делегатов.
1. В игре использовать несколько типов автомобилей: 
спортивные, легковые, грузовые и автобусы.
2. Реализовать игру «Гонки». Принцип игры: Автомобили двигаются от старта к финишу со скоростями, 
которые изменяются в установленных пределах 
случайным образом. Победителем считается автомобиль, пришедший к финишу первым.
Рекомендации по выполнению работы
1. Разработать абстрактный класс «автомобиль» 
(класс Car). Собрать в нем все общие поля, свойства 
(например, скорость) методы (например, ехать).
2. Разработать классы автомобилей с конкретной 
реализацией конструкторов и методов, свойств. 
В классы автомобилей добавить необходимые события (например, финиш).
3. Класс игры должен производить запуск соревнований автомобилей, выводить сообщения о текущем 
положении автомобилей, выводить сообщение об 
автомобиле, победившем в гонках. Создать делегаты, обеспечивающие вызов методов из классов 
автомобилей (например, выйти на старт, начать гонку). 
4. Игра заканчивается, когда какой-то из автомобилей 
проехал определенное расстояние (старт в положении 0, финиш в положении 100). Уведомление об 
окончании гонки (прибытии какого-либо автомобиля на финиш) реализовать с помощью событий.
*/

using static System.Console;

enum CarSpeed
{
    Low = 70,
    Middle = 90,
    High = 110,
    SuperHigh = 140
}

enum BonusSpeed
{
    Low = 10,
    Medium = 50,
    High = 100,
}

namespace GameRace
{
    class Program
    {
        static void Main()
        {
            List<Car> cars = new()
            {
                new RacingCar((int)CarSpeed.SuperHigh, "Гоночный автомобиль"),
                new PassengerCar((int)CarSpeed.High, "Пассажирский автомобиль"),
                new Bus((int)CarSpeed.Middle, "Автобус"),
                new Truck((int)CarSpeed.Low, "Грузовой автомобиль")
            };

            foreach (Car item in cars)
            {
                WriteLine(item);
            }

            WriteLine(new string('-', 30));

            CarRace.Start(cars);

            foreach (Car item in cars)
            {
                CarRace.Drive += item.Drive;
            }

            WriteLine("\n\n");

            CarRace.NumberOfCars = CarRace.GetHandlersCount();

            do
            {
                CarRace.CarDrive(CarRace.Distance);

                WriteLine(new string('-', 30));

                CarRace.Distance -= 10;

            } while (CarRace.GetHandlersCount() != 0);

        }
    }

    delegate void DriveDelegate(int distance);

    class CarRace
    {
        public static event DriveDelegate Drive;
        static public int NumberOfCars { get; set; }
        static public int Distance { get; set; }

        public static int GetHandlersCount()
        {
            var eventHandler = Drive;

            if (eventHandler != null)
                return eventHandler.GetInvocationList().Length;

            else return 0;
        }

        static CarRace()
        {
            Distance = 100;
        }
        public static void CarDrive(int distance)
        {
            Drive?.Invoke(distance);
        }

        static public string PrintAllCars(Car car)
        {
            return $"{car.Name} {car.Speed}";
        }

        static public void Start(List<Car> car)
        {
            Random rnd = new();

            foreach (var item in car)
            {
                BonusSpeed[] BonusSpeedValues = Enum.GetValues(typeof(BonusSpeed)).Cast<BonusSpeed>().ToArray();

                item.Speed += (int)BonusSpeedValues[rnd.Next(BonusSpeedValues.Length)];
            }
        }
    }

    class Car
    {
        public int Speed { get; set; }
        public string Name { get; set; }
        public Car(int speed, string name)
        {
            Speed = speed;
            Name = name;
        }

        public int CarPlace { get; set; }
        public int Distance { get; set; }
        public void Drive(int distance)
        {
            Distance = distance - Speed / 10;

            if (Distance > 0)
                WriteLine($"{Name} в движении, осталось проехать {Distance} км");

            else
                Finish();
        }

        public void Finish()
        {
            CarPlace = CarRace.NumberOfCars - (CarRace.GetHandlersCount() - 1);

            CarRace.Drive -= Drive;

            WriteLine($"{Name} закончил гонку. Занял {CarPlace} место");
        }
        public override string ToString()
        {
            return $"{Name} {Speed}";
        }
    }

    class RacingCar : Car
    {
        public RacingCar(int speed, string name) : base(speed, name) { }
    }

    class PassengerCar : Car
    {
        public PassengerCar(int speed, string name) : base(speed, name) { }
    }

    class Bus : Car
    {
        public Bus(int speed, string name) : base(speed, name) { }
    }

    class Truck : Car
    {
        public Truck(int speed, string name) : base(speed, name) { }
    }
}