using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuControler : MonoBehaviour
{
    [SerializeField] Toggle toggleKeyboard;
    [SerializeField] Toggle toggleUIControls;

    public Slider progressBar;
    public Text progressText;

    private void Start()
    {
        // Load saved setting (default: keyboard if nothing saved)
        if (!PlayerPrefs.HasKey("UseUIControls"))
        {
            PlayerPrefs.SetInt("UseUIControls", 0);
        }
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

        progressBar.gameObject.SetActive(false); // Hide progress bar at start
    }

    private void OnControlSelected(bool useUIControls)
    {
        PlayerPrefs.SetInt("UseUIControls", useUIControls ? 1 : 0);
        PlayerPrefs.Save();
    }


    public void LoadGame()
    {
        progressBar.gameObject.SetActive(true); // Show progress bar
        StartCoroutine(LoadSceneAsync());
    }

    IEnumerator LoadSceneAsync()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(1); // Load the scene with index 1

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f); // Unity loads till 0.9 before activating
            if (progressBar != null)
                progressBar.value = progress;

            if (progressText != null)
                progressText.text = Mathf.RoundToInt(progress * 100f) + "%";

            yield return null;
        }
    }
}
