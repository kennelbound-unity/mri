using Adic;

namespace MRI.Neural
{
    public interface IConnectionFactory : IFactory
    {
        Connection Create();
        Connection Create(Node from, Node to, float weight);
    }
}