using System;

namespace Rishele
{
    class Program
    {
        static void Main(string[] args)
        {
            string unencryptedText = Console.ReadLine().Replace(" ", "");//считываем шифруемое сообщение
            List<string> encryptedSubstringText = new List<string>(); //контейнер под разбитое сообщение
            List<List<int>> key = new List<List<int>>(); //контейнер под ключ, т. к. ключ - набор значений, в принципе можно исопльзовать и форматированную строку
            Random rand = new Random();
            int startingIndex = 0, length;

            while (startingIndex != unencryptedText.Length) //разбиваем строку
            {
                length = rand.Next(1, (unencryptedText.Length) - startingIndex);
                encryptedSubstringText.Add(new string(unencryptedText.Substring(startingIndex, length)));
                startingIndex += length;
            }            
            for (int i = 0; i < encryptedSubstringText.Count; i++) //генерируем основу под ключ - список списков с нетасованными индексами букв в шифруемом сообщении
            {
                key.Add(new Func<List<int>>(() => 
                {
                    List<int> newList = new List<int>();
                    for (int k = 0; k < encryptedSubstringText[i].Length; k++)
                    {
                        newList.Add(k);
                    }
                    return newList;
                })());
                for (int j = 0; j < encryptedSubstringText[i].Length; j++) //тасуем индексы в ключе и выставляем буквы в тасованном порядке
                {
                    char[] swap = encryptedSubstringText[i].ToCharArray();
                    int swapIndex = rand.Next(0, encryptedSubstringText[i].Length - 1);
                    char bubleChar = swap[j+swapIndex % encryptedSubstringText[i].Length-1];
                    Console.WriteLine($"{j}|{swapIndex}|{key[i].Count}|{encryptedSubstringText[i]}");
                    int bubleInt = key[i][j + swapIndex];

                    swap[j + swapIndex] = swap[j];
                    swap[j] = bubleChar;

                    key[i][j + swapIndex] = key[i][j];
                    key[i][j] = bubleInt;

                    encryptedSubstringText[i] = new string(swap);
                }
            }
            Console.WriteLine("================================");
            foreach (var item in encryptedSubstringText)
            {
                Console.Write($"{item} ");
            }
            foreach (var item in key)
            {
                Console.Write("(");
                foreach (var value in item)
                {
                    Console.Write($"{value}, ");
                }
                Console.Write(")");
            }

        }
    }
}
