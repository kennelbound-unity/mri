using System.Collections.Generic;
using Adic;
using MarkLight;
using UnityEngine;

namespace MRI.Neural.Commands
{
    public class FaceNodeCommand : Command
    {
        [Inject("MainCamera")] public Camera MainCamera;
        [Inject("Root")] public GameObject Root;

        public override void Execute(params object[] parameters)
        {
            Transform rootTransform = Root.transform;
            int index = Random.Range(0, rootTransform.childCount);
            Transform childTransform = rootTransform.GetChild(index);
            MainCamera.transform.LookAt(childTransform);
        }
    }
}