using Adic.Container;
using Configunity.Adic;
using UnityEngine;

namespace MRI.Neural.Contexts
{
    public class InputConfigContext : ConfigurationContext
    {
        public override void AddBindings(IInjectionContainer container)
        {
            Camera camera = container.Resolve<Camera>("MainCamera");

            // Add basic flying around controls
            camera.gameObject.AddComponent<FlyCamExtended>();
        }
    }
}