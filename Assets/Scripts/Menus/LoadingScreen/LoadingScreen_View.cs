using UnityEngine;

public class LoadingScreen_View : MonoBehaviour
{
    [SerializeField] private GameObject loadingPanel;

    public void EnableLoadingPanel()
    {
        loadingPanel.SetActive(true);
    }

    public void DisableLoadingPanel()
    {
        loadingPanel.SetActive(false);
    }
}
