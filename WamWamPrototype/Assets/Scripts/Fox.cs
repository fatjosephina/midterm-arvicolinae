﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
{
    private Rigidbody foxRb;
    private Transform target;
    public float chaseRadius;
    public float attackRadius;
    public float moveSpeed = 4.5f;
    private bool foxBarkHasPlayed = false;
    public AudioSource foxBark;
    private AudioSource foxYelp;

    // Start is called before the first frame update
    void Start()
    {
        foxRb = GetComponent<Rigidbody>();
        target = GameObject.FindWithTag("Player").transform;
        foxYelp = GameObject.Find("FoxYelp").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckDistance();
    }

    void CheckDistance()
    {
        if (Vector3.Distance(target.position, transform.position) <= chaseRadius)
        {
            // Vector3 lookDirection = (transform.position - target.transform.position).normalized;
            if (Vector3.Distance(target.position, transform.position) > attackRadius)
            {
                transform.LookAt(target);
                if (!foxBarkHasPlayed)
                {
                    foxBark.Play();
                    foxBarkHasPlayed = true;
                }
            }
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, moveSpeed * Time.deltaTime);
            // transform.position += transform.forward * moveSpeed * Time.deltaTime;
            // foxRb.AddForce(lookDirection * moveSpeed * Time.deltaTime, ForceMode.Impulse);
        }
        else
        {
            foxBarkHasPlayed = false;
        }
    }

    private void OnDestroy()
    {
        if (foxYelp != null)
        {
            foxYelp.Play();
        }
    }
}
