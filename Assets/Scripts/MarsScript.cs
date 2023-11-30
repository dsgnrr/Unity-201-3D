using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MarsScript : MonoBehaviour
{
    [SerializeField]
    private GameObject sun;
    private GameObject surface;

    private float dayPeriod = 24f / 360f;
    private float yearPeriod = 73f / 360f;


    void Start() 
    {
        surface = GameObject.Find("MarsSurface");
    }

    void Update()
    {
        //transform.rotation
        surface.transform.Rotate(Vector3.up, Time.deltaTime / dayPeriod, Space.Self);
        this.transform.RotateAround(sun.transform.position, Vector3.up, Time.deltaTime / yearPeriod);
    }
}
