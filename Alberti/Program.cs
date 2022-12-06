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
                char[] returnableValue = alphabet.ToCharArray();
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
            string unencryptedText = Console.ReadLine().ToLower().Replace(" ", "");
            string encryptedText = new Func<string>(() =>
            {
                string returnableValue = "";
                char bubble;
                foreach (var item in unencryptedText)
                {
                    returnableValue += randomizedAlphabet[alphabet.IndexOf(item)];
                    bubble = randomizedAlphabet.First();
                    randomizedAlphabet = new string(randomizedAlphabet).Remove(0, 1).Append(bubble).ToArray<char>();
                }
                return returnableValue;
            })();
            Console.WriteLine(new string(encryptedText));
        }
    }
}