using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gates2Script : MonoBehaviour
{
    private float period = 100f / 360f;
    void Start()
    {
        MazeState.AddPropertyListener(
            nameof(MazeState.checkPoint2Passed),
            OnCheckPoint2Changed);
    }

    void Update()
    {
        this.transform.Rotate(Vector3.up, Time.deltaTime / period);
    }
    private void OnCheckPoint2Changed() 
    {
        if (MazeState.checkPoint2Passed)
        {
            period /= 10f;
        }
    }
    private void OnDestroy()
    {
        MazeState.RemovePropertyListener(nameof(MazeState.checkPoint2Passed), 
            OnCheckPoint2Changed);
    }
}
