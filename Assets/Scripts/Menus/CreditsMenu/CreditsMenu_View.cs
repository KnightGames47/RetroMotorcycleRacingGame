using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CreditsMenu_View : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private Button backButton;

    public void EnableCreditsPanel()
    {
        panel.SetActive(true);
    }

    public void DisableCreditsPanel()
    {
        panel?.SetActive(false);
    }

    public void SetBackButtonListeners(UnityAction action)
    {
        backButton.onClick.AddListener(action); 
    }

    public void ReleaseAllButtons()
    {
        backButton.onClick.RemoveAllListeners();
    }
}
