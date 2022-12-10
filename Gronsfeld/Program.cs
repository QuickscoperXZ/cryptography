using System;
using System.Text.RegularExpressions;

namespace Gronsfeld
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex pattern = new Regex("[a-zA-Z]"); //регулярное выражение для проверки есть ли буква в ключе.
            string alphabet = "abcdefghijklmnopqrstuvwxyz";

            List<string> GronsfeldTable = new List<string>(); //создаём таблицу и добавляем в неё алфавит под соответствующим индексом
            GronsfeldTable.Add(alphabet);

            for (int i = 1; i < 10; i++) //заполняем таблицу
            {
                GronsfeldTable.Add(new Func<string>(() =>
                {
                    string subSequence = alphabet.Substring(0, i);
                    string returnableValue = alphabet.Remove(0, i);
                    returnableValue += subSequence;
                    return returnableValue;
                })());
            }

            string unencryptedText = Console.ReadLine().Replace(" ", "").ToLower(); //считываем шифруемое сообщение
            string key = new Func<string>(() =>
            {
                string returnableValue = Console.ReadLine().Replace(" ", "").ToLower();
                if (pattern.IsMatch(returnableValue)) 
                {
                    throw new FormatException();
                }
                if (returnableValue.Length != unencryptedText.Length) //считываем ключ, затем убеждаемся что в нем нет букв и затем дописываем его до длинны сообщения
                {
                    while (returnableValue.Length < unencryptedText.Length)
                    {
                        returnableValue += returnableValue.Substring(0, returnableValue.Length);
                        Console.WriteLine(returnableValue);
                    }
                    returnableValue = returnableValue.Remove((returnableValue.Length - (returnableValue.Length - unencryptedText.Length)));
                    return returnableValue;
                }
                else
                {
                    return returnableValue;
                }
            })();

            char[] encryptedText = new char[unencryptedText.Length];

            for (int i = 0; i < unencryptedText.Length; i++)
            {
                int charIndexer = Convert.ToInt32(unencryptedText[i]) - 97; //шифруем сообщения путём преобразования буквы и ключа в кординаты зашифрованной буквы
                int keyIndexer = Int32.Parse(Convert.ToString(key[i]));

                encryptedText[i] = GronsfeldTable[keyIndexer][charIndexer];
            }
            Console.WriteLine(new String(encryptedText));
        }
    }
}
