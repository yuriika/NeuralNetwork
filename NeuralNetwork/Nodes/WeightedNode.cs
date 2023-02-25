namespace NeuralNetwork.Nodes
{
    public abstract class WeightedNode : BaseNode
    {
        protected Func<double, double> _activationFunction;
        protected double? _value;

        public double Bias { get; set; }

        public List<NodeLink> Incoming { get; private set; }

        public WeightedNode()
        {
            Incoming = new List<NodeLink>();
            Bias = Helpers.GetRandomWeight();
        }

        public void AddIncoming(BaseNode node)
        {
            Incoming.Add(new NodeLink(node) { Weight = Helpers.GetRandomWeight() });
        }

        public void Invalidate()
        {
            _value = null;
        }

        public override double Value
        {
            get
            {
                if (!_value.HasValue)
                {
                    var v = Bias + Incoming.Sum(i => i.Node.Value * i.Weight);
                    _value = _activationFunction(v);
                }
                return _value.Value;
            }
            set
            {
                throw new InvalidOperationException();
            }
        }
    }
}
