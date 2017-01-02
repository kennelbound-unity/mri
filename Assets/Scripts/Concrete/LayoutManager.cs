using Adic;
using UnityEngine;

namespace MRI.Neural.Concrete
{
    public class LayoutManager : ILayoutManager
    {
        [Inject("NodePrototype")] public GameObject NodePrototype;
        [Inject("ConnectionPrototype")] public GameObject ConnectionPrototype;

        public void LayoutNetwork(Network network)
        {
            NodePrototype.SetActive(true);
            ConnectionPrototype.SetActive(true);

            foreach (Node node in network.Nodes)
            {
                AddGameObject(node);
                node.Transform.localPosition = Random.onUnitSphere * 2f;
                node.Transform.localScale = Vector3.one * node.Weight;
                node.Transform.SetParent(network.Root);
            }

            foreach (Connection conn in network.Connections)
            {
                AddGameObject(conn);
                LineRenderer lr = conn.Transform.GetComponent<LineRenderer>();
                if (lr == null)
                {
                    lr = conn.Transform.gameObject.AddComponent<LineRenderer>();
                }

                // Style the connection
                Color color = Color.white;
                lr.SetColors(color, color);

                float size = Mathf.Abs(conn.Weight) / 100;
                lr.SetWidth(size, size);

                lr.SetPosition(0, conn.From.Transform.position);
                lr.SetPosition(1, conn.To.Transform.position);
                conn.Transform.SetParent(network.Root);
            }

            NodePrototype.SetActive(false);
            ConnectionPrototype.SetActive(false);
        }

        public void AddGameObject(Node node)
        {
            node.Transform = GameObject.Instantiate(NodePrototype).transform;
        }

        public void AddGameObject(Connection conn)
        {
            conn.Transform = GameObject.Instantiate(ConnectionPrototype).transform;
        }
    }
}