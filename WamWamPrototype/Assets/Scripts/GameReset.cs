using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameReset : MonoBehaviour
{
    private GameMaster gameMaster;
    private Vector3 startPos = new Vector3(182, 6, -147);

    void Start()
    {
        if (GameObject.FindGameObjectWithTag("GameMaster") != null)
        {
            gameMaster = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
            gameMaster.lastCheckpointPos = startPos;
            gameMaster.checkPointStr = "?";
        }
    }
}
