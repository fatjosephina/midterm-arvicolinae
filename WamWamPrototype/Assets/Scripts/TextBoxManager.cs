using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextBoxManager : MonoBehaviour
{
    public GameObject[] textBoxes;
    private GameObject textBox;

    public TextBox FindClosestTextBox(Vector3 callerPos)
    {
        Transform tMin = null;
        float minDist = Mathf.Infinity;
        Vector3 currentPos = callerPos;
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
        return textBox.GetComponent<TextBox>();
    }
}
