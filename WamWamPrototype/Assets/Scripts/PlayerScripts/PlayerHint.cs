using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHint : MonoBehaviour
{
    public GameObject cam;
    public GameObject player;

    private Vector3 offset = new Vector3(-1, 0.5f, 2);
    private float speed = 5f;

    void Start()
    {
        
    }

    void Update()
    {
        Vector3 totalOffset = cam.transform.TransformPoint(offset);
        transform.position = Vector3.Lerp(transform.position, totalOffset, Time.deltaTime * speed);
    }

    void LateUpdate()
    {
        transform.LookAt(transform.position + cam.transform.rotation * Vector3.forward, cam.transform.rotation * Vector3.up);
    }
}
