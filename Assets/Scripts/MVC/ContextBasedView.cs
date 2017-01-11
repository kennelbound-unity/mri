using Adic;

namespace MRI.Neural.View
{
    public abstract class ContextBasedView : MarkLight.View
    {
        protected ContextRoot Context;
        public abstract void InitializeContext();

        public override void InitializeInternal()
        {
            InitializeContext();
        }
    }
}