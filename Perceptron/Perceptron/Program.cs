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
            double[][] trainingData = new double[4][];
            trainingData[0] = new[] { 0.0, 0.0 };
            trainingData[1] = new[] { 0.0, 1.0 };
            trainingData[2] = new[] { 1.0, 0.0 };
            trainingData[3] = new[] { 1.0, 1.0 };

            double[] labels = new[] { 0.0, 0.0, 0.0, 1.0 };

            Perceptron p = new Perceptron(2);
            p.Train(trainingData, labels);

            foreach(var input in trainingData)
            {
                double prediction = p.Predict(input);
                Console.Write("Входные данные: ");
                for(int i = 0; i < input.Length; i++)
                    Console.Write(input[i] + " ");
                Console.WriteLine($"\nПредикт: {prediction}");
            }    
            Console.ReadKey();
        }
    }
}
