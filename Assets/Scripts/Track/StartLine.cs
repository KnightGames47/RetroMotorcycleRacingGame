using UnityEngine;

[RequireComponent(typeof(Collider))]
public class StartLine : MonoBehaviour
{
    private RaceManager _raceManager;
    public void Init(RaceManager raceManager)
    {
        _raceManager = raceManager;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!_raceManager.isRaceOngoing)
            {
                _raceManager.StartRace();
            }   
        }
    }
}
