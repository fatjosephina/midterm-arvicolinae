using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Icicle : MonoBehaviour
{
    private AudioSource icicleBreak;

    // Start is called before the first frame update
    void Start()
    {
        icicleBreak = GameObject.Find("IcicleBreak").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        if (icicleBreak != null)
        {
            icicleBreak.Play();
        }
    }
}
