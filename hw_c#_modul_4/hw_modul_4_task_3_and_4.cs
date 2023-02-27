/*Задание 3
Создайте приложение для перевода обычного текста в азбуку Морзе.
Пользователь вводит текст. Приложение отображает введенный текст азбукой Морзе.
Используйте механизмы пространств имён.

Задание 4
Добавьте к предыдущему заданию механизм перевода текста из азбуки Морзе в обычный текст*/
using System.Text;
using static System.Console;

namespace charp
{
    internal class hw_modul_4_task_3_and_4
    {
        static void Main()
        {
            MorseIncrypt.Morse morse = new();

            string s = "Съешь же еще этих французских булочек да выпей чаю.";
            StringBuilder d = morse.MorseCodeIncrypt(s);
            WriteLine(d);

            MorseDecrypt.Morse morse1 = new();
            d = morse1.MorseCodeDecrypt(d.ToString());
            WriteLine(d);
        }
    }
}


namespace MorseIncrypt
{
    class Morse
    {
        string MorseEncode(char x)
        {
            x = char.ToLower(x);
            switch (x)
            {
                case 'а':
                    return ".-";
                case 'б':
                    return "-...";
                case 'в':
                    return ".--";
                case 'г':
                    return "--.";
                case 'д':
                    return "-..";
                case 'е':
                    return ".";
                case 'ж':
                    return "...-";
                case 'з':
                    return "--..";
                case 'и':
                    return "..";
                case 'й':
                    return ".---";
                case 'к':
                    return "-.-";
                case 'л':
                    return ".-..";
                case 'м':
                    return "--";
                case 'н':
                    return "-.";
                case 'о':
                    return "---";
                case 'п':
                    return ".--.";
                case 'р':
                    return ".-.";
                case 'с':
                    return "...";
                case 'т':
                    return "-";
                case 'у':
                    return "..-";
                case 'ф':
                    return "..-.";
                case 'х':
                    return "....";
                case 'ц':
                    return "-.-.";
                case 'ч':
                    return "---.";
                case 'ш':
                    return "----";
                case 'щ':
                    return "--.-";
                case 'ь':
                    return "-..-";
                case 'ъ':
                    return "-..-";
                case 'ы':
                    return "-.--";
                case 'э':
                    return "..-..";
                case 'ю':
                    return "..--";
                case 'я':
                    return ".-.-";


                case '1':
                    return ".----";
                case '2':
                    return "..---";
                case '3':
                    return "...--";
                case '4':
                    return "....-";
                case '5':
                    return ".....";
                case '6':
                    return "-....";
                case '7':
                    return "--...";
                case '8':
                    return "---..";
                case '9':
                    return "----.";
                case '0':
                    return "-----";


                case '.':
                    return "......";
                case ',':
                    return ".-.-.-";
                case ':':
                    return "-.-.-.";
                case ';':
                    return "---...";
                case '?':
                    return "..--..";
                case '!':
                    return "--..--";
                case '-':
                    return "-....-";
                case '"':
                    return ".-..-.";
                case '(':
                    return "-.--.-";
                case ')':
                    return "-.--.-";
                case '/':
                    return "-..-.";

                default:
                    return "";
            }
        }
        public StringBuilder MorseCodeIncrypt(string s)
        {
            StringBuilder result = new();

            for (int i = 0; i < s.Length; i++)
                result.Append(MorseEncode(s[i]) + " ");

            return result;
        }
    }
}

namespace MorseDecrypt
{
    class Morse
    {
        char MorseEncode(string code)
        {
            switch (code)
            {
                case ".-":
                    return 'а';
                case "-...":
                    return 'б';
                case ".--":
                    return 'в';
                case "--.":
                    return 'г';
                case "-..":
                    return 'д';
                case ".":
                    return 'е';
                case "...-":
                    return 'ж';
                case "--..":
                    return 'з';
                case "..":
                    return 'и';
                case ".---":
                    return 'й';
                case "-.-":
                    return 'к';
                case ".-..":
                    return 'л';
                case "--":
                    return 'м';
                case "-.":
                    return 'н';
                case "---":
                    return 'о';
                case ".--.":
                    return 'п';
                case ".-.":
                    return 'р';
                case "...":
                    return 'с';
                case "-":
                    return 'т';
                case "..-":
                    return 'у';
                case "..-.":
                    return 'ф';
                case "....":
                    return 'х';
                case "-.-.":
                    return 'ц';
                case "---.":
                    return 'ч';
                case "----":
                    return 'ш';
                case "--.-":
                    return 'щ';
                case "-..-":
                    return 'ь';
                case "-.--":
                    return 'ы';
                case "..-..":
                    return 'э';
                case "..--":
                    return 'ю';
                case ".-.-":
                    return 'я';


                case ".----":
                    return '1';
                case "..---":
                    return '2';
                case "...--":
                    return '3';
                case "....-":
                    return '4';
                case ".....":
                    return '5';
                case "-....":
                    return '6';
                case "--...":
                    return '7';
                case "---..":
                    return '8';
                case "----.":
                    return '9';
                case "-----":
                    return '0';


                case "......":
                    return '.';
                case ".-.-.-":
                    return ',';
                case "-.-.-.":
                    return ':';
                case "---...":
                    return ':';
                case "..--..":
                    return '?';
                case "--..--":
                    return '!';
                case "-....-":
                    return '-';
                case ".-..-.":
                    return '"';
                case "-.--.-":
                    return '(';
                case "-..-.":
                    return '/';
            }
            return ' ';
        }
        public StringBuilder MorseCodeDecrypt(string s)
        {
            StringBuilder result = new();
            string[] arr_str = s.Split(' ');
           
            foreach (string str in arr_str)
                result.Append(MorseEncode(str));

            return result;        
        }
    }
}
