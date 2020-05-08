using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDialogue : MonoBehaviour
{
    public AudioSource papaWam;
    private bool papaWamPlayed = false;
    public GameObject playerHint;
    public GameObject spacePrompt;
    private CameraMovement cameraMovement;
    public Material[] dialogueTexts;
    private GameObject textBoxText;
    private Renderer textRenderer;
    private int textIndex;

    private void Start()
    {
        textBoxText = GameObject.Find("TextBoxText");
        textRenderer = textBoxText.GetComponent<MeshRenderer>();
        textIndex = 0;
    }

    private void Update()
    {
        cameraMovement = GameObject.Find("Main Camera").GetComponent<CameraMovement>();
        if (cameraMovement.moveState == CameraMovement.MoveState.Reading)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (textIndex < dialogueTexts.Length - 1)
                {
                    textIndex++;
                }
                textRenderer.material = dialogueTexts[textIndex];
                if (textIndex == dialogueTexts.Length - 1 && spacePrompt.activeInHierarchy)
                {
                    spacePrompt.SetActive(false);
                }
            }
        }
        else
        {
            if (textIndex != 0)
            {
                textIndex = 0;
                textRenderer.material = dialogueTexts[textIndex];
            }
            if (!spacePrompt.activeInHierarchy)
            {
                spacePrompt.SetActive(true);
            }
        }
        Debug.Log(textIndex);
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
                if (!papaWamPlayed)
                {
                    papaWam.Play();
                    papaWamPlayed = true;
                }
            }
            else if (!playerHint.activeInHierarchy && cameraMovement.moveState != CameraMovement.MoveState.Reading)
            {
                playerHint.SetActive(true);
                if (papaWamPlayed)
                {
                    papaWamPlayed = false;
                }
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
