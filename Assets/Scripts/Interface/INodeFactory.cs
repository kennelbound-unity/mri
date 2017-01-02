using Adic;

namespace MRI.Neural
{
    public interface INodeFactory : IFactory
    {
        Node Create();
        Node Create(float weight);
    }
}