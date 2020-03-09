using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SealBounce : MonoBehaviour
{
    public float upBounceSpeed = 15.0f;
    public float forwardBounceSpeed = 8.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        collision.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * upBounceSpeed, ForceMode.Impulse);
        // collision.gameObject.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * forwardBounceSpeed, ForceMode.Impulse);

    }
}
