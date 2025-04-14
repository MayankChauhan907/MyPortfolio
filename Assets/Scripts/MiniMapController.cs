using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class MiniMapController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform miniMapCamTransform;

    [SerializeField] private GameObject fullscreenMap;
    [SerializeField] private Button openMapBtn, closeMapBtn;

    void Start()
    {
        fullscreenMap.SetActive(false); // Ensure the fullscreen map is initially inactive

        openMapBtn.onClick.AddListener(OpenMap); // Add listener to open map button
        closeMapBtn.onClick.AddListener(CloseMap); // Add listener to close map button
    }

    void LateUpdate()
    {
        Vector3 newLocation = player.position;
        newLocation.y = miniMapCamTransform.transform.position.y; // Keep the y position of the minimap constant
        miniMapCamTransform.transform.position = newLocation; // Update the minimap position to follow the player

        // transform.rotation = Quaternion.Euler(90f, player.eulerAngles.y, 0); // Rotate the minimap to match the player's rotation
    }

    private void OpenMap()
    {
        fullscreenMap.SetActive(true); // Activate the fullscreen map
    }

    private void CloseMap()
    {
        fullscreenMap.SetActive(false); // Deactivate the fullscreen map
    }
}
