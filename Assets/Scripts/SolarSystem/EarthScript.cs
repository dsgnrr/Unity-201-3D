using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthScript : MonoBehaviour
{
    [SerializeField]
    private GameObject sun;


    private GameObject surface;
    private GameObject atmosphere;
    private float dayPeriod = 24f / 360f;
    private float skyPeriod = 12f / 360f;
    private float yearPeriod = 73f / 360f;


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
        this.transform.RotateAround(sun.transform.position, Vector3.up, Time.deltaTime / yearPeriod);
    }
}
/* Вектор:
 * - (в Юніті) це тип даних(структура), яка зберігає дані та декларує основні
 * методи для роботи з ними. Vector2 - два числа (х,у), Vector3 - (x,y,z)
 * - (в алгебрі) це випорядкована множина чисел (або інших об'єктів)
 * - (у геометрії)
 *  = спрямований відрізок - характеристика напряму (наприклад, руху чи обертання)
 *  = точка у просторі з координатами (x,y,z)
 */
