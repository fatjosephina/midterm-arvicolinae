﻿using System.Collections;
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
    private float yRotation = 0f;

    public PlayerMovement playerMovement;

    private Vector3 saveOffsetPosition;
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

    private MoveState moveState = MoveState.Initial;
    enum MoveState { Initial, MoveCameraRotation, StopCameraRotation, NONE, NEXT }

    private void Start()
    {
        savedRotation = transform.rotation;
        saveOffsetPosition = offsetPosition;
        playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }
    private void LateUpdate()
    {
        Debug.Log(playerMovement.isOnPlatform);
        if (!gameStarted)
        {
            if (Input.anyKey)
            {
                gameStarted = true;
            }
        }
        Refresh();
    }

    bool DistanceBetweenPlayerCam()
    {
        bool xBool = false;
        bool yBool = false;
        bool zBool = false;

        float xFloat = transform.position.x - playerMovement.gameObject.transform.position.x;
        if (xFloat <= 2.5 && xFloat >= -2.5)
        {
            xBool = true;
        }
        float yFloat = transform.position.y - playerMovement.gameObject.transform.position.y;
        if (yFloat <= 1.5 && yFloat >= -1.5)
        {
            yBool = true;
        }
        float zFloat = transform.position.z - playerMovement.gameObject.transform.position.z;
        if (zFloat <= 2.5 && zFloat >= -2.5)
        {
            zBool = true;
        }
        if (xBool && yBool && zBool)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    bool TargetSideRotation()
    {
        //float yTarget = target.transform.eulerAngles.y;
        float yTarget = target.transform.rotation.eulerAngles.y;
        yTarget = Mathf.Round(yTarget / 45) * 45;
        Debug.Log(yTarget);
        if (yTarget != 0 && yTarget != 90 && yTarget != 180 && yTarget != 270)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // NEED TO KEEP CAMERA FOCUSED ON PLAYER WHEN BOUNCING ON SEAL

    public void Refresh()
    {
        if (!PlayerMovement.isGameOver)
        {
            if (Input.GetKey(KeyCode.Z))
            {
                moveState = MoveState.MoveCameraRotation;
                zPressed = true;
            }
            else
            {
                if (playerMovement.isOnSlope)
                {
                    moveState = MoveState.MoveCameraRotation;
                }
                else
                {
                    if (moveState == MoveState.MoveCameraRotation)
                    {
                        moveState = MoveState.StopCameraRotation;
                        zPressed = false;
                    }
                }
            }

            if (transform.position.y == yStartPosition && moveState != MoveState.MoveCameraRotation)
            {
                moveState = MoveState.StopCameraRotation;
            }

            if (!DistanceBetweenPlayerCam() && playerMovement.isOnPlatform && !TargetSideRotation() && gameStarted)
            {
                moveState = MoveState.MoveCameraRotation;
            }
            Debug.Log(moveState);
            Debug.Log(playerMovement.isOnPlatform);

            switch (moveState)
            {
                case MoveState.Initial:
                    transform.position = target.position + offsetPosition;
                    break;
                case MoveState.MoveCameraRotation:
                    offsetPosition = saveOffsetPosition;
                    /*if (offsetPositionSpace == Space.Self)
                    {*/
                        transform.position = target.TransformPoint(offsetPosition);
                    //}
                    transform.LookAt(target);
                    break;
                case MoveState.StopCameraRotation:
                    transform.position += playerMovement.translateChange;
                    break;
            }
        }
    }
}
