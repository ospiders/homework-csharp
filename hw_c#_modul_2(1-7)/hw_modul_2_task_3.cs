/* Пользователь вводит строку с клавиатуры. Необходимо зашифровать
 * данную строку используя шифр Цезаря. Из Википедии: Шифр Цезаря — это
 * вид шифра подстановки, в котором каждый символ в открытом тексте
 * заменяется символом, находящимся на некотором постоянном числе позиций
 * левее или правее него в алфавите. Например, в шифре со сдвигом вправо
 * на 3, A была бы заменена на D, B станет E, и так далее.
Подробнее тут: https://en.wikipedia.org/wiki/Caesar_cipher.
Кроме механизма шифровки, реализуйте механизм расшифрования.*/
using System.Text;
using static System.Console;

namespace charp
{
    class hw_modul_2_task_3
    {
        public static StringBuilder CaesarCipher(string text, int s)
        {
            StringBuilder result = new();

            for (int i = 0; i < text.Length; i++)
            {
                if (char.IsUpper(text[i]))
                {
                    char ch = (char)(((int)text[i] + s - 65) % 26 + 65);
                    result.Append(ch);
                }

                else if (text[i] == ' ')
                    result.Append(' ');

                else
                {
                    char ch = (char)(((int)text[i] + s - 97) % 26 + 97);
                    result.Append(ch);
                }
            }
            return result;
        }

        static void Main()
        {
            const int shift = 3;
            int encrypt_shift = 29 - shift;
            string secret_message = "Cesar secret message xez";

            WriteLine("Текст: {0}", secret_message);
            WriteLine("Зашифрованный текст: {0}", CaesarCipher(secret_message, shift));
            WriteLine("Расшифрованный текст: {0}", CaesarCipher(secret_message, encrypt_shift));
        }
    }
}