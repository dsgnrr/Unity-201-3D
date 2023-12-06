using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotLightScript : MonoBehaviour
{
    [SerializeField]
    private GameObject _camera;

    private Light spotLight;
    void Start()
    {
        spotLight = this.GetComponent<Light>();
    }

    void Update()
    {
        if (MazeState.isPause) return;
        if (MazeState.cameraFirstPerson && !MazeState.isDay) 
        {
            this.transform.position = _camera.transform.position;
            this.transform.forward = _camera.transform.forward;
            Vector2 wheel = Input.mouseScrollDelta;
            if (wheel.y!=0) // [25..90]
            {
                float spotAngle = spotLight.spotAngle + wheel.y;
                if (spotAngle < 25f)
                {
                    spotAngle = 25f;
                }
                else if (spotAngle > 90f)
                {
                    spotAngle = 90f;
                }
                spotLight.spotAngle = spotAngle;
            }
        }  
    }
}
