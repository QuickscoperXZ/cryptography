using System;

namespace Alberti
{
    class Program
    {
        static void Main(string[] args)
        {
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            char[] randomizedAlphabet = new Func<char[]>(() =>
            {
                char[] returnableValue = alphabet.ToCharArray(); //тасуем алфавит алгоритмом Фишера - Йедса
                int n = alphabet.Length;
                Random rndm = new Random();
                while (n > 1)
                {
                    n--;
                    int k = rndm.Next(n + 1);
                    char value = returnableValue[k];
                    returnableValue[k] = returnableValue[n];
                    returnableValue[n] = value;
                }
                return returnableValue;
            })();
            string unencryptedText = Console.ReadLine().ToLower().Replace(" ", ""); //считываем шифруемое сообщение
            string encryptedText = new Func<string>(() =>
            {
                string returnableValue = "";
                char bubble; //переменная для удобства переноса первой буквы в конец строки
                foreach (var item in unencryptedText)
                {
                    returnableValue += randomizedAlphabet[alphabet.IndexOf(item)]; //шифруем букву нижним диском
                    bubble = randomizedAlphabet.First(); //запоминаем
                    randomizedAlphabet = new string(randomizedAlphabet).Remove(0, 1).Append(bubble).ToArray<char>(); //поворачиваем диск
                }
                return returnableValue;
            })();
            Console.WriteLine(new string(encryptedText));
        }
    }
}
