using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerGameOver : MonoBehaviour
{
    public Text text;

    void Update()
    {
        if (PlayerMovement.isGameOver)
        {
            if (!PlayerMovement.isGameWon)
            {
                text.text = "Game over! Press space to restart";
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
            }
        }

        if (PlayerMovement.isGameWon)
        {
            text.text = "Congratulations! You saved the day!\n Press space to continue";
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("CreditScene");
            }
        }
    }
}
