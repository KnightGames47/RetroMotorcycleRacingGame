using UnityEngine;

public class LevelSelection_Model
{
    //This will contain information about locked levels and what levels we have access to.
    public string level1Scene { get; private set; } = "Track_01_Scene";
    public string level2Scene { get; private set; } = "Track_02_Scene";
    public string level3Scene { get; private set; } = "Track_03_Scene";
    public string level4Scene { get; private set; } = "Track_04_Scene";
}
