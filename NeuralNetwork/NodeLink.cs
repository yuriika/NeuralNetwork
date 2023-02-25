using NeuralNetwork.Nodes;

namespace NeuralNetwork
{
    public class NodeLink
    {
        public BaseNode Node { get; private set; }

        public double Weight { get; set; }

        public double Delta { get; set; }

        public NodeLink(BaseNode node)
        {
            Node = node;
        }

        public override string ToString()
        {
            return Node + " * " + Weight;
        }
    }
}
