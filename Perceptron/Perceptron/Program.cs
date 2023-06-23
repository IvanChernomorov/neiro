using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perceptron
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Perceptron perceptron = new Perceptron(3, 10, 0.1, 1000);

            double[][] trainData = new double[][]
            {
            new double[] { -1, -1, -1},
            new double[] { -1, -1, 1 },
            new double[] { -1, 1, -1 },
            new double[] { -1, 1, 1 },
            new double[] { 1, -1, -1 },
            new double[] { 1, -1, 1 },
            new double[] { 1, 1, -1 },
            new double[] { 1, 1, 1 }
            };

            double[] targets = new[] { -1.0, 1.0, -1.0, 1.0, -1.0, 1.0, -1.0, 1.0 };

            perceptron.Train(trainData, targets);

            for(int i = 0; i < trainData.GetLength(0); i++)
            {
                double result = perceptron.Predict(trainData[i])[0];
                Console.WriteLine($"Выходное значение НС: {result} => {targets[i]}");
            }

            //Console.WriteLine($"Оптимальные веса: {perceptron.W1[0, 0]}, {perceptron.W1[0, 1]}, {perceptron.W1[0, 2]}; {perceptron.W1[1, 0]}, {perceptron.W1[1, 1]}, {perceptron.W1[1, 2]}; {perceptron.W2[0]}, {perceptron.W2[1]}");
            Console.ReadKey();
        }
    }
}
