using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PapaWam : MonoBehaviour
{
    public GameObject textBoxManager;
    private TextBoxManager managerScript;
    private TextBox textBoxScript;

    private void Start()
    {
        /*Transform tMin = null;
        float minDist = Mathf.Infinity;
        Vector3 currentPos = transform.position;
        foreach (GameObject t in textBoxes)
        {
            float dist = Vector3.Distance(t.transform.position, currentPos);
            if (dist < minDist)
            {
                tMin = t.transform;
                minDist = dist;
            }
        }
        textBox = tMin.gameObject;
        textBoxScript = textBox.GetComponent<TextBox>();*/
        managerScript = textBoxManager.GetComponent<TextBoxManager>();
        textBoxScript = managerScript.FindClosestTextBox(transform.position);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            textBoxScript.playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            textBoxScript.playerInRange = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("IcePlatform"))
        {
            textBoxScript.savePosition = true;
        }
    }
}
