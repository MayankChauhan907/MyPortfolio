using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIAnimator : MonoBehaviour
{
    public CanvasGroup canvasGroup; // For fade-in effect
    public RectTransform panel; // The main panel
    public Text[] animatedTexts; // Text elements inside panel
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
    }

    public void ShowUI()
    {
        // Fade in panel & scale up
        canvasGroup.DOFade(1, fadeDuration);
        panel.DOScale(Vector3.one, scaleDuration).SetEase(Ease.OutBack);

        // Animate each text element one by one
        for (int i = 0; i < animatedTexts.Length; i++)
        {
            Text txt = animatedTexts[i];
            txt.color = new Color(txt.color.r, txt.color.g, txt.color.b, 0); // Set to transparent
            txt.DOFade(1, fadeDuration).SetDelay(i * textFadeDelay); // Fade-in one by one
        }
    }

    public void HideUI()
    {
        // Fade out panel & scale down
        canvasGroup.DOFade(0, fadeDuration);
        panel.DOScale(Vector3.zero, scaleDuration).SetEase(Ease.InBack);
    }
}
