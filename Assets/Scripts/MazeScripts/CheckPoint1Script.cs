using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckPoint1Script : MonoBehaviour
{
    [SerializeField]
    private Image indicator;

    private float checkPoint1Timeout = 10f;
    
    void Start()
    {
        MazeState.checkPoint1Amount = 1f;
        MazeState.checkPoint1Passed = false;
    }

    void Update()
    {
        MazeState.checkPoint1Amount -= Time.deltaTime / checkPoint1Timeout;
        if (MazeState.checkPoint1Amount > 0f)
        {
            indicator.fillAmount = MazeState.checkPoint1Amount;
            indicator.color = new Color(
                1f-indicator.fillAmount,
                indicator.fillAmount,
                0.3f
             );
        }
        else
        {
            GameObject.Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("CheckPoint1Script: " + other.name);
        MazeState.checkPoint1Passed = true;
        GameObject.Destroy(this.gameObject);
    }
}
