using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FobosScript : MonoBehaviour
{
    [SerializeField]
    private GameObject mars;
    [SerializeField]
    private GameObject sun;

    private float dayPeriod = 12f / 360f;
    private float monthPeriod = 12f / 360f;
    private float yearPeriod = 73f / 360f;

    void Start()
    {

    }

    void Update()
    {
        this.transform.Rotate(Vector3.up, Time.deltaTime / dayPeriod);

        this.transform.RotateAround(mars.transform.position,
            Vector3.up, Time.deltaTime / monthPeriod);

        this.transform.RotateAround(sun.transform.position,
            Vector3.up, Time.deltaTime / yearPeriod);
    }
}
