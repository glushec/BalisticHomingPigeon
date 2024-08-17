using UnityEngine;
using DG.Tweening;

public class HomingMissileTarget : MonoBehaviour 
{
    public Rigidbody rb;
    public float speed;
    private Tween myTween;
    public float radius;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        myTween = StartTween();
    }

    void Update() 
    {
        //var dir = new Vector3(Mathf.Cos(Time.time * speed) * size, Mathf.Sin(Time.time * speed) * size);
        //rb.velocity = dir;
        //Debug.Log(rb.velocity);
    }
    
    private Vector3 GetRandomPoint()
    {
        float angle = Random.Range(0f, Mathf.PI * 2); // Random angle in radians

        float x = Mathf.Cos(angle) * radius; // get x position
        float y = Mathf.Sin(angle) * radius; // get y position
        float z = Mathf.Sin(angle) * radius; // get z position

        Vector3 randomPoint = transform.position + new Vector3(x, y, z);
        return randomPoint;
    }
    
    private Tween StartTween()
    {
        return transform.DOMove(GetRandomPoint(), speed).OnComplete(OnTweenComplete);
    }
    
    private void OnTweenComplete()
    {
        myTween = StartTween();
    }
    
}