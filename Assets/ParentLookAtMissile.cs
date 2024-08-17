using UnityEngine;

public class ParentLookAtMissile : MonoBehaviour
{
    public Transform missile;

    void Update()
    {
        Vector3 targetPosition = new Vector3(missile.position.x, transform.position.y, missile.position.z);
        transform.LookAt(targetPosition);
    }
}