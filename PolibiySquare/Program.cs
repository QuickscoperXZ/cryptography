using System;
using System.Text.RegularExpressions;

namespace PolibiySquare
{
    class Program
    {
        static void Main(string[] args)
        {
            string alphabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
            int pos = 0;
            char[,] square = new char[6, 6];
            
            for (int i = 0; i < 6; i++)
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
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    Console.Write(square[i, j]);
                }
                Console.WriteLine();
            }
            string unencryptedText = Console.ReadLine().ToLower();
            unencryptedText = unencryptedText.Replace(" ", "");
            char[] encryptedText = new char[unencryptedText.Length];
            pos = 0;
            foreach (var item in unencryptedText)
            {
                for (int i = 0; i < 6; i++)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        if (square[i, j] == item)
                        {
                            try
                            {
                                if (item == 'ь' || item == 'ъ' || item == 'ы')
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
                                encryptedText[pos] = square[0, j];
                                pos++;
                            }
                        }
                    }
                }
            }
            Console.WriteLine(new string(encryptedText));
        }
    }
}