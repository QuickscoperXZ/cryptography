using System;
using System.Text.RegularExpressions;

namespace Atbash
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[] unencryptedText = Console.ReadLine().ToLower().ToCharArray() ?? "sampletext".ToCharArray(); //считываем исходный текст и задаём значение по умолчанию
            Regex pattern = new Regex(@"[a-zA-z]");//регулярное выражения для проверки является ли текущий символ буквой.\
            
            for (int i = 0; i<=unencryptedText.Length-1;i++)
            {
                if (pattern.Match(Convert.ToString(unencryptedText[i])).Success) 
                {
                    unencryptedText[i] = Convert.ToChar(26 - (Convert.ToInt32(unencryptedText[i]) - 96 - 1)+96); //если текущий символ - буква, то переводим символ в его представление в ASCII
                }                                                                                                //и вычитаем 97 чтобы получить его порядковый номер, после чего вычитаем его из мощности 
            }                                                                                                    //алфавита и снова прибавляем 96 чтобы получить этот символ в ASCII           
            Console.WriteLine(new String(unencryptedText));
        }
    }
}
