using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gates1Script : MonoBehaviour
{
    private float swingPeriod = 3f;


    void Start()
    {

    }

    void Update()
    {
        float factor = Time.deltaTime / swingPeriod;
        if (!MazeState.checkPoint1Passed)
        {
            factor *= 00.3f;
        }

        /*
        // ������ 1 ������ - "�������": ���� ���� ���� ������ ��'���
        // �� ��� ����������� �������, � ��������� (�� �������� ���������)
        // �� ����� ��������� � ��� �������, �� ���� ���������� ����
        // ��������, �� � �����������. ������� - ������������ Update()
        // � ����� � Time.deltaTime
        this.transform.Translate(factor * Vector3.down);
        if (this.transform.position.y <-0.35f|| this.transform.position.y >0)
        {
            swingPeriod = -swingPeriod;
        }*/
        /*
        // ������ 2. �������, ��� ���� ������, �� ���������� �����������
        // ������� ���������� �� ���� (����������� Translate), � ����
        // ����������, �� ���� ���������� �� ����������� �����.
        this.transform.Translate(factor * Vector3.down);
        if (this.transform.position.y <-0.35f )
        {
            swingPeriod = -swingPeriod;
            this.transform.position = new Vector3(
                this.transform.position.x,
                -0.35f,
                this.transform.position.z
                );
        }
        if(this.transform.position.y > 0)
        {
            swingPeriod = -swingPeriod;
            this.transform.position = new Vector3(
                this.transform.position.x,
                0f,
                this.transform.position.z
                );
        }
        */
        // ������ 3 - ��������� ����������, ��������, ������������
        Vector3 newPosition = this.transform.position + factor * Vector3.down;
        if (newPosition.y <= -0.35f || newPosition.y >= 0f)
        {
            newPosition.y = newPosition.y <= -0.35f ? -0.35f : 0f;//Mathf.Clamp(newPosition.y, -0.35f, 0f);
            swingPeriod = -swingPeriod;
        }
        this.transform.position = newPosition;
    }
}
