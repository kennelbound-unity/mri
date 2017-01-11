using MarkLight;
using MarkLight.Views.UI;

namespace MRI.Neural.MVC
{
    public class PauseMenu : UIView
    {
        public ViewSwitcher MainContentSwitcher;

        public void Resume()
        {
            LayoutRoot.IsActive.Value = false;
        }

        public void Pause()
        {
            LayoutRoot.IsActive.Value = true;
        }

        public void Quit()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
        }
    }
}