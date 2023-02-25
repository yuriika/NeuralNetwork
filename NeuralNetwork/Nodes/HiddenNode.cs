namespace NeuralNetwork.Nodes
{
    public class HiddenNode : WeightedNode
    {
        public HiddenNode()
        {
            _activationFunction = HyperTangens;
        }

        private static double HyperTangens(double value)
        {
            if (value < -45.0) return -1.0;
            else if (value > 45.0) return 1.0;

            return Math.Tanh(value);
        }

        public double BiasDelta { get; set; }
    }
}
