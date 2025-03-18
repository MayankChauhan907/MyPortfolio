using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class UIAnimator : MonoBehaviour
{
    public CanvasGroup canvasGroup; // For fade-in effect
    public RectTransform panel; // The main panel
    public TMP_Text[] animatedTextCanvasGroups; // Text elements inside panel
    public float fadeDuration = 0.5f;
    public float scaleDuration = 0.5f;
    public float textFadeDelay = 0.2f;

    private void Start()
    {
        // Ensure the UI is hidden at start
        if (canvasGroup != null)
            canvasGroup.alpha = 0;

        if (panel != null)
            panel.localScale = Vector3.zero;

        foreach (TMP_Text txt in animatedTextCanvasGroups)
        {
            txt.alpha = 0;
        }
    }

    public void ShowUI()
    {
        // Fade in panel & scale up
        canvasGroup.DOFade(1, fadeDuration);
        panel.DOScale(Vector3.one, scaleDuration).SetEase(Ease.OutBack);

        // Animate each text element
        for (int i = 0; i < animatedTextCanvasGroups.Length; i++)
        {
            TMP_Text txt = animatedTextCanvasGroups[i];
            Debug.Log("Animating: " + txt.text);

            txt.DOFade(1, fadeDuration).SetDelay(i * textFadeDelay).SetEase(Ease.Linear);
        }
    }

    public void HideUI()
    {
        // Fade out panel & scale down
        canvasGroup.DOFade(0, fadeDuration);
        panel.DOScale(Vector3.zero, scaleDuration).SetEase(Ease.InBack);
    }
}
