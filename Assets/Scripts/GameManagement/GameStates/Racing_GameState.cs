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
        //await SceneManager.LoadSceneAsync(sceneToOpen);//uncomment for production...
        //Need to put something for a loading screen here...
        raceManager = new RaceManager();
        raceManager.Init();
    }

    public void ExitState()
    {
        raceManager.CleanUp();
    }

    public void ProcessUpdate()
    {

    }
}
