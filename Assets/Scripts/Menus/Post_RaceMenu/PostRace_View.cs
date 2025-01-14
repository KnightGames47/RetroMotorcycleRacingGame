using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PostRace_View : MonoBehaviour
{
    [SerializeField] private GameObject postRacePanel;
    [SerializeField] private Button retryButton;
    [SerializeField] private Button quitButton;
    [SerializeField] private TMP_Text positionResult;
    [SerializeField] private TMP_Text fastestLapTimeResult;
    [SerializeField] private TMP_Text overallTimeResult;

    public void EnablePostRacePanel()
    {
        postRacePanel.SetActive(true);
    }
    public void DisablePostRacePanel()
    {
        postRacePanel.SetActive(false);
    }

    public void SetRetryButtonListeners(UnityAction action)
    {
        retryButton.onClick.AddListener(action);
    }

    public void SetMenuButtonListeners(UnityAction action)
    {
        quitButton.onClick.AddListener(action);
    }

    public void ReleaseAllButtonListeners()
    {
        retryButton?.onClick.RemoveAllListeners();
        quitButton?.onClick.RemoveAllListeners();
    }

    public void SetPositionResultText(string text)
    {
        positionResult.text = text;
    }

    public void SetFastestLapTimeText(string text)
    {
        fastestLapTimeResult.text = text;
    }

    public void SetOverallTimeText(string text)
    {
        overallTimeResult.text = text;
    }
}
