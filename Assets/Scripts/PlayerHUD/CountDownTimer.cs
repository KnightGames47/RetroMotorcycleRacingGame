using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class CountDownTimer : MonoBehaviour
{
    [SerializeField] private TMP_Text countDownTimerText;
    [SerializeField] private int countDownTime;

    private float timeRemaining;

    public UnityAction StartRace;

    public void StartCountDown()
    {
        timeRemaining = countDownTime;
    }

    private void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            UpdateTimerText();

            if(timeRemaining <= 0)
            {
                timeRemaining = 0;
                countDownTimerText.text = "";
                StartRace?.Invoke();
            }
        }
    }

    private void UpdateTimerText()
    {
        countDownTimerText.text = ((int)timeRemaining).ToString();
    }
}
