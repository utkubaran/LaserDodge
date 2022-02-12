using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelProgressTracker : MonoBehaviour
{
    private Transform finishLine, playerPos;

    private float distanceToFinish;

    private bool isFinished;

    void Start()
    {
        finishLine = GameObject.FindGameObjectWithTag("Finish Line").transform;
        playerPos = GameObject.FindGameObjectWithTag("Boy").transform;
        isFinished = false;
    }

    private void Update()
    {
        CheckDistance();
    }

    // Checks player's distance to the finish line
    private void CheckDistance()
    {
        distanceToFinish = finishLine.position.z - playerPos.position.z;

        if ((int)distanceToFinish <= 0 && !isFinished)
        {
            isFinished = true;
            distanceToFinish = 0;
            EventManager.OnLevelFinish?.Invoke();
        }
    }
}
