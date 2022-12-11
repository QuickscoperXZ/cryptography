using System;

namespace Vishener
{
    class Program
    {
        static void Main(string[] args)
        {
            string alphabet = "abcdefghijklmnopqrstuvwxyz";

            List<string> VishenerSquare = new List<string>(); //создаём контейнер под таблицу и записываем туда алфавит
            VishenerSquare.Add(alphabet);

            for (int i = 1; i < 25; i++) //заполняем таблицу
            {
                VishenerSquare.Add(new Func<string>(() =>
                {
                    string subSequence = alphabet.Substring(0, i + 1);
                    string returnableValue = alphabet.Remove(0, i + 1);
                    returnableValue += subSequence;
                    return returnableValue;
                })());
            }

            string encryptedText = Console.ReadLine().Replace(" ", "").ToLower(); //считываем зашифрованное сообщение
            string key = new Func<string>(() => //считываем ключ и дополняем его до длины шифротекста
            {
                string returnableValue = Console.ReadLine().Replace(" ", "").ToLower();
                if (returnableValue.Length != encryptedText.Length)
                {
                    while (returnableValue.Length < encryptedText.Length)
                    {
                        returnableValue += returnableValue.Substring(0, returnableValue.Length);
                        Console.WriteLine(returnableValue);
                    }
                    returnableValue = returnableValue.Remove((returnableValue.Length - (returnableValue.Length - encryptedText.Length)));
                    return returnableValue;
                }
                else
                {
                    return returnableValue;
                }
            })();

            string unencryptedText = new Func<string>(() => //расшифровываем сообщения путём определения индекса зашифрованной буквы и взятия соответсвующей индексу буквы из алфавита
            {
                char[] returnableValue = new char[encryptedText.Length];
                for (int i = 0; i < returnableValue.Length; i++)
                {
                    returnableValue[i] = VishenerSquare[0][VishenerSquare[Convert.ToInt32(key[i] - 97)].IndexOf(encryptedText[i])];
                }
                return new string(returnableValue);
            })();
            Console.WriteLine(unencryptedText);
        }
    }
}
