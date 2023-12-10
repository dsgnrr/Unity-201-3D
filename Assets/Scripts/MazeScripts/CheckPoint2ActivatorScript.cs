using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint2ActivatorScript : MonoBehaviour
{
    void Start()
    {
        MazeState.checkPoint2Active = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        MazeState.checkPoint2Active = true;
        MazeState.gameLevel += 1;
        GameObject.Destroy(this.gameObject);
    }
}
