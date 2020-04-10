using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snowball : MonoBehaviour
{
    private Rigidbody snowballRb;
    private float moveSpeed = 10.0f;
    private Vector3 direction = new Vector3(0, 0.5f, 1.0f);

    // Start is called before the first frame update
    void Start()
    {
        snowballRb = GetComponent<Rigidbody>();
        // rb.AddRelativeForce(Vector3.forward * Time.deltaTime * moveSpeed);
        snowballRb.AddRelativeForce(direction * moveSpeed, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {

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

}
