using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSettings : MonoBehaviour
{
    [SerializeField] CanvasGroup settingsPanel;
    [SerializeField] Toggle toggleKeyboard;
    [SerializeField] Toggle toggleUIControls;

    [SerializeField] CarController carController; // Reference to the CarController script

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        settingsPanel.alpha = 0;
        settingsPanel.interactable = false;
        settingsPanel.blocksRaycasts = false;

        bool useUI = PlayerPrefs.GetInt("UseUIControls", 0) == 1;

        // Set the toggles without triggering value change events
        toggleKeyboard.SetIsOnWithoutNotify(!useUI);
        toggleUIControls.SetIsOnWithoutNotify(useUI);

        // Add listeners (only listen to the one being turned ON)
        toggleKeyboard.onValueChanged.AddListener((isOn) =>
        {
            if (isOn) OnControlSelected(false);
        });

        toggleUIControls.onValueChanged.AddListener((isOn) =>
        {
            if (isOn) OnControlSelected(true);
        });
    }

    // Save the selected control scheme
    private void OnControlSelected(bool useUIControls)
    {
        carController.ChangeControlSettings(useUIControls); // Update the car controller with the selected control scheme
        PlayerPrefs.SetInt("UseUIControls", useUIControls ? 1 : 0);
        PlayerPrefs.Save();
    }

    public void ShowSettings()
    {
        settingsPanel.alpha = 1;
        settingsPanel.interactable = true;
        settingsPanel.blocksRaycasts = true;
    }

    public void HideSettings()
    {
        settingsPanel.alpha = 0;
        settingsPanel.interactable = false;
        settingsPanel.blocksRaycasts = false;
    }

    public void ExitButton()
    {
        SceneManager.LoadScene(0); // Load the main menu scene
    }
}
