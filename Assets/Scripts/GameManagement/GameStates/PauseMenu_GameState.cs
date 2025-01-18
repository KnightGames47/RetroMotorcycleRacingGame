using UnityEngine;

public class PauseMenu_GameState : IGameState
{
    private PauseMenu_Presenter _presenter;

    GameStates IGameState.StateType => GameStates.PAUSE;

    public PauseMenu_GameState()
    {
    }
    
    public void EnterState()
    {
        _presenter = new PauseMenu_Presenter();
        _presenter.Init();
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void ExitState()
    {
        _presenter.Cleanup();
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void ProcessUpdate()
    {
    }
}
