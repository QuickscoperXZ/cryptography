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
            string encryptedText = Console.ReadLine().ToLower().Replace(" ", "");
            Vector<double> encryptedVector = Vector<double>.Build.Dense(new Func<double[]>(() =>
            {
                double[] returnableValue = new double[encryptedText.Length];
                for (int i = 0; i < encryptedText.Length; i++)
                {
                    returnableValue[i] = Convert.ToDouble(alphabet.IndexOf(encryptedText[i]));
                }
                return returnableValue;
            })());
            Matrix<double> key = new Func<Matrix<double>>(() =>
            {
                Matrix<double> returnableMatrix = Matrix<double>.Build.Dense(encryptedText.Length, encryptedText.Length);
                for (int i = 0; i < encryptedText.Length; i++)
                {
                    for (int j = 0; j < encryptedText.Length; j++)
                    {
                        returnableMatrix[i, j] = Convert.ToInt32(Console.ReadLine());
                    }
                }
                return returnableMatrix.Inverse();
            })();
            Vector<double> unencryptedVector = Vector<double>.Build.DenseOfArray((key * encryptedVector.ToColumnMatrix()).ToColumnArrays()[0]);
            for (int i = 0; i < encryptedVector.Count; i++)
            {
                encryptedVector[i] %= 26;
            }
            string unencryptedText = new Func<string>(() =>
            {
                char[] returnableValue = new char[encryptedVector.Count];
                for (int i = 0; i < returnableValue.Length; i++)
                {
                    returnableValue[i] = Convert.ToChar(Convert.ToInt32(encryptedVector[i]) + 97);
                }
                return new string(returnableValue);
            })();
            Console.WriteLine(encryptedText);
        }
    }
}
