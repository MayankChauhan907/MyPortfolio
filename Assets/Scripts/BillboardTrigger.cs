using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BillboardTrigger : MonoBehaviour
{
    public KnowMorePanelController knowMorePanel; // Reference to the KnowMorePanel script
    [SerializeField] CanvasGroup gameDetailsPanel; // Reference to the game details panel
    [SerializeField] ScrollRect scrollRect; // Reference to the scroll rect for smooth scrolling

    void Start()
    {
        if (gameDetailsPanel != null)
        {
            gameDetailsPanel.alpha = 0;
            gameDetailsPanel.interactable = false;
            gameDetailsPanel.blocksRaycasts = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car")) // Detect car
        {
            if (knowMorePanel != null)
            {
                knowMorePanel.ShowKnowMorePanel(gameDetailsPanel);
                scrollRect.verticalNormalizedPosition = 1f; // Scroll to the top of the panel
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            if (knowMorePanel != null)
                knowMorePanel.HideAllPanels();
        }
    }
}
