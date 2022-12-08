using System;
using System.Text.RegularExpressions;

namespace Gronsfeld
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex pattern = new Regex("[a-zA-Z]");
            string alphabet = "abcdefghijklmnopqrstuvwxyz";

            List<string> GronsfeldTable = new List<string>();
            GronsfeldTable.Add(alphabet);

            for (int i = 1; i < 10; i++)
            {
                GronsfeldTable.Add(new Func<string>(() =>
                {
                    string subSequence = alphabet.Substring(0, i);
                    string returnableValue = alphabet.Remove(0, i);
                    returnableValue += subSequence;
                    return returnableValue;
                })());
            }

            string encryptedText = Console.ReadLine().Replace(" ", "").ToLower();
            string key = new Func<string>(() =>
            {
                string returnableValue = Console.ReadLine().Replace(" ", "").ToLower();
                if (pattern.IsMatch(returnableValue))
                {
                    throw new FormatException();
                }
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

            char[] unencryptedText = new char[encryptedText.Length];

            for (int i = 0; i < unencryptedText.Length; i++)
            {
                int charIndexer = Convert.ToInt32(unencryptedText[i]) - 97;
                int keyIndexer = Int32.Parse(Convert.ToString(key[i]));

                unencryptedText[i] = GronsfeldTable[0][GronsfeldTable[keyIndexer].IndexOf(encryptedText[i])];
            }
            Console.WriteLine(new String(encryptedText));
        }
    }
}