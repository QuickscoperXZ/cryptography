using System;
using System.Text.RegularExpressions;

namespace Atbash
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[] encryptedText = Console.ReadLine().ToLower().ToCharArray() ?? "sampletext".ToCharArray(); //считываем защифрованный текст
            Regex pattern = new Regex(@"[a-zA-z]"); //регулярное выражение для проверки является ли текущий символ буквой

            for (int i = 0; i <= encryptedText.Length - 1; i++)
            {
                if (pattern.Match(Convert.ToString(encryptedText[i])).Success)
                {
                    encryptedText[i] = Convert.ToChar(26 - (Convert.ToInt32(encryptedText[i]) - 96 - 1) + 96); //сдвигаем буквы
                }
            }
            Console.WriteLine(new String(encryptedText)); //выводим расшифрованное сообщение
        }
    }
} //да, это тот же самый код, в этом и суть атбаша. в алгоритме нет как такого ключа и ввиду того что алгоритм "разворачивает алфваит" развернув алфавит дважды можно получить зашифрованное сообщение
