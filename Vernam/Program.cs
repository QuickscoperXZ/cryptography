using System;
using System.Text;

namespace Vernam
{
    class Program
    {
        static void Main()
        {
            string unencryptedText = Console.ReadLine().ToLower().Replace(" ", "");
            char[] key = new Func<char[]>(() =>
            {
                string returnableValue = Console.ReadLine().Replace(" ", "").ToLower();
                if (returnableValue.Length != unencryptedText.Length)
                {
                    while (returnableValue.Length < unencryptedText.Length)
                    {
                        returnableValue += returnableValue.Substring(0, returnableValue.Length);
                    }
                    returnableValue = returnableValue.Remove((returnableValue.Length - (returnableValue.Length - unencryptedText.Length)));
                    return returnableValue.ToCharArray();
                }
                else
                {
                    return returnableValue.ToCharArray();
                }
            })();

            string encryptedText = new Func<string>(() =>
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < unencryptedText.Length; i++)
                {
                    sb.Append(Convert.ToChar(unencryptedText[i] ^ key[i]));
                }
                return sb.ToString();
            })();

            Console.WriteLine(encryptedText); //вывоит ASCII символы
            foreach (var item in encryptedText) //Выводит соответствующие коды
            {
                Console.WriteLine(Convert.ToInt32(item));
            }

            //List<int> unencryptedTextValues = new Func<List<int>>(() =>
            //{
            //    List<int> returnableValue = new List<int>();
            //    foreach (var item in unencryptedText)
            //    {
            //        returnableValue.Add(Convert.ToInt32(item));
            //    }
            //    return returnableValue;
            //})();
            //List<int> keyValues = new Func<List<int>>(() =>
            //{
            //    List<int> returnableValue = new List<int>();
            //    foreach (var item in unencryptedText)
            //    {
            //        returnableValue.Add(Convert.ToInt32(item));
            //    }
            //    return returnableValue;
            //})();

            //string encryptedText = new Func<string>(() =>
            //{
            //    List<char> returnableValue = new List<char>();
            //    for (int i = 0; i < unencryptedTextValues.Count; i++)
            //    {
            //        Console.Write($"{Convert.ToChar(unencryptedTextValues[i] ^ keyValues[i])}|");
            //        returnableValue.Add(Convert.ToChar(unencryptedTextValues[i]^keyValues[i]));
            //    }
            //    return new string(returnableValue.ToArray());
            //})();
            //List<int> encryptedTextValues = new Func<List<int>>(() =>
            //{
            //    List<int> returnableValue = new List<int>();
            //    for (int i = 0; i < unencryptedTextValues.Count; i++)
            //    {
            //        Console.Write($"{unencryptedTextValues[i] ^ keyValues[i]}|");
            //        returnableValue.Add(unencryptedTextValues[i] ^ keyValues[i]);
            //    }
            //    return returnableValue;
            //})();

            //Console.WriteLine(encryptedText);
            //foreach (var item in encryptedTextValues)
            //{
            //    Console.Write($"{item}|");
            //}
        }
    }
}