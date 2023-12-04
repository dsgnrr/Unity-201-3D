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
        // варіант 1 Недолік - "заскоки": якщо один крок виведе об'єкт
        // за межі допустимого діпазону, а наступний (із змененим напрямком)
        // не зможе повернути у цей діапазон, то знов відбудеться зміна
        // напрямку, що є неправильно. Причина - нерівномірність Update()
        // а відтак і Time.deltaTime
        this.transform.Translate(factor * Vector3.down);
        if (this.transform.position.y <-0.35f|| this.transform.position.y >0)
        {
            swingPeriod = -swingPeriod;
        }*/
        /*
        // варіант 2. Робочий, але його недолік, що потенційна неправильна
        // позиція реалізується на сцені (викликається Translate), а потім
        // корегується, що знов призводить до перерахунку сцени.
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
        // варіант 3 - попередній розрахунок, корекція, застосування
        Vector3 newPosition = this.transform.position + factor * Vector3.down;
        if (newPosition.y <= -0.35f || newPosition.y >= 0f)
        {
            newPosition.y = newPosition.y <= -0.35f ? -0.35f : 0f;//Mathf.Clamp(newPosition.y, -0.35f, 0f);
            swingPeriod = -swingPeriod;
        }
        this.transform.position = newPosition;
    }
}
