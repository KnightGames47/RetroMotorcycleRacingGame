using UnityEngine;

public class LevelSelect_GameState : IGameState
{
    private LevelSelection_Presenter _presenter;
    //here we also create an instance of the model with the proper data - I want to get this data froma scriptable object
    //    This way we can adjust the different map settings on the fly.
    public void EnterState()
    {
        _presenter = new LevelSelection_Presenter();
        _presenter.Init();
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
