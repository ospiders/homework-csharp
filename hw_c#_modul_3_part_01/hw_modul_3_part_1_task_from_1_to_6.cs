/*
Задание 1
Напишите метод, который отображает квадрат из 
некоторого символа. Метод принимает в качестве
параметра: длину стороны квадрата, символ

Задание 2
Напишите метод, который проверяет является ли 
переданное число «палиндромом». Число передаётся в 
качестве параметра. Если число палиндром нужно вернуть
из метода true, иначе false.
Палиндром — число, которое читается одинаково как 
справа налево, так и слева направо. Например:
1221 — палиндром;
3443 — палиндром;
7854 — не палиндром.

Задание 3
Напишите метод, фильтрующий массив на основании 
переданных параметров. Метод принимает параметры: 
оригинальный_массив, массив_с_данными_для_фильтрации.
Метод возвращает оригинальный массив без элементов,
которые есть в массиве для фильтрации.
Например:
1 2 6 -1 88 7 6 — оригинальный массив;
6 88 7 — массив для фильтрации;
1 2 -1 — результат работы метода.

Задание 4
Создайте класс «Веб-сайт». Необходимо хранить в 
полях класса: название сайта, путь к сайту, описание 
сайта, ip адрес сайта. Реализуйте методы класса для ввода 
данных, вывода данных, реализуйте доступ к отдельным 
полям через методы класса.

Задание 5
Создайте класс «Журнал». Необходимо хранить в 
полях класса: название журнала, год основания, 
описание журнала, контактный телефон, контактный e-mail. 
Реализуйте методы класса для ввода данных, вывода 
данных, реализуйте доступ к отдельным полям через 
методы класса.

Задание 6
Создайте класс «Магазин». Необходимо хранить в 
полях класса: название магазина, адрес, описание
профиля магазина, контактный телефон, контактный e-mail. 
Реализуйте методы класса для ввода данных, вывода 
данных, реализуйте доступ к отдельным полям через 
методы класса
 */

using static System.Console;

namespace charp
{
    internal class hw_modul_3_part_1_task_from_1_to_6
    {
        static void PrintSquare(int length, char sign)
        {
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                    Write(sign + " ");

                WriteLine();
            }
        }

        static bool IsPalindrome(int number)
        {
            int result = 0;
            int n = number;
            while (n > 0)
            {
                result = result * 10 + n % 10;
                n /= 10;
            }

            return result == number;
        }

        static int[] ArrayFilter(int[] input_massive, int[] filter)
        {
            int count = 0;

            for (int i = 0; i < input_massive.Length; i++)
            {
                for (int j = 0; j < filter.Length; j++)
                {
                    if (input_massive[i] == filter[j])
                        Array.Clear(input_massive, i, 1);
                }
            }

            foreach (int i in input_massive)
                if (i == 0)
                    count++;

            input_massive = input_massive.OrderBy(x => x == 0).ToArray();

            Array.Resize(ref input_massive, input_massive.Length - count);

            return input_massive;
        }
        static void Main()
        {
            //Задание 1
            PrintSquare(5, 'f');
            WriteLine();
            //Задание 2
            WriteLine(IsPalindrome(1221) + " " + IsPalindrome(3321));
            WriteLine();
            //Задание 3
            int[] mas = { 2, 3, 4, 6, 4, 9, 15, 543 };
            int[] ints = { 1, 2, 3, 4 };

            mas = ArrayFilter(mas, ints);

            foreach (int item in mas)
                Write(item + " ");

            WriteLine("\n");
            //Задание 4
            Website website = new();
            website.Print();
            website.Read();
            website.Print();
            //Задание 5
            Journal journal = new();
            journal.Print();
            journal.Read();
            journal.Print();
            //Задание 6
            Store store = new();
            store.Print();
            store.Read();
            store.Print();
        }
    }
    class Website
    {
        string? _site_name;
        string? _site_url;
        string? _site_description;
        string? _site_ip;

        public string? SiteName
        {
            get { return _site_name ?? "Не задано"; }
            set { _site_name = value; }
        }
        public string? SiteUrl
        {
            get { return _site_url ?? "Не задано"; }
            set { _site_url = value; }
        }
        public string? SiteDescription
        {
            get { return _site_description ?? "Не задано"; }
            set { _site_description = value; }
        }
        public string? SiteIp
        {
            get { return _site_ip ?? "Не задано"; }
            set { _site_ip = value; }
        }
        public void Read()
        {
            Write("Введите название сайта: ");
            SiteName = ReadLine();

            Write("Введите ссылку на сайт: ");
            SiteUrl = ReadLine();

            Write("Введите описание сайта: ");
            SiteDescription = ReadLine();

            Write("Введите Ip сайта: ");
            SiteIp = ReadLine();

            WriteLine();
        }
        public void Print()
        {
            WriteLine(
                "Название сайта: {0}\n" +
                "Ссылка на сайт: {1}\n" +
                "Описание сайта: {2}\n" +
                "IP сайта: {3}\n",
                SiteName, SiteUrl, SiteDescription, SiteIp);
        }
    }
    class Journal
    {
        string? _journal_name;
        int? _journal_year;
        string? _journal_description;
        string? _journal_phone;
        string? _journal_mail;

        public string? JournalName
        {
            get { return _journal_name ?? "Не задано"; }
            set { _journal_name = value; }
        }
        public int? JournalYear
        {
            get { return _journal_year ?? 0; }
            set { _journal_year = (value >= 2022 || value < 1900)
                    ? 0 : value ; }
        }
        public string? JournalDescription
        {
            get { return _journal_description ?? "Не задано"; }
            set { _journal_description = value; }
        }
        public string? JournalPhone
        {
            get { return _journal_phone ?? "Не задано"; }
            set { _journal_phone = value; }
        }
        public string? JournalMail
        {
            get { return _journal_mail ?? "Не задано"; }
            set { _journal_mail = value; }
        }

        public void Read()
        {
            Write("Введите название журнала: ");
            JournalName = ReadLine();

            Write("Введите год основания журнала: ");
            JournalYear = int.Parse(ReadLine() ?? "0");

            Write("Введите описание журнала: ");
            JournalDescription = ReadLine();

            Write("Введите телефонный номер журнала: ");
            JournalPhone = ReadLine();

            Write("Введите email журнала: ");
            JournalMail = ReadLine();

            WriteLine();
        }
        public void Print()
        {
            WriteLine(
                "Название журнала: {0}\n" +
                "Год основания журнала: {1}\n" +
                "Описание журнала: {2}\n" +
                "Телефонный номер журнала: {3}\n" +
                "Email журнала: {4}\n",
                JournalName, JournalYear, JournalDescription, JournalPhone, JournalMail);
        }
    }
    class Store
    {
        string? _store_name;
        string? _store_adress;
        string? _store_profile;
        string? _store_phone;
        string? _store_mail;

        public string? StoreName
        {
            get { return _store_name ?? "Не задано"; }
            set { _store_name = value; }
        }
        public string? StoreAdress
        {
            get { return _store_adress ?? "Не задано"; }
            set { _store_adress = value; }
        }
        public string? StoreProfile
        {
            get { return _store_profile ?? "Не задано"; }
            set { _store_profile = value; }
        }
        public string? StorePhone
        {
            get { return _store_phone ?? "Не задано"; }
            set { _store_phone = value; }
        }
        public string? StoreMail
        {
            get { return _store_mail ?? "Не задано"; }
            set { _store_mail = value; }
        }

        public void Read()
        {
            Write("Введите название магазина: ");
            StoreName = ReadLine();

            Write("Введите адрес магазина: ");
            StoreAdress = ReadLine();

            Write("Введите профиль магазина: ");
            StoreProfile = ReadLine();

            Write("Введите телефонный номер магазина: ");
            StorePhone = ReadLine();

            Write("Введите email магазина: ");
            StoreMail = ReadLine();

            WriteLine();
        }
        public void Print()
        {
            WriteLine(
                "Название магазина: {0}\n" +
                "Адрес магазина: {1}\n" +
                "Профиль магазина: {2}\n" +
                "Телефонный номер магазина: {3}\n" +
                "Email магазина: {4}\n",
                StoreName, StoreAdress, StoreProfile, StorePhone, StoreMail);
        }
    }
}