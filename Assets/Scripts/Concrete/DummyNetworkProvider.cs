using Adic;

namespace MRI.Neural.Concrete
{
    public class DummyNetworkProvider : IProviderService
    {
        [Inject] public INodeFactory NodeFactory;
        [Inject] public IConnectionFactory ConnectionFactory;

        public Network GetNetwork()
        {
            Network network = new Network();
            Node node1, node2, node3, node4;
            node1 = NodeFactory.Create(0.5f);
            node2 = NodeFactory.Create(0.2f);
            node3 = NodeFactory.Create(0.2f);
            node4 = NodeFactory.Create(0.2f);

            network.Add(node1, node2, node3, node4);

            network.Add(
                ConnectionFactory.Create(node1, node2, 0.1f),
                ConnectionFactory.Create(node2, node3, 0.1f),
                ConnectionFactory.Create(node3, node4, 0.1f),
                ConnectionFactory.Create(node2, node4, 0.1f),
                ConnectionFactory.Create(node1, node4, 0.1f)
            );

            return network;
        }
    }
}