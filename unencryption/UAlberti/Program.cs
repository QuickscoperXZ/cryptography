using System;

namespace Alberti
{
    class Program
    {
        static void Main(string[] args)
        {
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            string keyAlphabet = Console.ReadLine().ToLower().Replace(" ", "");
            string encryptedText = Console.ReadLine().ToLower().Replace(" ", "");

            string unencryptedText = new Func<string>(() =>
            {
                string returnableValue = "";
                char bubble;

                foreach (var item in encryptedText)
                {
                    returnableValue += alphabet[keyAlphabet.IndexOf(item)];
                    bubble = keyAlphabet.Last();
                    keyAlphabet = bubble + keyAlphabet.Remove(keyAlphabet.Length - 1, 1);
                }
                return returnableValue;
            })();
            Console.WriteLine(unencryptedText);
        }
    }
}