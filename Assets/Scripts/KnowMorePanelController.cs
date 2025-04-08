using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.Events;

public class KnowMorePanelController : MonoBehaviour
{
    [Header("UI Elements")]
    public CanvasGroup knowMorePanel;
    public Button knowMoreButton;

    [Header("Animation Settings")]
    [SerializeField] private float fadeDuration = 0.5f;
    [SerializeField] private Ease fadeInEase = Ease.OutSine;
    [SerializeField] private Ease fadeOutEase = Ease.InSine;

    [SerializeField] private CanvasGroup currentDetailPanel;

    private void Start()
    {
        HideCanvasGroup(knowMorePanel);
    }

    public void ShowKnowMorePanel(CanvasGroup newDetailPanel = null)
    {
        if (currentDetailPanel != null)
            HideCanvasGroup(currentDetailPanel);

        if (newDetailPanel != null) currentDetailPanel = newDetailPanel;

        knowMoreButton.onClick.RemoveAllListeners();
        knowMoreButton.onClick.AddListener(SwitchToGameDetailsPanel);

        FadeCanvasGroup(knowMorePanel, true);
    }

    public void HideAllPanels()
    {
        if (currentDetailPanel != null)
            HideCanvasGroup(currentDetailPanel);

        HideCanvasGroup(knowMorePanel);
    }

    public void SwitchToGameDetailsPanel()
    {
        if (currentDetailPanel == null) return;

        FadeCanvasGroup(knowMorePanel, false, () =>
        {
            FadeCanvasGroup(currentDetailPanel, true);
        });
    }

    public void SwitchBackToKnowMorePanel()
    {
        if (currentDetailPanel == null) return;

        FadeCanvasGroup(currentDetailPanel, false, () =>
        {
            FadeCanvasGroup(knowMorePanel, true);
        });
    }

    #region Helpers

    private void FadeCanvasGroup(CanvasGroup group, bool show, UnityAction onComplete = null)
    {
        DOTween.Kill(group); // Prevent overlapping tweens

        float targetAlpha = show ? 1f : 0f;
        Ease ease = show ? fadeInEase : fadeOutEase;

        group.DOFade(targetAlpha, fadeDuration).SetEase(ease).OnComplete(() =>
        {
            group.interactable = show;
            group.blocksRaycasts = show;
            onComplete?.Invoke();
        });
    }

    private void HideCanvasGroup(CanvasGroup group)
    {
        if (group == null) return;

        DOTween.Kill(group);
        group.alpha = 0f;
        group.interactable = false;
        group.blocksRaycasts = false;
    }

    #endregion
}
