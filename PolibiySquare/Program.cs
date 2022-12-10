using System;
using System.Text.RegularExpressions;

namespace PolibiySquare
{
    class Program
    {
        static void Main(string[] args)
        {
            string alphabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
            int pos = 0; //вводим дополнительый итератор
            char[,] square = new char[6, 6]; //создаём таблицу - квадрат
            
            for (int i = 0; i < 6; i++) //заполняем таблицу
            {
                for (int j = 0; j < 6; j++)
                {
                    try
                    {
                        square[i, j] = alphabet[pos];
                    }
                    catch(IndexOutOfRangeException e)
                    {
                        square[i, j] = ' ';
                    }
                    pos++;
                }
            }
            for (int i = 0; i < 6; i++) //выводим таблицу(сугубо для проверки)
            {
                for (int j = 0; j < 6; j++)
                {
                    Console.Write(square[i, j]);
                }
                Console.WriteLine();
            }
            string unencryptedText = Console.ReadLine().ToLower().Replace(" ", ""); //считываем шифруемый текст
            char[] encryptedText = new char[unencryptedText.Length]; //создаём контейнер для зашифрованного сообщения
            pos = 0; //обнуляем итератор
            foreach (var item in unencryptedText) //шифруем в соответствии с правилами
            {
                for (int i = 0; i < 6; i++)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        if (square[i, j] == item)
                        {
                            try
                            {
                                if (item == 'ь' || item == 'ъ' || item == 'ы') //переносим значение в первую строку если под буквой в таблице ничего нет, таких символа только три
                                {
                                    encryptedText[pos] = square[0, j];
                                }
                                else
                                {
                                    encryptedText[pos] = square[i + 1, j];
                                }
                                pos++;
                            }
                            catch
                            {
                                encryptedText[pos] = square[0, j]; //это тут избыточно
                                pos++;
                            }
                        }
                    }
                }
            }
            Console.WriteLine(new string(encryptedText)); //выводим зашифрованное сообщение
        }
    }
}
