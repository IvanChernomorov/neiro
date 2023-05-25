using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Perceptron
{
    internal class Perceptron
    {
        private int inputSize;
        private double learningRate;
        int maxEpoch;
        private double[] weights;

        public Perceptron(int inputSize, double learningRate = 0.1, int maxEpoch = 100)
        {
            this.inputSize = inputSize;
            this.learningRate = learningRate;
            this.maxEpoch = maxEpoch;
            this.weights = new double[inputSize + 1];
        } 

        public double Predict(double[] inputs)
        {
            double sum = 0;
            for (int i = 0; i < inputs.Length; i++)
                sum += weights[i] * inputs[i];
            sum += weights[weights.Length - 1];
            return sum >= 0 ? 1 : 0;
        }

        public void Train(double[][] inputs, double[] target)
        {
            for(int i = 0; i < maxEpoch; i++)
            {
                for(int j = 0; j < inputs.Length; j++)
                {
                    double predict = Predict(inputs[j]);
                    double error = target[j] - predict;
                    for (int k = 0; k < inputs[j].Length; k++)
                        weights[k] += learningRate * error * inputs[j][k];
                    weights[weights.Length-1] += learningRate * error;
                }
            }
        }
    }
}
