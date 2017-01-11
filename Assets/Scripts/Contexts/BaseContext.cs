using Adic;
using Adic.Container;
using Configunity.Adic;

namespace MRI.Neural.Contexts
{
    public abstract class BaseContext : ContextRoot
    {
        /// <summary>The IoC container.</summary>
        protected IInjectionContainer Container;

        private bool _configurationContextConfigured;

        public override void SetupContainers()
        {
            //Create the container.
            Container = SetupContainer().RegisterExtension<UnityBindingContainerExtension>();
            SetupBindings();
            SetupCommands();
        }

        public virtual IInjectionContainer SetupContainer()
        {
            return AddContainer<InjectionContainer>();
        }

        public abstract void SetupBindings();

        public abstract void SetupCommands();

        public virtual void Bind<T>() where T : ConfigurationContext, new()
        {
            T t = new T();

            if (!_configurationContextConfigured)
            {
                _configurationContextConfigured = true;
                t.SetupConfigStorage(Container);
            }

            t.SetupBindings(Container);
        }
    }
}