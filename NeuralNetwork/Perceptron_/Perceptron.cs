namespace NeuralNetwork.Perceptron_
{
    public class Perceptron
    {
        public Perceptron(int numberOfInputs)
        {
            Inputs = new double[numberOfInputs];
            Weights = new double[numberOfInputs];
        }

        public double[] Inputs { get; }
        public double[] Weights { get; }
        public double Bias { get; set; }

        public Func<double, double> ActivationFunction { get; set; }

        public double Output
        {
            get
            {
                var s = Bias;
                for (var i = 0; i < Inputs.Length; i++)
                {
                    s += Inputs[i] * Weights[i];
                }
                return ActivationFunction(s);
            }
        }
    }
}
