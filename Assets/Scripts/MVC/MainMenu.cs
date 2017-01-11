using MarkLight.Views.UI;
using UnityEngine;

public class MainMenu : UIView
{
    public ViewSwitcher ContentViewSwitcher;

    public void StartGame()
    {
        ContentViewSwitcher.SwitchTo(1);
    }

    public void Options()
    {
        ContentViewSwitcher.SwitchTo(2);
    }

    public void Quit()
    {
        Application.Quit();
    }
}