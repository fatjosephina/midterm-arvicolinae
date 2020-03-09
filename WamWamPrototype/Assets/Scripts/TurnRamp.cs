using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnRamp : MonoBehaviour
{
    private float turnSpeed = 90.0f;
    private float turnAngle = 1;
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
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            collision.gameObject.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * Time.deltaTime * turnSpeed, ForceMode.Impulse);
            collision.gameObject.transform.Rotate(0, -90, 0);
        }
    }
}
