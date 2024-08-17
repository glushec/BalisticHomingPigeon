using UnityEngine;

public class SphereGizmo : MonoBehaviour
{
    public Color gizmoColor = new Color(1, 1, 1, 0.7f);

    private void OnDrawGizmos()
    {
        Gizmos.color = gizmoColor;
        Gizmos.DrawSphere(transform.position, 1f);
    }
}