using Adic;
using Adic.Injection;
using UnityEngine;

namespace MRI.Neural.Concrete
{
    public class ConnectionFactory : IConnectionFactory
    {
        public object Create(InjectionContext context)
        {
            return Create();
        }

        public Connection Create()
        {
            return Create(null, null, 0.2f);
        }

        public Connection Create(Node from, Node to, float weight)
        {
            var conn = new Connection()
            {
                From = from,
                To = to,
                Weight = weight
            };
            return conn;
        }
    }
}