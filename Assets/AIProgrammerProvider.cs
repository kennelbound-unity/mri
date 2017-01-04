using System.Collections.Generic;
using System.Linq;
using Adic;
using AIProgrammer.GeneticAlgorithm;
using AIProgrammer.Types;
using MRI.Neural;
using Network = MRI.Neural.Network;

public class AIProgrammerProvider : IProviderService
{
    [Inject] public INodeFactory NodeFactory;
    [Inject] public IConnectionFactory ConnectionFactory;

    public Network GetNetwork()
    {
        Network network = new Network();

        GA ga = new GA();
        ga.Load("my-genetic-algorithm.dat");

        List<Genome> orderedGenome = new List<Genome>(ga.GAParams.ThisGeneration);
        orderedGenome.Sort((a, b) => (a.Fitness.CompareTo(b.Fitness)));

        Genome best = orderedGenome.First();
        Node last = null;
        foreach (double gene in best.Genes())
        {
            Node node = NodeFactory.Create((float) gene);
            network.Add(node);
            if (last != null)
            {
                network.Add(ConnectionFactory.Create(last, node, 1.0f));
            }
            last = node;
        }

        return network;
    }
}