using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightScript : MonoBehaviour
{
    #region isDay_prop
    private bool _isDay;
    private bool isDay
    {
        get => _isDay;
        set
        {
            MazeState.isDay = _isDay = value;
            if (_isDay) SetDayLighting();
            else SetNightLighting();
        }
    }
    #endregion

    private Light lightComponent;
    void Start()
    {
        lightComponent = this.GetComponent<Light>();
        isDay = true;
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.N))
        {
            isDay = !isDay;
        }
        if(Input.GetKeyUp(KeyCode.KeypadMinus)) 
        {
            float intensity = lightComponent.intensity;
            float newIntensity = intensity - 0.01f;
            if (intensity >0.01f)
            {
                intensity = newIntensity;
                RenderSettings.skybox.SetFloat("_Exposure", newIntensity);
            }
            lightComponent.intensity = intensity;  
        }
        if (Input.GetKeyUp(KeyCode.KeypadPlus))
        {
            float intensity = lightComponent.intensity;
            float newIntensity = intensity + 0.01f;
            if (intensity < 1f)
            {
                intensity = newIntensity;
                RenderSettings.skybox.SetFloat("_Exposure", newIntensity);
            }
            lightComponent.intensity = intensity;
        }
        if (lightComponent.intensity < 0.01f)
        {
            lightComponent.intensity = 0.01f;
            RenderSettings.skybox.SetFloat("_Exposure", 0.01f);
        }
        if (lightComponent.intensity > 1f)
        {
            lightComponent.intensity = 1f;
            RenderSettings.skybox.SetFloat("_Exposure", 1f);
        }
    }
    private void SetDayLighting()
    {
        lightComponent.intensity = 1f;
        RenderSettings.skybox.SetFloat("_Exposure", 1f);
    }
    private void SetNightLighting()
    {
        lightComponent.intensity = .05f;
        RenderSettings.skybox.SetFloat("_Exposure", .05f);
    }
}
/* Світло й управління світлом
 * 1. Спрямоване світло - основне джерело, освітлення, не залежить
 * від позиції, тільки повороти (нахил) променів світла. Головна
 * характеристика для управління - інтенсивність
 * 2. Skybox (небо). У нього є багато параметрів, за світність
 * відповідає "_Exposure". Але особливість роботи з цим параметром -
 * встановлення через SetFloat()
 */
