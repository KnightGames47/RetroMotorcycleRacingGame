using UnityEngine;

public class PostRace_GameState : IGameState
{
    private RaceManager raceManager;
    private PostRace_Presenter _presenter;

    public PostRace_GameState(RaceManager manager)
    {
        raceManager = manager;
    }

    public GameStates StateType => GameStates.POST_RACE;

    public void EnterState()
    {
        //We want to show the post race stats...
        _presenter = new PostRace_Presenter();
        _presenter.Init();

        Cursor.lockState = CursorLockMode.None;
        //TODO: we also need to disable the player input here...

    }

    public void ExitState()
    {
        //we are going to handle some cleanup here.
        _presenter.Cleanup();
    }

    public void ProcessUpdate()
    {
        
    }
}
