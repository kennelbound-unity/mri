using Adic;
using Adic.Container;
using Configunity;
using Configunity.Adic;
using MRI.Neural.View;
using UnityEngine;
using UnityStandardAssets.ImageEffects;

namespace MRI.Neural.Contexts
{
    public class GraphicsConfigContext : ConfigurationContext
    {
        public override void AddBindings(IInjectionContainer container)
        {
            // Setup the Camera
            container.Bind<Camera>().ToGameObjectsWithTag<Camera>("MainCamera").As("MainCamera");
            Camera camera = container.Resolve<Camera>("MainCamera");
            camera.gameObject.AddComponent<DepthOfField>();

            // Add all the configuration options here
            ConfigSetting dofe = AddConfigOption(container, ConfigSettingType.Bool,
                ConfigNames.GraphicsSettingsDepthOfFieldEnabled, false);

            // Bind the camera
            AddComponentBinding(camera.GetComponent<DepthOfField>(), dofe, "enabled");
        }
    }
}