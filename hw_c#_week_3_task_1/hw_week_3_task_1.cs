using System;


namespace HouseBuilding
{
    interface IWorker
    {

    }

    class Team : IWorker
    {
        public string TeamName { get; set; }

        public Team(string team_name)
        {
            TeamName = team_name;
        }

        public override string ToString()
        {
            return $"Имя бригады: {TeamName}";
        }

        public bool CheckBasement(House stage)
        {
            if (stage.basement == null) return false;

            return true;
        }

        public bool CheckWalls(House stage)
        {
            if (stage.walls == null || stage.walls.Count < 4) return false;

            return true;
        }

        public bool CheckWindows(House stage)
        {
            if (stage.window == null || stage.window.Count < 4) return false;

            return true;
        }

        public bool CheckDoor(House stage)
        {
            if (stage.door == null) return false;

            return true;
        }
        public bool CheckRoof(House stage)
        {
            if (stage.roof == null) return false;

            return true;
        }
    }
    class TeamLeader : Team
    {
        public string? LeaderName { get; set; }
        public string? ReportСonstruction { get; set; }

        public TeamLeader(string team_name, string human_name) : base(team_name)
        {
            LeaderName = human_name;
        }

        public void SetСonstruction(House stage)
        {
            if (!CheckBasement(stage))
            {
                ReportСonstruction = "Дом еще не строился.";
                return;
            }

            if (CheckBasement(stage))
                ReportСonstruction = "Фундамент готов. ";

            if (CheckWalls(stage))
                ReportСonstruction += "Стены построены. ";

            if (CheckWindows(stage))
                ReportСonstruction += "Окна установлены. ";

            if (CheckDoor(stage))
                ReportСonstruction += "Дверь установлена. ";

            if (CheckRoof(stage))
            {
                ReportСonstruction += "Крыша установлена. ";
                ReportСonstruction += "Дом полностью построен.";
            }
        }

        public void PrintReport()
        {
            Console.WriteLine(ReportСonstruction);
        }

        public override string ToString()
        {
            return base.ToString() + $", Бригадир: {LeaderName}\n";
        }
    }
    class Worker : Team
    {
        public Worker(string team_name, string worker_name) : base(team_name)
        {
            HumanName = worker_name;
        }

        public string HumanName { get; set; }

        public void Build(House house)
        {
            if (!CheckBasement(house))
            {
                Basement.Make(house);
                Console.WriteLine($"{this} - {house.basement}");
            }

            else if (!CheckWalls(house))
            {
                Walls.Make(house);
                Console.WriteLine($"{this} - {house.walls[0]}");
            }

            else if (!CheckWindows(house))
            {
                Windows.Make(house);
                Console.WriteLine($"{this} - {house.window[0]}");
            }

            else if (!CheckDoor(house))
            {
                Door.Make(house);
                Console.WriteLine($"{this} - {house.door}");
            }

            else if (!CheckRoof(house))
            {
                Roof.Make(house);
                Console.WriteLine($"{this} - {house.roof}");
            }

            else
                throw new Exception("Ошибка выбора");
        }

        public override string ToString()
        {
            return base.ToString() + $", Рабочий: {HumanName}";
        }
    }


    interface IPart
    {
        public static void Make(House house) { }
    }
    class House
    {
        public Basement? basement;
        public List<Walls>? walls = new();
        public List<Windows>? window = new();
        public Door? door;
        public Roof? roof;

        public string? HouseName { get; set; }
        public House() { HouseName = "Безымянный"; }
        public House(string name)
        {
            HouseName = name;
        }
        public override string ToString()
        {
            return $"Название дома: {HouseName}\n";
        }
    }

    class Basement : IPart
    {
        public Basement() { }
        public static void Make(House house)
        {
            house.basement = new Basement();
        }
         public override string ToString() { return "Строю фундамент\n"; }
    }
    class Walls : IPart
    {
        public Walls() { }

        public static void Make(House house)
        {
            house.walls.Add(new Walls());
        }

        public override string ToString() { return "Строю стену\n"; }

    }
    class Door : IPart
    {
        public Door() { }
        public static void Make(House house)
        {
            house.door = new Door();
        }
        public override string ToString() { return "Строю дверь\n"; }

    }
    class Windows : IPart
    {
        public Windows() { }
        public static void Make(House house)
        {
            house.window.Add(new Windows());
        }
        public override string ToString() { return "Строю окно\n"; }

    }
    class Roof : IPart
    {
        public Roof() { }
        public static void Make(House house)
        {
            house.roof = new Roof();
        }
        public override string ToString() { return "Строю крышу\n"; }
    }


    class Program
    {
        static void Main()
        {
            TeamLeader teamleader = new("Bravo", "Elvis");
            Worker vasya = new("Bravo", "Vasya");
            House house = new("Korob");

            for(int i = 0; i < 11; i++)
                vasya.Build(house);

            teamleader.SetСonstruction(house);

            Console.WriteLine($"{teamleader}{house}{teamleader.ReportСonstruction}");

            Console.WriteLine("\n");

            House house1 = new("Dobrik");
            TeamLeader team = new("Charlie", "Ragnar");

            team.SetСonstruction(house1);
            Console.WriteLine($"{team}{house1}{team.ReportСonstruction}");

        }
    }
}
