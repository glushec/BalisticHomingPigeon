using UnityEngine;

public class ChildLookAtMissile : MonoBehaviour
{
    public Transform missile;
    public GameObject explosionPrefab;
    public GameObject instantiateAt;
    public float spawnInterval = 3f;
    
    private float timer = 0f;

    void Update()
    {
        transform.LookAt(missile);
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            Instantiate(explosionPrefab, instantiateAt.transform.position, Quaternion.identity);
            timer = 0f;
        }
    }
}