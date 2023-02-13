// See https://aka.ms/new-console-template for more information
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NeuralNetwork;

Console.WriteLine("Hello, World!");

Test.TestLogicalOr();

static class Test
{
    [TestMethod]
    public static void TestLogicalOr()
    {
        var perceptron = new Perceptron(2);
        perceptron.ActivationFunction = x => x >= 1.0 ? 1.0 : 0.0;
        perceptron.Bias = 0;
        perceptron.Weights[0] = 1;
        perceptron.Weights[1] = 1;

        perceptron.Inputs[0] = 0;
        perceptron.Inputs[1] = 0;
        Assert.AreEqual(0, perceptron.Output);
        Console.WriteLine(perceptron.Output);

        perceptron.Inputs[0] = 0;
        perceptron.Inputs[1] = 1;
        Assert.AreEqual(1, perceptron.Output);
        Console.WriteLine(perceptron.Output);

        perceptron.Inputs[0] = 1;
        perceptron.Inputs[1] = 0;
        Assert.AreEqual(1, perceptron.Output);
        Console.WriteLine(perceptron.Output);

        perceptron.Inputs[0] = 1;
        perceptron.Inputs[1] = 1;
        Assert.AreEqual(1, perceptron.Output);
        Console.WriteLine(perceptron.Output);
    }
}