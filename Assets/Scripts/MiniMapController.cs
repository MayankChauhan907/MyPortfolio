using Unity.Mathematics;
using UnityEngine;

public class MiniMapController : MonoBehaviour
{
    [SerializeField] private Transform player;

    void LateUpdate()
    {
        Vector3 newLocation = player.position;
        newLocation.y = transform.position.y; // Keep the y position of the minimap constant
        transform.position = newLocation; // Update the minimap position to follow the player

        // transform.rotation = Quaternion.Euler(90f, player.eulerAngles.y, 0); // Rotate the minimap to match the player's rotation
    }

    public void OpenMap()
    {
        // Open the map UI
        // Implement your logic to open the map here
        Debug.Log("Map opened");
    }
}
