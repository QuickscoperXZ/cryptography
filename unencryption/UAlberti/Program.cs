using System;

namespace Alberti
{
    class Program
    {
        static void Main(string[] args)
        {
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            string keyAlphabet = Console.ReadLine().ToLower().Replace(" ", ""); //считываем ключ    
            string encryptedText = Console.ReadLine().ToLower().Replace(" ", ""); //считываем шифротекст

            string unencryptedText = new Func<string>(() => //расшифровываем его
            {
                string returnableValue = "";
                char bubble; //переменная для удобного хранения сдвига

                foreach (var item in encryptedText)
                {
                    returnableValue += alphabet[keyAlphabet.IndexOf(item)]; //добавляем соответствующую букву
                    bubble = keyAlphabet.Last();
                    keyAlphabet = bubble + keyAlphabet.Remove(keyAlphabet.Length - 1, 1); //поворачиваем внутреннее кольцо
                }
                return returnableValue;
            })();
            Console.WriteLine(unencryptedText); //выводим сообщение
        }
    }
}
