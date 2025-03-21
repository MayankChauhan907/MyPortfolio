using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening; // For smooth animations

public class KnowMorePanelController : MonoBehaviour
{
    [Header("UI Elements")]
    public CanvasGroup panelCanvasGroup; // Canvas group for smooth fade
    public TextMeshProUGUI gameTitleText; // TMP text for game title
    public Button knowMoreButton; // Button to open game link
    private CanvasGroup gameDetailsPanel;

    [Header("Game Details")]
    public string gameTitle; // Title of the game
    public string gameInfoURL; // URL for the game project

    private void Start()
    {
        // Hide the panel at start
        panelCanvasGroup.alpha = 0;
        panelCanvasGroup.interactable = false;
        panelCanvasGroup.blocksRaycasts = false;
    }

    public void ShowPanel(CanvasGroup panel)
    {
        Debug.Log("Showing panel: " + panel.name);
        gameDetailsPanel = panel;
        // gameTitleText.text = gameTitle; // Set the game title dynamically
        knowMoreButton.onClick.RemoveAllListeners();
        knowMoreButton.onClick.AddListener(() => OpenGameInfo());

        // Fade in smoothly
        panelCanvasGroup.DOFade(1f, 0.5f).SetEase(Ease.OutSine);
        panelCanvasGroup.interactable = true;
        panelCanvasGroup.blocksRaycasts = true;
    }

    public void HidePanel()
    {
        // Fade out smoothly
        panelCanvasGroup.DOFade(0f, 0.5f).SetEase(Ease.InSine)
            .OnComplete(() =>
            {
                panelCanvasGroup.interactable = false;
                panelCanvasGroup.blocksRaycasts = false;
                gameDetailsPanel.DOFade(0f, 0.5f).SetEase(Ease.OutSine);
            });
    }

    private void OpenGameInfo()
    {
        Debug.Log("Opening game info: ");

        panelCanvasGroup.DOFade(0f, 0.5f).SetEase(Ease.InSine)
        .OnComplete(() =>
        {
            panelCanvasGroup.interactable = false;
            panelCanvasGroup.blocksRaycasts = false;
            gameDetailsPanel.DOFade(1f, 0.5f).SetEase(Ease.OutSine);
        });
    }
}
