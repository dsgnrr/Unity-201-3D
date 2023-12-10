using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckPoint2Script : MonoBehaviour
{
    [SerializeField]
    private Image indicator;

    private float checkPoint2Timeout = 10f;

    void Start()
    {
        MazeState.checkPoint2Amount = 1f;
        MazeState.checkPoint2Passed = false;
    }

    void Update()
    {
        if (MazeState.checkPoint2Active)
        {
            MazeState.checkPoint2Amount -= Time.deltaTime / checkPoint2Timeout;
            if (MazeState.checkPoint2Amount > 0f)
            {
                indicator.fillAmount = MazeState.checkPoint2Amount;
                indicator.color = new Color(
                    1f - indicator.fillAmount,
                    indicator.fillAmount,
                    0.3f
                 );
            }
            else
            {
                GameObject.Destroy(this.gameObject);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("CheckPoint1Script: " + other.name);
        MazeState.checkPoint2Passed = true;
        GameObject.Destroy(this.gameObject);
    }
}
