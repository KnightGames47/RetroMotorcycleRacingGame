using UnityEngine;

public class MainMenu_GameState : IGameState
{
    private MainMenu_Presenter _presenter;

    public GameStates StateType => GameStates.MAIN_MENU;

    public void EnterState()
    {
        _presenter = new MainMenu_Presenter();
        _presenter.Init();
        Cursor.lockState = CursorLockMode.Confined;
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
