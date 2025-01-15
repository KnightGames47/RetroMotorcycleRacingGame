using UnityEngine;

public class CustomizationMenu_Presenter
{
    private CustomizationMenu_Model _model;
    private CustomizationMenu_View _view;

    public void Init()
    {
        _model = new CustomizationMenu_Model();
        _view = Object.FindFirstObjectByType<CustomizationMenu_View>();
        _view.EnableCustomizationPanel();

        _view.SetBackButtonListeners(OnBackButtonClicked);
        _view.SetColorButtonsListeners(OnColorButtonClicked);
    }

    public void Cleanup()
    {
        _view.DisableCustomizationPanel();
        _view.ReleaseAllButtons();
    }

    private void OnBackButtonClicked()
    {
        GameStateManager.Instance.TransitionToState(new MainMenu_GameState());
    }

    private void OnColorButtonClicked()
    {
        //Here we want to get the color associated with the button and set it as the sprite color for the character.
        Debug.LogWarning("color buttons not implemented yet");
    }
}
