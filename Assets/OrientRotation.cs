using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrientRotation : MonoBehaviour
{
    public Transform targetObject; // The object to which rotation should be oriented
    public Options axis;
    [HideInInspector] public bool hasParent;
    [HideInInspector] public Quaternion parentTransform;
    

    void Update()
    {
        Vector3 lookDirection = targetObject.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(lookDirection, Vector3.up);


        parentTransform = transform.parent.rotation;

        switch (axis)
        {
            case Options.X:
                transform.rotation = Quaternion.Euler(targetRotation.eulerAngles.y + 180, transform.eulerAngles.y, transform.eulerAngles.z);
                break;

            case Options.Y:
                transform.rotation = Quaternion.Euler(transform.eulerAngles.x, targetRotation.eulerAngles.y + 180, transform.eulerAngles.z);
                break;

            case Options.XY:
                transform.rotation = Quaternion.Euler(targetRotation.eulerAngles.x + 180, targetRotation.eulerAngles.y + 180, transform.eulerAngles.z);
                break;
        }
    }


    // private void OnDrawGizmos() {
    //
    //     switch (axis)
    //     {
    //         case Options.X:
    //             Gizmos.color = Color.red;
    //             Gizmos.DrawLine(transform.position, targetObject.transform.position);
    //             break;
    //
    //         case Options.Y:
    //             Gizmos.color = Color.green;
    //             Gizmos.DrawLine(transform.position, targetObject.transform.position);
    //             break;
    //
    //         case Options.XY:
    //             Gizmos.color = Color.blue;
    //             Gizmos.DrawLine(transform.position, targetObject.transform.position);
    //             break;
    //     }
    //     
    // }
    
}

public enum Options
{
    X,
    Y,
    XY
}