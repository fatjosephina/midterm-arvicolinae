using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMovement : MonoBehaviour
{
    public float moveSpeed = 1.1f;
    private bool isMovingForward;
    private int frames = 0;

    // Start is called before the first frame update
    void Start()
    {
        isMovingForward = true;
    }

    // Update is called once per frame
    void Update()
    {
        frames++;

        if (frames < 100)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
            isMovingForward = false;
        }
        else if (frames > 100)
        {
            transform.Translate(Vector3.back * Time.deltaTime * moveSpeed);
            isMovingForward = true;
        }

        /*if (frames < 50 || frames > 150)
        {
            transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
        }
        else if (frames > 50 && frames < 150)
        {
            transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);
        }*/

        if (frames >= 200)
        {
            frames = 0;
        }
    }
}
