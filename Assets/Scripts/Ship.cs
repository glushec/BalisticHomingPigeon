using System;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public float speed = 10f;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        // Make sure the object has a Rigidbody component attached
        if (rb == null)
        {
            Debug.LogError("Rigidbody component not found on the object!");
        }
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(speed * Time.fixedDeltaTime, 0f, 0f);
        rb.velocity = movement;
    }
    
}