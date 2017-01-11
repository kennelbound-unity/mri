using MarkLight;

namespace MRI.Neural.View
{
    public class Options : ConfigSettingBindingUIView
    {
        public _bool DepthOfFieldEnabled;

        public override void Start()
        {
            base.Start();
            AddBinding(DepthOfFieldEnabled, ConfigNames.GraphicsSettingsDepthOfFieldEnabled);
        }

        public void Save()
        {
            PersistBindings();
        }

        public void ResetDefaults()
        {
        }
    }
}