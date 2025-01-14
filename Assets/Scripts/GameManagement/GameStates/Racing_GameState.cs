using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Racing_GameState : IGameState
{
    public RaceManager raceManager {  get; private set; }

    private string sceneToOpen;
    private UnityEvent sceneLoaded;

    //This is eventually going to contain a SO for the level data.
    public Racing_GameState(string sceneName)
    {
        //we need to fill the information
        sceneToOpen = sceneName;
    }

    public async void EnterState()
    {
        GameStateManager.Instance.loadingScreen.EnableLoadScreen();
        await SceneManager.LoadSceneAsync(sceneToOpen);
        
        raceManager = new RaceManager();
        raceManager.Init();
        GameStateManager.Instance.loadingScreen.DisableLoadScreen();
    }

    public void ExitState()
    {
        raceManager.CleanUp();
    }

    public void ProcessUpdate()
    {

    }
}
