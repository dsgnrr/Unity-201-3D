using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthScript : MonoBehaviour
{
    private GameObject surface;
    private GameObject atmosphere;
    private float dayPeriod = 24f / 360f;
    private float skyPeriod = 12f / 360f;

    void Start()
    {
        surface = GameObject.Find("EarthSurface");
        atmosphere = GameObject.Find("EarthAtmosphere");
    }

    void Update()
    {
        //transform.rotation
        surface.transform.Rotate(Vector3.up, Time.deltaTime / dayPeriod,Space.Self);
        atmosphere.transform.Rotate(Vector3.up, Time.deltaTime / skyPeriod);
    }
}
/* ������:
 * - (� ���) �� ��� �����(���������), ��� ������ ��� �� ������� ������
 * ������ ��� ������ � ����. Vector2 - ��� ����� (�,�), Vector3 - (x,y,z)
 * - (� ������) �� ������������� ������� ����� (��� ����� ��'����)
 * - (� �������)
 *  = ����������� ������ - �������������� ������� (���������, ���� �� ���������)
 *  = ����� � ������� � ������������ (x,y,z)
 */
