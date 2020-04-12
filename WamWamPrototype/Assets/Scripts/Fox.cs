using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
{
    private Rigidbody foxRb;
    private Transform target;
    private Quaternion startRotation;
    public float chaseRadius;
    public float attackRadius;
    public float moveSpeed = 4.5f;
    private bool foxBarkHasPlayed = false;
    public AudioSource foxBark;
    private AudioSource foxYelp;

    void Start()
    {
        foxRb = GetComponent<Rigidbody>();
        startRotation = gameObject.transform.rotation;
        target = GameObject.FindWithTag("Player").transform;
        foxYelp = GameObject.Find("FoxYelp").GetComponent<AudioSource>();
    }

    void Update()
    {
        CheckDistance();
    }

    void CheckDistance()
    {
        if (Vector3.Distance(target.position, transform.position) <= chaseRadius)
        {
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
        }
        else
        {
            foxBarkHasPlayed = false;
            gameObject.transform.rotation = startRotation;
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
