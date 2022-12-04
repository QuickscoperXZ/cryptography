using System;
using System.Text.RegularExpressions;

namespace Atbash
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[] unencryptedText = Console.ReadLine().ToLower().ToCharArray() ?? "sampletext".ToCharArray();
            Regex pattern = new Regex(@"[a-zA-z]");
            
            for (int i = 0; i<=unencryptedText.Length-1;i++)
            {
                if (pattern.Match(Convert.ToString(unencryptedText[i])).Success)
                {
                    unencryptedText[i] = Convert.ToChar(26 - (Convert.ToInt32(unencryptedText[i]) - 96 - 1)+96);
                }
            }
            Console.WriteLine(new String(unencryptedText));
        }
    }
}