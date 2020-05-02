using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDialogue : MonoBehaviour
{
    public GameObject playerHint;
    public CameraMovement cameraMovement;

    private void Update()
    {
        cameraMovement = GameObject.Find("Main Camera").GetComponent<CameraMovement>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PapaWam"))
        {
            playerHint.SetActive(true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("PapaWam"))
        {
            if (playerHint.activeInHierarchy && cameraMovement.moveState == CameraMovement.MoveState.Reading)
            {
                playerHint.SetActive(false);
            }
            else if (!playerHint.activeInHierarchy && cameraMovement.moveState != CameraMovement.MoveState.Reading)
            {
                playerHint.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("PapaWam"))
        {
            playerHint.SetActive(false);
        }
    }
}
