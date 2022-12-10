using System;
using System.Text;

namespace Vernam
{
    class Program
    {
        static void Main()
        {
            string unencryptedText = Console.ReadLine().ToLower().Replace(" ", ""); //считываем шифруемое сообщение
            char[] key = new Func<char[]>(() => //считываем ключ и дописываем его до длинны шифруемого сообщения
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

            string encryptedText = new Func<string>(() => // шифруем путём поразрядного исключаещего или
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
        }
    }
}
