using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BillboardTrigger : MonoBehaviour
{
    public KnowMorePanelController knowMorePanel; // Reference to the KnowMorePanel script
    [SerializeField] CanvasGroup gameDetailsPanel; // Reference to the game details panel

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
                knowMorePanel.ShowPanel(gameDetailsPanel);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            if (knowMorePanel != null)
                knowMorePanel.HidePanel();
        }
    }
}
