using System.Collections.Generic;
using UnityEngine;

namespace MRI.Neural
{
    public class Network
    {
        public Transform Root;
        public List<Node> Nodes = new List<Node>();
        public List<Connection> Connections = new List<Connection>();

        public void Add(params Node[] nodes)
        {
            foreach (Node node in nodes)
            {
                Add(node);
            }
        }

        public void Add(Node node)
        {
            Nodes.Add(node);
//            node.Transform.SetParent(Root);
        }

        public void Add(params Connection[] connections)
        {
            foreach (Connection connection in connections)
            {
                Add(connection);
            }
        }

        public void Add(Connection conn)
        {
            Connections.Add(conn);
//            conn.Transform.SetParent(Root);
        }
    }
}