using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField]
    private GameObject sun;

    private float camEulerX;
    private float camEulerY;
    private float camSunEulerX;
    private float camSunEulerY;
    private Vector3 camSun; // вектор Сонце -> Камера
    private Camera _camera;
    void Start()
    {
        camEulerX = this.transform.eulerAngles.x;
        camEulerY = this.transform.eulerAngles.y;
        camSun = sun.transform.position - this.transform.position;
        _camera = this.GetComponent<Camera>();
    }
    private void Awake()
    {
        Debug.Log("Awake: "+MazeState.checkPoint1Amount);
    }

    // Update is called once per frame
    void Update()
    {
        float mx = Input.GetAxis("Mouse X"); // Це НЕ координати, а дані
        float my = Input.GetAxis("Mouse Y"); // про пересування миші
        camEulerX -= my;
        camEulerY += mx;
        if (Input.GetMouseButton(0))
        {
            camSunEulerX -= my;
            camSunEulerY += mx;
        }
        //this.transform.Rotate(-my, mx, 0);

    }
    private void LateUpdate()
    {
        // поворот камери навколо свого центру
        this.transform.eulerAngles = new Vector3(camEulerX, camEulerY, 0f);
        if (Input.GetMouseButton(0))
        {
            // поворот вектора camSun
            this.transform.position =
                sun.transform.position -
                Quaternion.Euler(camSunEulerX, camSunEulerY, 0) * camSun;
        }
        Vector2 scroll = Input.mouseScrollDelta;
        if (scroll != Vector2.zero)
        {
            float newValue = _camera.fieldOfView - scroll.y;
            if (newValue >= 5 && newValue <= 120)
            {
                _camera.fieldOfView -= scroll.y;
            }
            else
            {
                if (_camera.fieldOfView < 5f) _camera.fieldOfView = 5f;
                if (_camera.fieldOfView >120f) _camera.fieldOfView = 120f;
            }
        }
    }
}
/* Управління камерою
 * 1. Обертання рузами миші
 *  - недосконалий підхід this.transform.Rotate(-my, mx, 0);
 *      поворот по двох осях призводить до ефекту повороту по третій осі.
 *      "поворот повернутого" тіла відбувається по всіх осях.
 *  - більш рпавильний підхід: безпосередньо встановлювати
 *      кути повороту (кути Ейлера) із збереженням значення 0 для Z
 * 2. Різні режим управління
 *  - прості рухи миші - обертання навколо власної осі
 *  - рух із затисненою клавішею - обертання навколо Сонця
 */
