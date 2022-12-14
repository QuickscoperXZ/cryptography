using System;
using System.Text;

namespace Vernam
{
    class Program
    {
        static void Main()
        {
            string encryptedText = Console.ReadLine().ToLower().Replace(" ", ""); //считываем зашифрованное сообщение
            char[] key = new Func<char[]>(() => //считываем ключ и дописываем его до длинны сообщения
            {
                string returnableValue = Console.ReadLine().Replace(" ", "").ToLower();
                if (returnableValue.Length != encryptedText.Length)
                {
                    while (returnableValue.Length < encryptedText.Length)
                    {
                        returnableValue += returnableValue.Substring(0, returnableValue.Length);
                    }
                    returnableValue = returnableValue.Remove((returnableValue.Length - (returnableValue.Length - encryptedText.Length)));
                    return returnableValue.ToCharArray();
                }
                else
                {
                    return returnableValue.ToCharArray();
                }
            })();

            string unencryptedText = new Func<string>(() => //расшивроывываем путём поразрядного исключаещего или ключа и шифротекста
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < encryptedText.Length; i++)
                {
                    sb.Append(Convert.ToChar(encryptedText[i] ^ key[i]));
                }
                return sb.ToString();
            })();

            Console.WriteLine(encryptedText); //вывоит ASCII символы
        }
    }
}
