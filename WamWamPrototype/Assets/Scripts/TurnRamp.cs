using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnRamp : MonoBehaviour
{
    private float turnSpeed = 90.0f;
    public float turnAngle = 90.0f;
    private bool isTriggerEntered = false;

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
