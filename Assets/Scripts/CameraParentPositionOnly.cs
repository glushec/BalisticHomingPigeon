using UnityEngine;

public class CameraParentPositionOnly : MonoBehaviour
{
    public Transform targetObject; // Reference to the object you want to follow

    private Vector3 offset; // Offset between camera and target

    private void Start()
    {
        // Calculate the initial offset between camera and target
        offset = transform.position - targetObject.position;
    }

    private void LateUpdate()
    {
        // Update the camera's position based on the target's position and the offset
        transform.position = targetObject.position + offset;
    }
}