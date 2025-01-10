using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LevelSelection_View : MonoBehaviour
{
    [SerializeField] private GameObject levelSelectPanel;
    [SerializeField] private Button backButton;
    [SerializeField] private Button level_1_Button;
    [SerializeField] private Button level_2_Button;
    [SerializeField] private Button level_3_Button;
    [SerializeField] private Button level_4_Button;

    public void EnableLevelSelectionPanel()
    {
        levelSelectPanel.SetActive(true);
    }

    public void DisableLevelSelectionPanel()
    {
        levelSelectPanel?.SetActive(false);
    }

    public void SetBackButtonListeners(UnityAction action)
    {
        backButton.onClick.AddListener(action);
    }
    
    public void SetLevel1ButtonListeners(UnityAction action)
    {
        level_1_Button.onClick.AddListener(action);
    }

    public void SetLevel2ButtonListeners(UnityAction action)
    {
        level_2_Button.onClick.AddListener(action);
    }

    public void SetLevel3ButtonListeners(UnityAction action)
    {
        level_3_Button.onClick.AddListener(action); 
    }

    public void SetLevel4ButtonListeners(UnityAction action)
    {
        level_4_Button.onClick.AddListener(action);
    }

    public void ReleaseAllButtonListeners()
    {
        backButton?.onClick.RemoveAllListeners();
        level_1_Button?.onClick.RemoveAllListeners();
        level_2_Button?.onClick.RemoveAllListeners();
        level_3_Button?.onClick.RemoveAllListeners();
        level_4_Button?.onClick.RemoveAllListeners();
    }
}
