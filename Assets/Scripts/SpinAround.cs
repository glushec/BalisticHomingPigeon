using UnityEngine;

public class SpinAround : MonoBehaviour
{
    public float rotationSpeed = 100f;

    void Update()
    {
        // Rotate the object around its local Z-axis
        transform.Rotate(0f , 0f, rotationSpeed * Time.deltaTime);
    }
}