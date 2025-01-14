using UnityEngine;

public class LoadingScreen_Presenter
{
    private LoadingScreen_View _view;
    public void Init()
    {
        _view = Object.FindFirstObjectByType<LoadingScreen_View>();
    }

    public void EnableLoadScreen()
    {
        _view.EnableLoadingPanel();
    }

    public void DisableLoadScreen()
    {
        _view.DisableLoadingPanel();
    }
}
