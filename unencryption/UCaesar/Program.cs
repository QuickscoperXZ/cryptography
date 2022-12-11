using System;
using System.Text.RegularExpressions;

namespace Atabsh_Caesar
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] encryptedText = Console.ReadLine().ToCharArray() ?? throw new Exception("Неверная строка"); //Незашифрованный текст
            int key = Convert.ToInt32(Console.ReadLine()) % 26;

            Regex pattern = new Regex(@"[a-zA-z]"); //Регулярное выражение для проверки соответствия

            for (int i = 0;i<encryptedText.Count();i++)
            {
                if (pattern.Match(Convert.ToString(encryptedText[i])).Success) //Проверяем совпадает ли число с нашим выражением
                {
                    if (Convert.ToChar(Convert.ToInt32(encryptedText[i]) - key) < 97) 
                        encryptedText[i] = Convert.ToChar(Convert.ToInt32(encryptedText[i]) + (122 -  key)); //Если совпало то меняем текущий символ на предыдущий, если уходим за пределы алфавита в ASCII то считаем от конца алфваита
                    else
                        encryptedText[i] = Convert.ToChar(Convert.ToInt32(encryptedText[i]) + key);
                }
            }

            Console.WriteLine(new String(encryptedText)); //Выводим полученную строку
            
        }
    }
}
