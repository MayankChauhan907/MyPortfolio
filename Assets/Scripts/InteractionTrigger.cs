using UnityEngine;

public class InteractionTrigger : MonoBehaviour
{
    public enum SectionType { Profile, Skills, Experience, BestGames, Technologies, Resume }
    public SectionType sectionType;

    public UIAnimator uiPanel; // Assign Canvas UI (For Profile)

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            Debug.Log("Entered: " + sectionType.ToString());
            ShowSection();
            other.GetComponentInParent<CarController>().StopCarImmediately();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            HideSection();
        }
    }

    void ShowSection()
    {
        if (uiPanel != null)
            uiPanel.ShowUI();
    }

    void HideSection()
    {
        if (uiPanel != null)
            uiPanel.HideUI();
    }
}
