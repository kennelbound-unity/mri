using System;
using System.Collections.Generic;
using Adic;
using Configunity;
using MarkLight;
using MarkLight.Views.UI;

namespace MRI.Neural.View
{
    public class ConfigSettingBindingUIView : UIView
    {
        private List<ConfigSetting> Settings = new List<ConfigSetting>();

        [Inject] public IConfigStorage Storage;

        public virtual void Start()
        {
            this.Inject();
        }

        public void AddBinding<T>(ViewField<T> field, string settingName)
        {
            // Get the appropriate setting
            ConfigSetting setting = Storage.Get(settingName);
            if (setting == null)
            {
                throw new Exception("Could not bind field to setting: " + settingName);
            }

            field.Value = (T) setting.Value;
            field.ValueSet += (sender, args) => { setting.Value = field.Value; };
            Settings.Add(setting);
        }

        public void AddBinding(ViewField<bool> field, string settingName)
        {
            AddBinding<bool>(field, settingName);
        }

        public void AddBinding(ViewField<float> field, string settingName)
        {
            AddBinding<float>(field, settingName);
        }

        public void AddBinding(ViewField<int> field, string settingName)
        {
            AddBinding<int>(field, settingName);
        }

        public void AddBinding(ViewField<string> field, string settingName)
        {
            AddBinding<string>(field, settingName);
        }

        public void PersistBindings()
        {
            foreach (ConfigSetting configSetting in Settings)
            {
                // Will update the values and trigger the persist event
                Storage.Set(configSetting);
            }
        }
    }
}