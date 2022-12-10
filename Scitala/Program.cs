using System;
using System.Text.RegularExpressions;

namespace System
{
    class Program
    {
        static void Main(string[] args)
        {
            string unencryptedText = Console.ReadLine(); //считываем шифруемое сообщение и диаметр
            int dia = Convert.ToInt32(Console.ReadLine()); 
            int len;
            if (dia < 2)
            {
                Console.WriteLine("Неверный диаметр");
            }
            else
            {
                string Source = unencryptedText;
                char[] Code = Source.ToCharArray();

                //Вычисление длины Скиталы по диаметру и длине исходного текста
                if (unencryptedText.Length % dia == 0)
                    len = unencryptedText.Length / dia;
                else
                    len = unencryptedText.Length / dia + 1;

                if (len < 2)
                {
                    Console.WriteLine("Слишком короткий исходный текст!", "Ошибка");
                }
                else
                {
                    //Создаем Скиталу требуемого размера
                    char[][] mas = new char[dia][];
                    for (int m = 0; m < dia; m++)
                        mas[m] = new char[len];

                    //Заполняем всю Скиталу мусорным символом
                    for (int m = 0; m < dia; m++)
                        for (int n = 0; n < len; n++)
                            mas[m][n] = '⁣';

                    //Заполняем Скиталу символами исходного текста
                    int i = 0, j = 0;
                    for (int m = 0; m < Code.Length; m++)
                    {
                        mas[i][j] = Code[m];
                        j++;
                        if (j == len)
                        {
                            i++;
                            j = 0;
                        }
                    }

                    //Считываем шифртекст со Скиталы
                    char[] result = new char[len * dia];
                    int cur = 0;
                    for (int m = 0; m < len; m++)
                        for (int n = 0; n < dia; n++)
                        {
                            result[cur] = mas[n][m];
                            cur++;
                        }
                    Console.WriteLine(new string(result));
                }
            }
        }
    }
    }
