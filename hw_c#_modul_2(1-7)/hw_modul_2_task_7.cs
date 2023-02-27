/* Создайте приложение, проверяющее текст на недопустимые слова.
 * Если недопустимое слово найдено, оно должно быть заменено
 * на набор символов *. По итогам работы приложения необходимо
 * показать статистику действий. */

using static System.Console;

namespace charp
{
    internal class hw_modul_2_task_7
    {
        static void Main()
        {
            int count = 0;
            const string word = "die";

            string text = "To be, or not to be, that is the question," +
                "\r\nWhether 'tis nobler in the mind to suffer\r\n" +
                "The slings and arrows of outrageous fortune,\r\n" +
                "Or to take arms against a sea of troubles,\r\n" +
                "And by opposing end them? To die: to sleep;\r\n" +
                "No more; and by a sleep to say we end\r\n" +
                "The heart-ache and the thousand natural shocks\r\n" +
                "That flesh is heir to, 'tis a consummation\r\n" +
                "Devoutly to be wish'd. To die, to sleep";

            WriteLine(text + "\n");

            foreach(string s in text.Split(' '))
                if(s.Contains(word))
                    count++;

            if (text.Contains(word))
                text = text.Replace(word, "***");

            WriteLine(text + "\nСтатистика: " + count + " замены слова " + word);
        }
    }
}