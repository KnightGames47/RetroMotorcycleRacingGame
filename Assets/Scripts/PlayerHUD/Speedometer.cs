using TMPro;
using UnityEngine;

public class Speedometer : MonoBehaviour
{
    [SerializeField] private GameObject player;
    
    private TMP_Text speedText;

    private void OnEnable()
    {
        speedText = GetComponent<TMP_Text>();
    }

    private void Update()
    {
        //we will need to work on this value to get the right speed...
        //Need to set up the player acceleration and deceleration for this...
        speedText.text = ((int)player.GetComponent<Rigidbody>().linearVelocity.z).ToString();   
    }
}
