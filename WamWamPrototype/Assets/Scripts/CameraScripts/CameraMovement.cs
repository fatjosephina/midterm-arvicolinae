using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    public Vector3 offsetPosition;
    [SerializeField]
    private Space offsetPositionSpace = Space.Self;
    [SerializeField]
    private bool lookAt = true;

    private void LateUpdate()
    {
        Refresh();
    }

    public void Refresh()
    {
        if (!PlayerMovement.isGameOver)
        {
            if (offsetPositionSpace == Space.Self)
            {
                transform.position = target.TransformPoint(offsetPosition);
            }
            else
            {
                transform.position = target.position + offsetPosition;
            }

            if (lookAt)
            {
                transform.LookAt(target);
            }
            else
            {
                transform.rotation = target.rotation;
            }
        }
    }
}
