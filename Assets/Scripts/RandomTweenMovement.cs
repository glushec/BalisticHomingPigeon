using System;
using UnityEngine;
using DG.Tweening;
using Random = UnityEngine.Random;

public class RandomTweenMovement : MonoBehaviour
{
    public Camera mainCamera;
    public float randomMoveDuration = 0.5f;
    public float radius = 5f;
    public float clickMoveDuration = 0.5f;
    private Tween myTween;
    
    private void Start()
    {
        myTween = StartTween();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                //Vector3 targetPosition = new Vector3(hit.point.x, transform.position.y, hit.point.z);
                //myTween.Kill();
                //myTween = transform.DOMove(targetPosition, clickMoveDuration).SetEase(Ease.OutQuad).OnComplete(OnTweenComplete);
                //myTween.Complete();
            }
        }
    }

    private Vector3 PickRandomPoint()
    {
        Vector2 randomCirclePoint = Random.insideUnitCircle * radius;
        Vector3 targetPosition = new Vector3(randomCirclePoint.x, transform.position.y, randomCirclePoint.y);

        return targetPosition;
    }
    
    private Vector3 GetRandomPoint()
    {
        float angle = Random.Range(0f, Mathf.PI * 2); // Random angle in radians

        float x = Mathf.Cos(angle) * radius; // get x position
        float z = Mathf.Sin(angle) * radius; // get z position

        Vector3 randomPoint = transform.position + new Vector3(x, 0f, z);
        return randomPoint;
    }
    
    private Tween StartTween()
    {
        return transform.DOMove(GetRandomPoint(), randomMoveDuration).OnComplete(OnTweenComplete);
    }

    private void OnTweenComplete()
    {
        myTween = StartTween();
    }
}