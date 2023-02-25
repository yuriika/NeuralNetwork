namespace NeuralNetwork.Perceptron_
{
    public class PerceptronTrainer
    {
        Perceptron _perceptron;

        public PerceptronTrainer(Perceptron perceptron)
        {
            _perceptron = perceptron;
        }

        public void Train(IEnumerable<PerceptronTrainingRow> rows, double adjust, long rounds)
        {
            for (var r = 0; r < rounds; r++)
            {
                foreach (var row in rows)
                {
                    RandomizeArray(row.Inputs);
                    for (var i = 0; i < row.Inputs.Length; i++)
                    {
                        _perceptron.Inputs[i] = row.Inputs[i];
                    }
                    var diff = _perceptron.Output - row.ExpectedOutput;
                    var delta = adjust * Math.Abs(diff) * Math.Sign(diff);
                    if (Math.Abs(diff) > 0)
                    {
                        for (var i = 0; i < _perceptron.Weights.Length; i++)
                        {
                            _perceptron.Weights[i] -= delta;
                            _perceptron.Bias -= delta;
                        }
                    }

                }
                Console.Write(".");
            }
            Console.WriteLine();
            Console.WriteLine(rounds);
        }

        private void RandomizeArray(double[] inputs)
        {
            for (var i = 0; i < inputs.Length; i++)
            {
                var tmp = inputs[i];
                var j = new Random().Next(0, inputs.Length);
                inputs[i] = inputs[j];
                inputs[j] = tmp;
            }
        }
    }

    public class PerceptronTrainingRow
    {
        public double[] Inputs { get; set; }
        public double ExpectedOutput { get; set; }

        public PerceptronTrainingRow(double[] inputs, double expectedOutput) { Inputs = inputs; ExpectedOutput = expectedOutput; }
    }
}
