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
    private bool gameStarted = false;
    private float yStartPosition = 6.5f;
    private bool zPressed = false;
    private Vector3 savedPosition;
    private Quaternion savedRotation;
    public GameObject playerCam;
    float offsetY = 1;
    float offsetZFaceForward = -2;
    float offsetZFaceBack = 2;
    float offsetZFaceLeftRight = 0;
    float offsetZForwardRight = -1.5f;
    float offsetZForwardLeft = -1.5f;
    float offsetZBackRight = 1.5f;
    float offsetZBackLeft = 1.5f;
    float offsetXFaceBackForward = 0;
    float offsetXFaceRight = -2;
    float offsetXFaceLeft = 2;
    float offsetXForwardRight = -1.5f;
    float offsetXForwardLeft = 1.5f;
    float offsetXBackRight = -1.5f;
    float offsetXBackLeft = 1.5f;


    private void Start()
    {
        savedRotation = transform.rotation;
    }
    private void LateUpdate()
    {
        Refresh();
    }

    public void Refresh()
    {
        if (!PlayerMovement.isGameOver)
        {
            /*if (offsetPositionSpace == Space.Self)
            {
                transform.position = target.TransformPoint(offsetPosition);
            }
            else
            {*/
            //}
            if (Input.GetKey(KeyCode.Z))
            {
                zPressed = true;
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
                savedPosition = transform.position;
                savedRotation = transform.rotation;
            }
            else
            { 
                if (!zPressed)
                {
                    transform.position = target.position + offsetPosition;
                    savedPosition = transform.position;
                    if (transform.position.y == yStartPosition)
                    {
                        gameStarted = true;
                    }
                }
                else
                {
                    //transform.position = savedPosition;
                    //transform.position = playerCam.transform.position;
                    //float zPos = target.position.z - 2;
                    //float yPos = target.position.y + 1;
                    //float xPos = target.position.x;
                    //transform.position = new Vector3(xPos, yPos, zPos);
                    transform.position = target.position + offsetPosition;
                    //transform.position = target.TransformPoint(offsetPosition);
                    //Vector3 vector = target.TransformPoint(offsetPosition);
                    //transform.position = new Vector3(target.position.x, target.position.y + vector.y, target.position.z + vector.z);
                }
                transform.rotation = savedRotation;
                //transform.LookAt(target);
            }
        }
    }
}
