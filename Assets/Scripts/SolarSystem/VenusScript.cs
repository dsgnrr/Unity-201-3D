using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VenusScript : MonoBehaviour
{
    private GameObject surface;
    private GameObject atmosphere;

    private float dayPeriod = 24f / 360;
    private float skyPeriod = 12f / 360;

    void Start()
    {
        surface = GameObject.Find("VenusSurface");
        atmosphere = GameObject.Find("VenusAtmosphere");
    }

    void Update()
    {
        surface.transform.Rotate(Vector3.up, Time.deltaTime / dayPeriod, Space.Self);
        atmosphere.transform.Rotate(Vector3.up, Time.deltaTime / skyPeriod);
    }
}
