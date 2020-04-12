using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMovement : MonoBehaviour
{
    public float moveSpeed = 1.1f;
    private int frames = 0;

    void Update()
    {
        frames++;

        if (frames < 100)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
        }
        else if (frames > 100)
        {
            transform.Translate(Vector3.back * Time.deltaTime * moveSpeed);
        }

        if (frames >= 200)
        {
            frames = 0;
        }
    }
}
