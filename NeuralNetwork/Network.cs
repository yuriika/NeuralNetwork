using NeuralNetwork.Nodes;

namespace NeuralNetwork
{
    public class Network
    {
        public IList<InputNode> InputNodes { get; private set; }
        public IList<HiddenNode> HiddenNodes { get; private set; }
        public IList<OutputNode> OutputNodes { get; private set; }

        public Network(int inputNodeCount, int hiddenNodeCount, int outputNodeCount)
        {
            InputNodes = Enumerable.Range(0, inputNodeCount).Select(e => new InputNode()).ToList();
            HiddenNodes = Enumerable.Range(0, hiddenNodeCount).Select(e => new HiddenNode()).ToList();
            OutputNodes = Enumerable.Range(0, outputNodeCount).Select(e => new OutputNode()).ToList();

            // Connect the nodes
            foreach (var i in InputNodes)
            {
                foreach (var h in HiddenNodes)
                {
                    h.AddIncoming(i);
                }
            }
            foreach (var h in HiddenNodes)
            {
                foreach (var o in OutputNodes)
                {
                    o.AddIncoming(h);
                }
            }
        }

        public void Invalidate()
        {
            foreach (var n in OutputNodes)
            {
                n.Invalidate();
            }
            foreach (var n in HiddenNodes)
            {
                n.Invalidate();
            }
        }

        public double[] GetWeights()
        {
            var list = new List<double>();
            foreach (var h in HiddenNodes)
            {
                foreach (var i in h.Incoming)
                {
                    list.Add(i.Weight);
                }
                list.Add(h.Bias);
            }
            foreach (var n in OutputNodes)
            {
                foreach (var i in n.Incoming)
                {
                    list.Add(i.Weight);
                }
                list.Add(n.Bias);
            }
            return list.ToArray();
        }

        public void SetWeights(double[] weights)
        {
            var index = 0;
            foreach (var n in HiddenNodes)
            {
                foreach (var i in n.Incoming)
                {
                    i.Weight = weights[index++];
                }
                n.Bias = weights[index++];
            }
            foreach (var n in OutputNodes)
            {
                foreach (var i in n.Incoming)
                {
                    i.Weight = weights[index++];
                }
                n.Bias = weights[index++];
            }
        }
    }
}
