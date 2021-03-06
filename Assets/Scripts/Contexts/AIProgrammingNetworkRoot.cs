﻿using Adic;
using MRI.Neural.Commands;
using MRI.Neural.Concrete;
using UnityEngine;

namespace MRI.Neural.Contexts
{
    public class AIProgrammingNetworkRoot : BaseContext
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
            Container.Bind<GameObject>().ToGameObject("Engine").As("Root");
            Container.Bind<INodeFactory>().ToSingleton<NodeFactory>();
            Container.Bind<IConnectionFactory>().ToSingleton<ConnectionFactory>();
            Container.Bind<IProviderService>().ToSingleton<AIProgrammerProvider>();
            Container.Bind<GameObject>().ToPrefab("Prefabs/Node").As("NodePrototype");
            Container.Bind<GameObject>().ToPrefab("Prefabs/Connection").As("ConnectionPrototype");
            Container.Bind<ILayoutManager>().ToSingleton<ClusteredNodeLayoutManager>();

            // Add the Graphics Configuration
//            GraphicsConfigContext context = new GraphicsConfigContext();
//            context.SetupConfigStorage(Container); // Only has to be done once.  May want to figure out a better way to manage this
//            context.SetupBindings(Container);

            Bind<GraphicsConfigContext>();
            Bind<InputConfigContext>();

//            new InputConfigContext().SetupBindings(Container);
        }

        public override void SetupCommands()
        {
            Container
                .RegisterExtension<CommanderContainerExtension>()
                .RegisterExtension<EventCallerContainerExtension>()
                .RegisterCommands("MRI.Neural.Commands");

            Dispatcher = Container.GetCommandDispatcher();
        }
    }
}