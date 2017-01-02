using Adic.Injection;

namespace MRI.Neural.Concrete
{
    public class NodeFactory : INodeFactory
    {
        public object Create(InjectionContext context)
        {
            return Create();
        }

        public Node Create()
        {
            return Create(0.2f);
        }

        public Node Create(float weight)
        {
            var node = new Node()
            {
                Weight = weight
            };
            return node;
        }
    }
}