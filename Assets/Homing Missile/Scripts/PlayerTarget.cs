using System;
using UnityEngine;
using DG.Tweening;
using Random = UnityEngine.Random;

public class PlayerTarget : MonoBehaviour 
{
    public Rigidbody rb;
    public Camera mainCamera;
    [Header("TARGET PROPERTIES")]
    public float radius;
    public float duration;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();

    }
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
    
            if (Physics.Raycast(ray, out hit))
            {
                Vector3 targetPosition = new Vector3(hit.point.x, 0, hit.point.z);
                rb.MovePosition(targetPosition);
            }
        }
    }
    
    private void FixedUpdate()
    {
        //Vector3 movement = new Vector3(speed * Time.fixedDeltaTime, 0f, 0f);
        //rb.velocity = movement;
        Vector3 targetVelocity = new Vector3(Random.Range(-radius, radius), 0, Random.Range(-radius, radius));
        Sequence sequence = DOTween.Sequence();
        sequence.Append(DOTween.To(() => rb.velocity, v => rb.velocity = v, targetVelocity, duration));
    }
    //
    // private void Update()
    // {
    //     if (Input.GetMouseButtonDown(0))
    //     {
    //         Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
    //         RaycastHit hit;
    //
    //         if (Physics.Raycast(ray, out hit))
    //         {
    //             Vector3 targetPosition = new Vector3(hit.point.x, transform.position.y, hit.point.z);
    //             myTween.Kill();
    //             myTween = transform.DOMove(targetPosition, tweenSpeed).SetEase(Ease.OutQuad).OnComplete(OnTweenComplete);
    //             //Debug.Log("click");
    //             //myTween.Complete();
    //         }
    //     }
    // }
    //
    // private Vector3 GetRandomPoint()
    // {
    //     float angle = Random.Range(0f, Mathf.PI * 2); // Random angle in radians
    //
    //     float x = Mathf.Cos(angle) * radius; // get x position
    //     //float y = Mathf.Sin(angle) * radius; // get y position
    //     float z = Mathf.Sin(angle) * radius; // get z position
    //
    //     Vector3 randomPoint = transform.position + new Vector3(x, 0f, z);
    //     return randomPoint;
    // }
    //
    // private Tween StartTween()
    // {
    //     return transform.DOMove(GetRandomPoint(), speed).OnComplete(OnTweenComplete);
    // }
    //
    // private void OnTweenComplete()
    // {
    //     myTween = StartTween();
    // }
    
}