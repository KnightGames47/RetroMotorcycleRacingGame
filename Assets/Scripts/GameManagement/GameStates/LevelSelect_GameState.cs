using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect_GameState : IGameState
{
    private LevelSelection_Presenter _presenter;

    public GameStates StateType => GameStates.LEVEL_SELECT;

    //here we also create an instance of the model with the proper data - I want to get this data froma scriptable object
    //    This way we can adjust the different map settings on the fly.
    public async void EnterState()
    {
        GameStateManager.Instance.loadingScreen.EnableLoadScreen();
        await SceneManager.LoadSceneAsync("MenuScene");
        _presenter = new LevelSelection_Presenter();
        _presenter.Init();
        Cursor.lockState = CursorLockMode.Confined;
        GameStateManager.Instance.loadingScreen.DisableLoadScreen();
    }

    public void ExitState()
    {
        _presenter.Cleanup();
    }

    public void ProcessUpdate()
    {
        //throw new System.NotImplementedException();
    }
}
