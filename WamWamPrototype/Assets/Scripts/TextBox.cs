using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextBox : MonoBehaviour
{
    private GameObject cam;
    private CameraMovement cameraMovement;
    public bool playerInRange = false;
    private Vector3 defaultPosition;
    private Quaternion defaultRotation;
    public bool savePosition = false;

    private void Start()
    {
        defaultPosition = transform.position;
        defaultRotation = transform.rotation;
        cam = GameObject.Find("Main Camera");
        cameraMovement = cam.GetComponent<CameraMovement>();
    }

    private void Update()
    {
        if (savePosition)
        {
            defaultPosition = transform.position;
            defaultRotation = transform.rotation;
            savePosition = false;
        }
    }

    private void LateUpdate()
    {
        if (playerInRange && cameraMovement.moveState == CameraMovement.MoveState.Reading)
        {
            transform.LookAt(transform.position + cam.transform.rotation * Vector3.forward, cam.transform.rotation * Vector3.up);
        }
        else
        {
            transform.position = defaultPosition;
            transform.rotation = defaultRotation;
        }
    }
}