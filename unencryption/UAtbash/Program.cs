using System;
using System.Text.RegularExpressions;

namespace Atbash
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[] encryptedText = Console.ReadLine().ToLower().ToCharArray() ?? "sampletext".ToCharArray();
            Regex pattern = new Regex(@"[a-zA-z]");

            for (int i = 0; i <= encryptedText.Length - 1; i++)
            {
                if (pattern.Match(Convert.ToString(encryptedText[i])).Success)
                {
                    encryptedText[i] = Convert.ToChar(26 - (Convert.ToInt32(encryptedText[i]) - 96 - 1) + 96);
                }
            }
            Console.WriteLine(new String(encryptedText));
        }
    }
}