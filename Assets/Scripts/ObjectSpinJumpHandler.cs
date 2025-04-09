using UnityEngine;

public class ObjectSpinJumpHandler : MonoBehaviour
{
    [Header("Spin and Float Settings")]
    public float spinSpeed = 50f; // Speed of rotation
    public float floatSpeed = 2f; // Speed of up-and-down motion
    public float floatAmplitude = 0.5f; // Amplitude of up-and-down motion

    private Vector3 initialPosition;

    private void Start()
    {
        // Store the initial position of the object
        initialPosition = transform.position;
    }

    private void Update()
    {
        // Spin the object
        SpinObject();

        // Move the object up and down
        FloatObject();
    }

    private void SpinObject()
    {
        // Rotate the object around the Y-axis
        transform.Rotate(Vector3.up, spinSpeed * Time.deltaTime);
    }

    private void FloatObject()
    {
        // Calculate the new Y position using a sine wave
        float newY = initialPosition.y + Mathf.Sin(Time.time * floatSpeed) * floatAmplitude;
        transform.position = new Vector3(initialPosition.x, newY, initialPosition.z);
    }
}
