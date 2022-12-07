using System;
using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra;

namespace Hill
{
    class Program
    {
        static void Main(string[] args)
        {
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            string unencryptedText = Console.ReadLine().ToLower().Replace(" ", "");
            Vector<double> unencryptedVector = Vector<double>.Build.Dense(new Func<double[]>(() => 
            {
                double[] returnableValue = new double[unencryptedText.Length];
                for (int i = 0; i < unencryptedText.Length; i++)
                {
                    returnableValue[i] = Convert.ToDouble(alphabet.IndexOf(unencryptedText[i]));
                }
                return returnableValue;
            })());
            Matrix<double> key = new Func<Matrix<double>>(() =>
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
            Vector<double> encryptedVector = Vector<double>.Build.DenseOfArray((key * unencryptedVector.ToColumnMatrix()).ToColumnArrays()[0]);
            for (int i = 0; i < encryptedVector.Count; i++)
            {
                encryptedVector[i] %= 26;
            }
            string encryptedText = new Func<string>(() =>
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


