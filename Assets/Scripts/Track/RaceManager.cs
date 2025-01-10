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
    private int totalLaps = 1;
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

        startLine.Init(this);
        finishLine.Init(this);
        foreach(var checkPoint in checkPoints)
        {
            checkPoint.Init(this);
        }

        Debug.Log("race initialized");

        //TODO: Might want to start a loading screen here for the set up...
    }

    public void CleanUp()
    {
        //releasing things...
    }

    public void StartRace()
    {
        //For now, this is going to be triggered by crossing the start line.
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

        OnLapComplete?.Invoke();
        Debug.Log($"Lap {currentLap} completed!");

        if(currentLap >= totalLaps)
        {
            EndRace();
        }
        else
        {
            currentLap++;
        }
    }

    public void EndRace()
    {
        isRaceOngoing = false;
        raceTime = Time.time - raceStartTime;
        OnRaceFinish?.Invoke();
        Debug.Log($"Race ended! Total time: {raceTime} seconds");
    }

    public void SetCurrentCheckpoint(CheckPoint checkPoint)
    {
        currentCheckpoint = checkPoint;
    }
}
 