using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontalInput;
    private float forwardInput;
    public float moveSpeed = 5.0f;
    public float turnSpeed = 45.0f;
    public float slopeSpeed = 7.0f;
    public float knockSpeed = 250.0f;
    private bool isOnSlope = false;
    private bool isAirborne = false;
    private bool isOnPlatform = false;
    private bool hasIcepop = false;
    private bool hit = false;
    private float damage = 1.0f;
    private Rigidbody rb;
    private Animator PlayerAnimator;
    public static bool isGameOver = false;
    public static bool isGameWon = false;

    public GameObject snowball;
    public PhysicMaterial slipperyMaterial;
    public PhysicMaterial normalMaterial;
    public AudioSource waterSplash;
    public AudioSource slide;
    public AudioSource airWhoosh;
    public AudioSource bounce;
    public AudioSource yeehaw;
    public FloatValue currentHealth;
    public Signal playerHealthSignal;

    // Start is called before the first frame update
    void Start()
    {
        isGameOver = false;
        isGameWon = false;
        rb = GetComponent<Rigidbody>();
        PlayerAnimator = GetComponent<Animator>();
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
            if (!slide.isPlaying && !isAirborne)
            {
                slide.Play();
            }
            GetComponent<SphereCollider>().material = slipperyMaterial;
            horizontalInput = Input.GetAxis("Horizontal");
            rb.AddRelativeForce(Vector3.forward * Time.deltaTime * slopeSpeed, ForceMode.Impulse);
            // transform.Translate(Vector3.forward * Time.deltaTime * slopeSpeed);
            transform.Translate(Vector3.right * Time.deltaTime * moveSpeed * horizontalInput);
        }

        if (!isAirborne && isOnPlatform && hasIcepop)
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                Instantiate(snowball, transform.position + transform.forward, transform.rotation);

            }
        }

        if (hit == true)
        {
            currentHealth.runtimeValue -= damage;
            playerHealthSignal.Raise();
            if (currentHealth.runtimeValue > 0)
            {
                rb.velocity = Vector3.zero;
                rb.AddRelativeForce(Vector3.up * Time.deltaTime * knockSpeed, ForceMode.Impulse);
                rb.AddRelativeForce(Vector3.back * Time.deltaTime * knockSpeed, ForceMode.Impulse);
            }
            else 
            {
                isGameOver = true;
            }
                hit = false;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            PlayerAnimator.SetBool("forwardArrowPressed", false);
            PlayerAnimator.SetBool("backArrowPressed", true);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            PlayerAnimator.SetBool("backArrowPressed", false);
            PlayerAnimator.SetBool("forwardArrowPressed", true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        isAirborne = false;
        if (!collision.gameObject.CompareTag("Slope"))
        {
            isOnSlope = false;
        }
        else
        {
            isOnSlope = true;
        }

        if (collision.gameObject.CompareTag("IcePlatform"))
        {
            isOnPlatform = true;
        }
        else
        {
            isOnPlatform = false;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Slope"))
        {
            isAirborne = true;
            airWhoosh.Play();
            yeehaw.Play();
        }
        else if (collision.gameObject.CompareTag("Seal"))
        {
            bounce.Play();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("EternalIce"))
        {
            isGameWon = true;
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Icicle"))
        {
            hit = true;
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Fox"))
        {
            hit = true;
        }
        else if (other.gameObject.CompareTag("Water"))
        {
            currentHealth.runtimeValue = 0;
            playerHealthSignal.Raise();
            isGameOver = true;
            waterSplash.Play();
        }
        else if (other.gameObject.CompareTag("Icepop"))
        {
            hasIcepop = true;
            Destroy(other.gameObject);
        }
        else
        {
            Debug.Log("Trigger enter");
        }
    }
}
