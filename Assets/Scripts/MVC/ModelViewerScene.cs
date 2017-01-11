using MarkLight.Views.UI;
using MRI.Neural.Contexts;

namespace MRI.Neural.View
{
    public class ModelViewerScene : ContextBasedView
    {
        public ViewSwitcher MainContentSwitcher;

        public override void InitializeContext()
        {
            Context = GameObject.AddComponent<AIProgrammingNetworkRoot>();
        }
    }
}