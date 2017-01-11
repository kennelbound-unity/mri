using Adic;
using Adic.Container;
using Configunity.Adic;
using MRI.Neural.Commands;
using MRI.Neural.Concrete;
using UnityEngine;

namespace MRI.Neural.Contexts
{
    public class NeuralNetworkRenderingRoot : BaseContext
    {
        /// <summary>The command dispatcher.</summary>
        protected ICommandDispatcher Dispatcher;

        public override void Init()
        {
            Dispatcher.Dispatch<SpawnNetworkCommand>();
        }

        public override void SetupBindings()
        {
            // Setup the bindings
            Container.Bind<GameObject>().ToGameObject("Root").As("Root");

            // Neural Net Rendering Factories
            Container.Bind<INodeFactory>().ToSingleton<NodeFactory>();
            Container.Bind<IConnectionFactory>().ToSingleton<ConnectionFactory>();
            Container.Bind<IProviderService>().ToSingleton<DummyNetworkProvider>();
            Container.Bind<GameObject>().ToPrefab("Prefabs/Node").As("NodePrototype");
            Container.Bind<GameObject>().ToPrefab("Prefabs/Connection").As("ConnectionPrototype");
            Container.Bind<ILayoutManager>().ToSingleton<LayoutManager>();

            ConfigurationContext context = new ConfigurationContext();
            context.SetupConfigStorage(Container);

            // Setup the Graphics Configuration
            GraphicsConfigContext gc = new GraphicsConfigContext();
            gc.SetupBindings(Container);
        }

        public override void SetupCommands()
        {
            //Register any extensions the container may use.
            Container
                .RegisterExtension<CommanderContainerExtension>()
                .RegisterExtension<EventCallerContainerExtension>()
                .RegisterCommands("MRI.Neural.Commands");

            //Get a reference to the command dispatcher so it can be used to dispatch
            //commands in the Init() method.
            Dispatcher = Container.GetCommandDispatcher();
        }
    }
}