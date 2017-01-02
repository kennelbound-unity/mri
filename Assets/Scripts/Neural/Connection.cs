using UnityEngine;

namespace MRI.Neural
{
	public class Connection
	{
		public float Weight = 1.0f;
		public Transform Transform;
		public Node From;
		public Node To;
	}
}