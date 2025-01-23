using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class RaceManager
{
    private StartLine startLine;
    private FinishLine finishLine;
    private  CheckPoint[] checkPoints;
    public int totalLaps { get; private set; } = 1;
    public GameObject player { get; private set; }
    private LapCounter _lapCounter;
    
    public CheckPoint currentCheckpoint { get; private set; }

    public bool isRaceOngoing { get; private set; } = false;
    public int currentLap { get; private set; } = 0;
    public float raceStartTime { get; private set; } = 0f;
    public float raceTime { get; private set; } = 0f;
    public float currentLapTime { get; private set; } = 0f;
    public int playerPosition { get; private set; }//Depending on checks compared to other NPCs

    public UnityAction OnRaceStart;
    public UnityAction OnRaceFinish;
    public UnityAction OnLapComplete;


    public void Init()
    {
        startLine = Object.FindFirstObjectByType<StartLine>();
        finishLine = Object.FindFirstObjectByType<FinishLine>();
        checkPoints = Resources.FindObjectsOfTypeAll(typeof(CheckPoint)) as CheckPoint[];

        player = GameObject.FindGameObjectWithTag("Player");
        _lapCounter = Object.FindFirstObjectByType<LapCounter>();

        startLine.Init(this);
        finishLine.Init(this);
        foreach(var checkPoint in checkPoints)
        {
            checkPoint.Init(this);
        }

        _lapCounter.SetLapCounter(currentLap, totalLaps);

        Debug.Log("race initialized");
    }

    public void CleanUp()
    {
        //releasing things...
    }

    public void StartRace()
    {
        //For now, this is going to be triggered by crossing the start line.
        //We want this to eventually be done by a count down timer.
        raceStartTime = Time.time;
        isRaceOngoing = true;
        currentLap = 1;
        OnRaceStart?.Invoke();
        Debug.Log("Starting Race");
    }

    public void CompleteLap()
    {
        //should do a checkpoint check to make sure this is being set.
        if (!isRaceOngoing) return;

        
        Debug.Log($"Lap {currentLap} completed!");

        if(currentLap >= totalLaps)
        {
            EndRace();
        }
        else
        {
            currentLap++;
            OnLapComplete?.Invoke();
            _lapCounter.SetLapCounter(currentLap, totalLaps);
        }
    }

    public void EndRace()
    {
        isRaceOngoing = false;
        raceTime = Time.time - raceStartTime;
        OnRaceFinish?.Invoke();
        Debug.Log($"Race ended! Total time: {raceTime} seconds");

        //Here we are going to show the post race screen
        GameStateManager.Instance?.TransitionToState(new PostRace_GameState(this));
    }

    public void SetCurrentCheckpoint(CheckPoint checkPoint)
    {
        currentCheckpoint = checkPoint;
    }
}
 