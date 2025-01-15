using UnityEngine;
using UnityEngine.SceneManagement;

public class PostRace_Presenter
{
    private PostRace_View _view;
    private PostRace_Model _model;

    public void Init()
    {
        _model = new PostRace_Model();
        _view = Object.FindFirstObjectByType<PostRace_View>();
        _view.EnablePostRacePanel();

        _view.SetRetryButtonListeners(OnRetryClicked);
        _view.SetMenuButtonListeners(OnQuitClicked);    
    }

    public void Cleanup()
    {
        _view.DisablePostRacePanel();
        _view.ReleaseAllButtonListeners();
    }

    private void OnRetryClicked()
    {
        GameStateManager.Instance.loadingScreen.EnableLoadScreen();
        GameStateManager.Instance.TransitionToState(new Racing_GameState(SceneManager.GetActiveScene().name));
        GameStateManager.Instance.loadingScreen.DisableLoadScreen();
    }

    private async void OnQuitClicked()
    {
        GameStateManager.Instance.loadingScreen.EnableLoadScreen();
        await SceneManager.LoadSceneAsync(_model.mainMenuScene);
        GameStateManager.Instance.TransitionToState(new LevelSelect_GameState());
        GameStateManager.Instance.loadingScreen.DisableLoadScreen();
    }
}
