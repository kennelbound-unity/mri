﻿using Adic;
using Adic.Container;
using AIProgrammer;
using MRI.Neural.Commands;
using MRI.Neural.Concrete;
using UnityEngine;

namespace MRI.Neural.Contexts
{
    public class ProgramCreatingContext : ContextRoot
    {
        /// <summary>The IoC container.</summary>
        protected IInjectionContainer Container;

        /// <summary>The command dispatcher.</summary>
        protected ICommandDispatcher Dispatcher;

        public override void SetupContainers()
        {
            //Create the container.
            Container = AddContainer<InjectionContainer>()
                .RegisterExtension<UnityBindingContainerExtension>();

            // Setup the bindings
            Container.Bind<GameObject>().ToGameObject("Root").As("Root");

            Container.Bind<INodeFactory>()
                .ToSingleton<NodeFactory>();

            Container.Bind<IConnectionFactory>()
                .ToSingleton<ConnectionFactory>();

            Container.Bind<IProviderService>()
                .ToSingleton<AIProgrammerProvider>();

            Container.Bind<GameObject>()
                .ToPrefab("Prefabs/Node")
                .As("NodePrototype");

            Container.Bind<GameObject>()
                .ToPrefab("Prefabs/Connection")
                .As("ConnectionPrototype");

            Container.Bind<ILayoutManager>()
                .ToSingleton<ClusteredNodeLayoutManager>();

            Container.Bind<Program>().To<Program>();

            //Register any extensions the container may use.
            Container
                .RegisterExtension<CommanderContainerExtension>()
                .RegisterExtension<EventCallerContainerExtension>()
                .RegisterCommands("MRI.Neural.Commands");


            //Get a reference to the command dispatcher so it can be used to dispatch
            //commands in the Init() method.
            Dispatcher = Container.GetCommandDispatcher();
        }

        public override void Init()
        {
//            Program.Main(new string[0]);
            Dispatcher.Dispatch<SpawnNetworkCommand>();
        }
    }
}