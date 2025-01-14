using UnityEngine;

public class LevelSelection_Presenter
{
    private LevelSelection_View _view;
    private LevelSelection_Model _model;

    public void Init()
    {
        _model = new LevelSelection_Model();
        _view = Object.FindFirstObjectByType<LevelSelection_View>();
        Debug.Log("setting level select open");
        _view.EnableLevelSelectionPanel();

        _view.SetBackButtonListeners(OnBackClicked);
        _view.SetLevel1ButtonListeners(OnLevel1Clicked);
        _view.SetLevel2ButtonListeners(OnLevel2Clicked);
        _view.SetLevel3ButtonListeners(OnLevel3Clicked);
        _view.SetLevel4ButtonListeners(OnLevel4Clicked);
    }

    public void Cleanup()
    {
        _view.DisableLevelSelectionPanel();
        _view.ReleaseAllButtonListeners();
    }

    private void OnBackClicked()
    {
        GameStateManager.Instance.TransitionToState(new MainMenu_GameState());
    }

    private void OnLevel1Clicked()
    {
        //Open level 1 scene
        //We have to send in specific scene names if we want this to work...
        //we are going to be sending a SO through here that will contain more information than just the scene name.
        //For now, we are just passing the scene name so that we can open the scene and get started.
        GameStateManager.Instance.TransitionToState(new Racing_GameState(_model.level1Scene));
    }

    private void OnLevel2Clicked()
    {
        GameStateManager.Instance.TransitionToState(new Racing_GameState(_model.level2Scene));
    }

    private void OnLevel3Clicked()
    {
        GameStateManager.Instance.TransitionToState(new Racing_GameState(_model.level3Scene));
    }

    private void OnLevel4Clicked()
    {
        GameStateManager.Instance.TransitionToState(new Racing_GameState(_model.level4Scene));
    }
}
