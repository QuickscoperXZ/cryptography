using System;
using System.Text.RegularExpressions;

namespace Atabsh_Caesar
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] unencryptedText = Console.ReadLine().ToCharArray() ?? throw new Exception("Неверная строка"); //Незашифрованный текст
            int mv = Convert.ToInt32(Console.ReadLine()) % 26;

            Regex pattern = new Regex(@"[a-zA-z]"); //Регулярное выражение для проверки соответствия

            for (int i = 0;i<unencryptedText.Count();i++) //В цикле проверяем совпадает ли число с нашим выражением
            {
                if (pattern.Match(Convert.ToString(unencryptedText[i])).Success) 
                {
                    unencryptedText[i] = Convert.ToChar(Convert.ToInt32(unencryptedText[i]) + mv); //Если совпало то меняем текущий символ на следующий
                }
            }

            Console.WriteLine(new String(unencryptedText)); //Выводим полученную строку
            
        }
    }
}