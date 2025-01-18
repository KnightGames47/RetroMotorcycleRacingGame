using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class InGameSettings_View : MonoBehaviour
{
    //The pause menu presenter is going to be the presenter used for this view...

    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private Button backButton;
    [SerializeField] private Slider musicVolumeSlider;
    [SerializeField] private Slider soundFXVolumeSlider;
    [SerializeField] private TMP_Dropdown displayDropdown;

    public void EnableSettingsPanel()
    {
        settingsPanel.SetActive(true);
    }
    public void DisableSettingsPanel()
    {
        settingsPanel?.SetActive(false);
    }

    public void SetBackButtonListeners(UnityAction action)
    {
        backButton.onClick.AddListener(action);
    }

    public void ReleaseAllButtonListeners()
    {
        backButton.onClick.RemoveAllListeners();
    }

    //TODO: We have to figure out what to do with the sliders and dropdown...
}
