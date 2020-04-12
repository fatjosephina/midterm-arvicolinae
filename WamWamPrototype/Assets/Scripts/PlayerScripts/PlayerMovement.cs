using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontalInput;
    private float forwardInput;
    public float moveSpeed = 5.0f;
    public float turnSpeed = 45.0f;
    public float slopeSpeed = 10.0f;
    public float knockSpeed = 250.0f;
    private float angularDrag = 9999.0f;
    private bool isOnSlope = false;
    private bool isAirborne = false;
    private bool isOnPlatform = false;
    public static bool hasIcepop = false;
    private bool hit = false;
    private readonly float damage = 1.0f;
    private Rigidbody rb;
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
    public AudioSource hurt;
    public AudioSource snowballThrow;
    public AudioSource winSound;
    public FloatValue currentHealth;
    public Signal playerHealthSignal;

    void Start()
    {
        isGameOver = false;
        isGameWon = false;
        hasIcepop = false;
        rb = GetComponent<Rigidbody>();
        rb.angularDrag = angularDrag;
    }

    private void Update()
    {
        if (!isOnSlope)
        {
            horizontalInput = Input.GetAxis("Horizontal");
            forwardInput = Input.GetAxis("Vertical");
        }
        else
        {
            horizontalInput = Input.GetAxis("Horizontal");
        }
        if (!isGameWon && !isGameOver)
        {
            MovePlayer();

            CheckForPowerup();

            CheckIfHit();
        }
    }

    private void MovePlayer()
    {
        if (!isOnSlope)
        {
            GetComponent<SphereCollider>().material = normalMaterial;
            Vector3 forwardMovement = Vector3.forward * Time.deltaTime * moveSpeed * forwardInput;
            transform.Translate(forwardMovement);
            transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);
        }
        else
        {
            if (!slide.isPlaying && !isAirborne)
            {
                slide.Play();
            }
            GetComponent<SphereCollider>().material = slipperyMaterial;
            rb.AddRelativeForce(Vector3.forward * Time.deltaTime * slopeSpeed, ForceMode.Impulse);
            Vector3 horizontalMovement = Vector3.right * Time.deltaTime * moveSpeed * horizontalInput;
            transform.Translate(horizontalMovement);
        }
    }

    private void CheckForPowerup()
    {
        if (!isAirborne && isOnPlatform && hasIcepop)
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                Instantiate(snowball, transform.position + transform.forward, transform.rotation);
                snowballThrow.Play();
            }
        }
    }

    private void CheckIfHit()
    {
        if (hit == true)
        {
            currentHealth.runtimeValue -= damage;
            playerHealthSignal.Raise();
            hurt.Play();
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
            rb.velocity = Vector3.zero;
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
            winSound.Play();
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
    }
}
