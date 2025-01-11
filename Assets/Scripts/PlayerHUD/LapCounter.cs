using TMPro;
using UnityEngine;

public class LapCounter : MonoBehaviour
{
    private TMP_Text counterText;
    private RaceManager _raceManager;

    private void OnEnable()
    {
        counterText = GetComponent<TMP_Text>();
    }


    public void SetLapCounter(int currentLap, int totalLaps)
    {
        counterText.text = $"{currentLap} / {totalLaps}";
    }
}
