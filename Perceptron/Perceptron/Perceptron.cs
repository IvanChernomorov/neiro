using System;
using System.Runtime.InteropServices;

namespace Perceptron
{
    public class Perceptron
    {
        private int inputSize;
        private int hiddenSize;
        private double learningRate;
        private int maxEpoch;
        private double[,] inputWeights;
        private double[] hiddenWeights;

        public Perceptron(int inputSize, int hiddenSize, double learningRate = 0.1, int maxEpoch = 100)
        {
            Random rand = new Random();
            inputWeights = new double[hiddenSize, inputSize];
            for(int i = 0; i < hiddenSize; i++)
                for(int j = 0; j < inputSize; j++)
                    inputWeights[i, j] = rand.NextDouble() * 2 - 1;

            hiddenWeights = new double[hiddenSize];
            for (int i = 0; i < hiddenSize; i++)
                hiddenWeights[i] = rand.NextDouble() * 2 - 1;

            this.learningRate = learningRate;
            this.maxEpoch = maxEpoch;
            this.hiddenSize = hiddenSize;
            this.inputSize = inputSize;
        }

        public double F(double x)
        {
            return (Math.Exp(x) - Math.Exp(-x)) / (Math.Exp(x) + Math.Exp(-x));
        }

        public double DF(double x)
        {
            return 1 - Math.Pow(F(x), 2);
        }

        public double[] Predict(double[] input)
        {
            double[] sum = new double[hiddenSize];

            for (int i = 0; i < hiddenSize; i++)
            {
                for (int j = 0; j < inputSize; j++)
                    sum[i] += inputWeights[i, j] * input[j];
                sum[i] = F(sum[i]);
            }

            double res = 0.0;
            for (int i = 0; i < hiddenSize; i++)
                res += hiddenWeights[i] * sum[i];
            res = F(res);

            double[] out1 = new double[hiddenSize + 1];
            out1[0] = res;
            for (int i = 1; i < hiddenSize + 1; i++)
                out1[i] = sum[i - 1];

            return out1;
        }

        public void Train(double[][] inputs, double[] targets)
        {
            Random rand = new Random();

            for (int k = 0; k < maxEpoch; k++)
            {
                int randInput = rand.Next(0, inputs.Length);

                double[] x = inputs[randInput];
                double[] result = Predict(x);

                double delta = (result[0] - targets[randInput]) * DF(result[0]);
               
                for(int i = 0; i < hiddenSize; i++)
                    hiddenWeights[i] -= learningRate * delta * result[i+1];

                double[] delta2 = new double[hiddenSize];
                for (int i = 0; i < hiddenSize; i++)
                    delta2[i] = hiddenWeights[i] * delta * DF(result[i + 1]);

                for (int i = 0; i < hiddenSize; i++)
                    for (int j = 0; j < inputSize; j++)
                        inputWeights[i, j] -= x[j] * delta2[i] * learningRate;
            }
        }
    }

}
