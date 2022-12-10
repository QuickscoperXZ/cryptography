using System;

namespace Vishener
{
    class Program
    {
        static void Main(string[] args)
        {
            string alphabet = "abcdefghijklmnopqrstuvwxyz";

            List<string> VishenerSquare = new List<string>(); //создаём контейнер под таблицу
            VishenerSquare.Add(alphabet); //добавляем в неё алфавит

            for (int i = 1; i < 25; i++) //строим таблицу со всеми сдвигами
            {
                VishenerSquare.Add(new Func<string>(() =>
                {
                    string subSequence = alphabet.Substring(0, i+1);
                    string returnableValue = alphabet.Remove(0, i + 1);
                    returnableValue += subSequence;
                    return returnableValue;
                })());
            }

            string unencryptedText = Console.ReadLine().Replace(" ", "").ToLower(); //считываем шифруемое сообщение
            string key = new Func<string>(() => //считываем ключ и дополняем его до длинны сообщения
            {
                string returnableValue = Console.ReadLine().Replace(" ", "").ToLower();
                if (returnableValue.Length != unencryptedText.Length)
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
            char[] encryptedText = new char[unencryptedText.Length]; //шифруем сообщение путём вычисления кординат зашифрованной буквы в таблице

            for (int i = 0; i < unencryptedText.Length; i++)
            {
                int charIndexer = Convert.ToInt32(unencryptedText[i])-97;
                int keyIndexer = Convert.ToInt32(key[i])-97;

                encryptedText[i] = VishenerSquare[keyIndexer][charIndexer];
            }
            Console.WriteLine(new String(encryptedText));
        }
    }
}
