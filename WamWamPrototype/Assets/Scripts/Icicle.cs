using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Icicle : MonoBehaviour
{
    private AudioSource icicleBreak;

    void Start()
    {
        icicleBreak = GameObject.Find("IcicleBreak").GetComponent<AudioSource>();
    }

    private void OnDestroy()
    {
        if (icicleBreak != null)
        {
            icicleBreak.Play();
        }
    }
}
