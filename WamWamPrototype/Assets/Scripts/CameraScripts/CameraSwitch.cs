using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public Camera mainCamera;
    public Camera secondaryCamera;
    public GameObject player;
    private CameraMovement cameraMovement;
    private PlayerMovement playerMovement;
    private bool condition;
 
    private void Start()
    {
        mainCamera.enabled = true;
        secondaryCamera.enabled = false;
        cameraMovement = mainCamera.GetComponent<CameraMovement>();
        playerMovement = player.GetComponent<PlayerMovement>();

    }

    private void Update()
    {
        if (cameraMovement.moveState == CameraMovement.MoveState.MidCameraRotation)
        {
            mainCamera.transform.LookAt(Vector3.forward, Vector3.up);
            mainCamera.enabled = false;
            secondaryCamera.enabled = true;
            Vector3 vector = new Vector3(0, 10, 0);
            secondaryCamera.transform.position = player.transform.position + player.transform.TransformDirection(vector);
            secondaryCamera.transform.LookAt(player.transform);
        }

        if (!playerMovement.isBouncing)
        {
            secondaryCamera.enabled = false;
            mainCamera.enabled = true;
        }
    }
}
