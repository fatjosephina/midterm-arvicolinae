using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private float horizontalInput;
    private float forwardInput;
    public float moveSpeed = 5.0f;
    public float turnSpeed = 45.0f;
    public float slopeSpeed = 7.0f;
    public float knockSpeed = 100.0f;
    private bool isOnSlope = false;
    private bool hit = false;
    private Rigidbody rb;

    public PhysicMaterial slipperyMaterial;
    public PhysicMaterial normalMaterial;
    public Text text;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isOnSlope == false)
        {
            GetComponent<SphereCollider>().material = normalMaterial;
            horizontalInput = Input.GetAxis("Horizontal");
            forwardInput = Input.GetAxis("Vertical");
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed * forwardInput);
            transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);
        }
        else
        {
            GetComponent<SphereCollider>().material = slipperyMaterial;
            horizontalInput = Input.GetAxis("Horizontal");
            rb.AddRelativeForce(Vector3.forward * Time.deltaTime * slopeSpeed, ForceMode.Impulse);
            // transform.Translate(Vector3.forward * Time.deltaTime * slopeSpeed);
            transform.Translate(Vector3.right * Time.deltaTime * moveSpeed * horizontalInput);
        }

        if (hit == true)
        {
            rb.velocity = Vector3.zero;
            rb.AddRelativeForce(Vector3.up * Time.deltaTime * knockSpeed, ForceMode.Impulse);
            rb.AddRelativeForce(Vector3.back * Time.deltaTime * knockSpeed, ForceMode.Impulse);
            hit = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Slope"))
        {
            isOnSlope = false;
        }
        else
        {
            isOnSlope = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("EternalIce"))
        {
            text.text = "Congratulations! You win!";
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Icicle"))
        {
            hit = true;
            Destroy(other.gameObject);
        }
        else
        {
            Debug.Log("Trigger enter");
        }
    }
}
