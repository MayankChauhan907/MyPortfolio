using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuControler : MonoBehaviour
{
    [SerializeField] private Toggle toggleKeyboard;
    [SerializeField] private Toggle toggleUIControls;
    [SerializeField] private Slider volumeSlider, progressBarSlider;
    [SerializeField] private GameObject progressBar;

    private const string UseUIControlsKey = "UseUIControls";
    private const string VolumeKey = "Volume";

    private void Start()
    {
        InitializeSettings();
        InitializeVolume();
        progressBar.SetActive(false); // Ensure progress bar is hidden at start
    }

    private void InitializeSettings()
    {
        // Initialize control settings
        if (!PlayerPrefs.HasKey(UseUIControlsKey))
        {
            PlayerPrefs.SetInt(UseUIControlsKey, 0); // Default to keyboard controls
        }

        bool useUI = PlayerPrefs.GetInt(UseUIControlsKey, 0) == 1;

        // Set toggle states without triggering events
        toggleKeyboard.SetIsOnWithoutNotify(!useUI);
        toggleUIControls.SetIsOnWithoutNotify(useUI);

        // Add listeners for toggles
        toggleKeyboard.onValueChanged.AddListener(isOn => OnControlSelected(false));
        toggleUIControls.onValueChanged.AddListener(isOn => OnControlSelected(true));
    }

    private void InitializeVolume()
    {
        // Initialize volume settings
        if (!PlayerPrefs.HasKey(VolumeKey))
        {
            PlayerPrefs.SetFloat(VolumeKey, 0.5f); // Default volume
        }

        volumeSlider.value = PlayerPrefs.GetFloat(VolumeKey, 0.5f);
        volumeSlider.onValueChanged.AddListener(OnVolumeSliderChanged);
    }

    private void OnControlSelected(bool useUIControls)
    {
        PlayerPrefs.SetInt(UseUIControlsKey, useUIControls ? 1 : 0);
        PlayerPrefs.Save();
    }

    private void OnVolumeSliderChanged(float value)
    {
        PlayerPrefs.SetFloat(VolumeKey, value);
        PlayerPrefs.Save();
    }

    public void LoadGame()
    {
        progressBar.SetActive(true); // Show progress bar
        StartCoroutine(LoadSceneAsync());
    }

    private IEnumerator LoadSceneAsync()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(1); // Load the scene with index 1
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f); // Unity loads till 0.9 before activating
            if (progressBarSlider != null)
                progressBarSlider.value = progress;

            yield return null;
        }
    }
}
