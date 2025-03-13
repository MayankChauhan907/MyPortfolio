using UnityEngine;

public class InteractionTrigger : MonoBehaviour
{
    public enum SectionType { Profile, Skills, Experience, BestGames, Technologies, Resume }
    public SectionType sectionType;

    public GameObject uiPanel; // Assign Canvas UI (For Profile)
    public GameObject floating3DUI; // Assign 3D Elements (For Skills, Tech, etc.)

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            Debug.Log("Entered: " + sectionType.ToString());
            ShowSection();
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
            uiPanel.SetActive(true);

        if (floating3DUI != null)
            floating3DUI.SetActive(true);
    }

    void HideSection()
    {
        if (uiPanel != null)
            uiPanel.SetActive(false);

        if (floating3DUI != null)
            floating3DUI.SetActive(false);
    }
}
