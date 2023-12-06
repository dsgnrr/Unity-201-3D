using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private GameObject cameraAnchor;

    private float camAngleX;
    private float camAngleY;
    private float rodAngleX;
    private float rodAngleY;
    private Vector3 camRod;
    void Start()
    {
        camAngleX = this.transform.eulerAngles.x;
        camAngleY = this.transform.eulerAngles.y;
        camRod = transform.position;
        rodAngleX = rodAngleY = 0f;
    }

    void Update()
    {
        if (MazeState.isPause) return;
        float mx = Input.GetAxis("Mouse X");
        float my = Input.GetAxis("Mouse Y");

        camAngleX -= my;
        camAngleY += mx;
        rodAngleX -= my;
        rodAngleY += mx;
        if (Input.GetKeyDown(KeyCode.V))
        {
            MazeState.cameraFirstPerson = !MazeState.cameraFirstPerson;
        }
        //// Обмеження горизонтального кута
        //camAngleX = Mathf.Clamp(camAngleX, 20f, 90f);
        //rodAngleX = Mathf.Clamp(rodAngleX, 20f, 90f);
    }
    private void LateUpdate()
    {
        if (MazeState.isPause) return;

        this.transform.eulerAngles = new Vector3(camAngleX, camAngleY, 0);
        if (MazeState.cameraFirstPerson)
        {
            transform.position = cameraAnchor.transform.position;
        }
        else
        {
            transform.position = Quaternion.Euler(rodAngleX, rodAngleY, 0) * camRod;
        }
    }
}
