using System;
using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra; //импортируем библиотеки для работы с матрицами

namespace Hill
{
    class Program
    {
        static void Main(string[] args)
        {
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            string unencryptedText = Console.ReadLine().ToLower().Replace(" ", ""); //считываем шифруемое сообщение
            Vector<double> unencryptedVector = Vector<double>.Build.Dense(new Func<double[]>(() => //создаём и заполняем вектор порядковыми в алфавите букв сообщения
            {
                double[] returnableValue = new double[unencryptedText.Length];
                for (int i = 0; i < unencryptedText.Length; i++)
                {
                    returnableValue[i] = Convert.ToDouble(alphabet.IndexOf(unencryptedText[i]));
                }
                return returnableValue;
            })());
            Matrix<double> key = new Func<Matrix<double>>(() => //генерируем ключ ввиде квадратной матрицы порядка равного длинне сообщения
            {
                Matrix<double> returnableMatrix = Matrix<double>.Build.Dense(unencryptedText.Length,unencryptedText.Length);
                for (int i = 0; i < unencryptedText.Length; i++)
                {
                    for (int j = 0; j < unencryptedText.Length; j++)                                   
                    {
                        returnableMatrix[i, j] = Convert.ToDouble(new Random().Next(0,25));
                    }
                }
                return returnableMatrix;
            })();            
            Vector<double> encryptedVector = Vector<double>.Build.DenseOfArray((key * unencryptedVector.ToColumnMatrix()).ToColumnArrays()[0]); //считаем произведение матрицы и вектора
            for (int i = 0; i < encryptedVector.Count; i++)
            {
                encryptedVector[i] %= 26; // вычисляем полученое значение по модулю 26
            }
           string encryptedText = new Func<string>(() => //конвертируем полученый вектор состоящий из порядковых номеров символов в строку и выводи её
            {
                char[] returnableValue = new char[encryptedVector.Count];
                for (int i = 0; i < returnableValue.Length; i++)
                {
                    returnableValue[i] = Convert.ToChar(Convert.ToInt32(encryptedVector[i])+97);
                }
                return new string(returnableValue);
            })();
            Console.WriteLine(encryptedText);
        }
    }
}


