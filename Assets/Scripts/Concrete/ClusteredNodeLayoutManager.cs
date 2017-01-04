using System.Collections.Generic;
using System.Net;
using System.Runtime.InteropServices;
using UnityEngine;

namespace MRI.Neural.Concrete
{
    public class ClusteredNodeLayoutManager : LayoutManager
    {
        public float NodeScale = 0.08f;
        public float ClusterMinScale = 0.2f;
        public float ClusterMaxScale = 0.5f;
        public float MaxDistance = 5f;

        public override void LayoutNetwork(Network network)
        {
            NodePrototype.SetActive(true);
            ConnectionPrototype.SetActive(true);

            Dictionary<Node, List<Node>> relationships = new Dictionary<Node, List<Node>>();
            foreach (Connection conn in network.Connections)
            {
                if (!relationships.ContainsKey(conn.From))
                {
                    relationships[conn.From] = new List<Node>();
                }

                relationships[conn.From].Add(conn.To);
            }

            foreach (Node node in network.Nodes)
            {
                SetupNode(node, null, relationships, network.Root);
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

                float size = Mathf.Abs(conn.Weight) / network.Connections.Count;
                lr.SetWidth(size, size);

                lr.SetPosition(0, conn.From.Transform.position);
                lr.SetPosition(1, conn.To.Transform.position);
                conn.Transform.SetParent(network.Root);
            }

            NodePrototype.SetActive(false);
            ConnectionPrototype.SetActive(false);
        }

        protected void SetupNode(Node node, Node parent, Dictionary<Node, List<Node>> relationships, Transform root)
        {
            if (node.Transform == null)
            {
                AddGameObject(node);
                node.Transform.SetParent(root);
                node.Transform.localScale = Vector3.one * NodeScale;
                node.Transform.gameObject.GetComponent<Renderer>().material.color =
                    Color.Lerp(Color.red, Color.Lerp(Color.blue, Color.green, Random.Range(0, 1f)),
                        Random.Range(0, 1f));

                if (parent == null)
                {
                    node.Transform.localPosition = Random.onUnitSphere * Random.Range(-1 * MaxDistance, MaxDistance);
                }
                else
                {
                    node.Transform.localPosition = parent.Transform.localPosition +
                                                   Random.onUnitSphere * Random.Range(ClusterMinScale, ClusterMaxScale);
                }

                // cluster related items together
                if (relationships.ContainsKey(node))
                {
                    foreach (Node rel in relationships[node])
                    {
                        SetupNode(rel, node, relationships, root);
                    }
                }
            }
        }
    }
}