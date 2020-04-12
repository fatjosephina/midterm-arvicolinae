using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnRamp : MonoBehaviour
{
    private float turnSpeed = 90.0f;
    public float turnAngle = 90.0f;
    private bool isTriggerEntered = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            collision.gameObject.transform.Rotate(0, -90, 0);
            collision.gameObject.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * Time.deltaTime * turnSpeed, ForceMode.Impulse);
        }
    }*/

    private void OnTriggerEnter(Collider other)
    {
        if (!isTriggerEntered)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                other.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
                other.gameObject.transform.Rotate(0, turnAngle, 0);
                other.gameObject.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * Time.deltaTime * turnSpeed, ForceMode.Impulse);
                isTriggerEntered = true;
            }
        }
    }
}
