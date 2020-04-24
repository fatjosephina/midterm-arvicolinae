using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator PlayerAnimator;

    // Start is called before the first frame update
    void Start()
    {
        PlayerAnimator = GetComponent<Animator>();
        PlayerAnimator.SetBool("isGameWon", false);
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            PlayerAnimator.SetBool("forwardArrowPressed", false);
            PlayerAnimator.SetBool("backArrowPressed", true);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            PlayerAnimator.SetBool("backArrowPressed", false);
            PlayerAnimator.SetBool("forwardArrowPressed", true);
        }*/

        if (PlayerMovement.isGameWon)
        {
            PlayerAnimator.SetBool("isGameWon", true);
        }
    }
}
