using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snowball : MonoBehaviour
{
    private Rigidbody snowballRb;
    private float moveSpeed = 10.0f;
    private Vector3 direction = new Vector3(0, 0.5f, 1.0f);
    private AudioSource snowballSplat;

    void Start()
    {
        snowballRb = GetComponent<Rigidbody>();
        snowballRb.AddRelativeForce(direction * moveSpeed, ForceMode.Impulse);
        snowballSplat = GameObject.Find("SnowballSplat").GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
        if (collision.gameObject.CompareTag("Fox"))
        {
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Icicle"))
        {
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (other.gameObject.CompareTag("Fox"))
        {
            Destroy(other.transform.parent.gameObject);
        }
        else if (other.gameObject.CompareTag("Icicle"))
        {
            Destroy(other.gameObject);
        }
    }

    private void OnDestroy()
    {
        if (snowballSplat != null)
        {
            snowballSplat.Play();
        }
    }
}
