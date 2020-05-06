using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpacePrompt : MonoBehaviour
{
    private CameraMovement cameraMovement;
    private float moveSpeed = 0.05f;
    private int frames = 0;
    private Vector3 startPosition = Vector3.zero;

    private void Start()
    {
        cameraMovement = GameObject.Find("Main Camera").GetComponent<CameraMovement>();

    }

    private void Update()
    {
        if (GetComponentInParent<TextBox>().savePosition)
        {
            startPosition = transform.localPosition;
        }
        if (cameraMovement.moveState == CameraMovement.MoveState.Reading)
        {
            frames++;

            if (frames < 25)
            {
                transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
            }
            else if (frames > 25)
            {
                transform.Translate(Vector3.back * Time.deltaTime * moveSpeed);
            }

            if (frames >= 50)
            {
                frames = 0;
            }
        }
        else
        {
            if ((startPosition != Vector3.zero) && (transform.position != startPosition))
            {
                transform.localPosition = startPosition;
            }
        }
    }
}
