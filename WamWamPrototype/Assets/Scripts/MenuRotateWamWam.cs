using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuRotateWamWam : MonoBehaviour
{
    private int frames = 0;
    private float turnDegree = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        frames++;

        if (frames < 50)
        {
            transform.Rotate(0, turnDegree, 0, Space.World);
        }
        else if (frames > 50)
        {
            transform.Rotate(0, -turnDegree, 0, Space.World);
        }

        if (frames >= 100)
        {
            frames = 0;
        }
    }
}
