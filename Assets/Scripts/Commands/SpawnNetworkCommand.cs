using Adic;
using UnityEngine;

namespace MRI.Neural.Commands
{
    public class SpawnNetworkCommand : Command
    {
        [Inject] public ILayoutManager LayoutManager;
        [Inject] public IProviderService ProviderService;
        [Inject("Root")] public GameObject Root;

        public override void Execute(params object[] parameters)
        {
            Network network = ProviderService.GetNetwork();
            network.Root = Root.GetComponent<Transform>();
            LayoutManager.LayoutNetwork(network);
        }
    }
}