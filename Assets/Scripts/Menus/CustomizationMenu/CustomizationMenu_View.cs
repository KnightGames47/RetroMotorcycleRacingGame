using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CustomizationMenu_View : MonoBehaviour
{
    [SerializeField] private GameObject customizationPanel;
    [SerializeField] private Button backButton;
    [SerializeField] private Button[] colorButtons;

    public void EnableCustomizationPanel()
    {
        customizationPanel.SetActive(true);
    }

    public void DisableCustomizationPanel()
    {
        customizationPanel?.SetActive(false);
    }

    public void SetBackButtonListeners(UnityAction action)
    {
        backButton.onClick.AddListener(action);
    }

    public void SetColorButtonsListeners(UnityAction action)
    {
        foreach (Button button in colorButtons)
        {
            button.onClick.AddListener(action);
        }
    }

    public void ReleaseAllButtons()
    {
        backButton.onClick.RemoveAllListeners();

        foreach (Button button in colorButtons)
        {
            button.onClick.RemoveAllListeners();
        }
    }
}
