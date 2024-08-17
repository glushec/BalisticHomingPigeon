using System;
using UnityEngine;

public class EnemyMissileStart : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(0f, 0f, speed * Time.fixedDeltaTime);
        rb.velocity = movement;
    }
    
}