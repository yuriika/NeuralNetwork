using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NeuralNetwork.Perceptron_
{
    public static class TestTraining
    {
        [TestMethod]
        public static void TestTrainingBounce()
        {
            var perceptron = new Perceptron(2);
            perceptron.ActivationFunction = x => x >= 1 ? 1 : 0;
            var trainer = new PerceptronTrainer(perceptron);
            var rows = new[]
            {
                new PerceptronTrainingRow ( new [] { 0.0, 1.0 }, 0),
                new PerceptronTrainingRow ( new [] { 0.5, 1.0 }, 0),
                new PerceptronTrainingRow ( new [] { 1.0, 0.0 }, 0),
                new PerceptronTrainingRow ( new [] { 1.5, 5.0 }, 0),
                new PerceptronTrainingRow ( new [] { 3.0, 3.0 }, 0),
                new PerceptronTrainingRow ( new [] { 3.5, 0.0 }, 0),
                new PerceptronTrainingRow ( new [] { 1.0, 6.0 }, 1),
                new PerceptronTrainingRow ( new [] { 2.0, 9.0 }, 1),
                new PerceptronTrainingRow ( new [] { 4.0, 6.0 }, 1),
                new PerceptronTrainingRow ( new [] { 5.5, 1.0 }, 1),
                new PerceptronTrainingRow ( new [] { 6.0, 4.0 }, 1),
                new PerceptronTrainingRow ( new [] { 9.0, 3.0 }, 1),
            };
            trainer.Train(rows, 0.01, 500);

            perceptron.Inputs[0] = 2.0;
            perceptron.Inputs[1] = 2.0;
            //Assert.AreEqual(0, perceptron.Output);
            Console.WriteLine(perceptron.Output);

            perceptron.Inputs[0] = 7.0;
            perceptron.Inputs[1] = 6.0;
            //Assert.AreEqual(1, perceptron.Output);
            Console.WriteLine(perceptron.Output);
        }
    }
}
