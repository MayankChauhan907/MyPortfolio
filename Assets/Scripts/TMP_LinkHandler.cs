using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class TMP_LinkHandler : MonoBehaviour, IPointerClickHandler
{
    public TMP_Text text;

    public void OnPointerClick(PointerEventData eventData)
    {
        int linkIndex = TMP_TextUtilities.FindIntersectingLink(text, eventData.position, null);

        if (linkIndex != -1) // If a link was clicked
        {
            TMP_LinkInfo linkInfo = text.textInfo.linkInfo[linkIndex];
            string link = linkInfo.GetLinkID(); // Get the actual link

            Debug.Log("Opening Link: " + link);
            Application.OpenURL(link); // Open the link in a browser or mail client
        }
    }
}
