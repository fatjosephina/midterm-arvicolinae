using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public string checkPointStr;
    public AudioSource papaWam;
    public AudioSource getCheckpoint;
    public Vector3 offsetPosition;
    private GameMaster gameMaster;
    private Transform fingers;

    private void Start()
    {
        gameMaster = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameMaster.lastCheckpointPos = transform.position + offsetPosition;
            Transform flag = transform.Find("Flag");
            if (!flag.gameObject.activeInHierarchy)
            {
                flag.gameObject.SetActive(true);
                if (gameMaster.checkPointStr != checkPointStr)
                {
                    papaWam.Play();
                    getCheckpoint.Play();
                    fingers = transform.Find("Fingers");
                    fingers.gameObject.SetActive(true);
                    StartCoroutine(TurnCo());
                    gameMaster.checkPointStr = checkPointStr;
                }
            }
        }
    }

    IEnumerator TurnCo()
    {
        transform.Rotate(0, -45, 0);
        yield return new WaitForSeconds(2.5f);
        transform.Rotate(0, 45, 0);
        fingers.gameObject.SetActive(false);
    }
}
