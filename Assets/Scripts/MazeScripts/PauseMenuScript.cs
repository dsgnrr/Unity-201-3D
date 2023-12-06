using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuScript : MonoBehaviour
{
    [SerializeField]
    private Slider musicVolumeSlider;
    [SerializeField]
    private Slider effectsVolumeSlider;
    [SerializeField]
    private Toggle muteAllToggle;
    [SerializeField]
    private GameObject content;

    void Start()
    {
        MazeState.musicVolume = musicVolumeSlider.value;
        MazeState.effectsVolume = effectsVolumeSlider.value;
        MazeState.isSoundsMuted = muteAllToggle.isOn;
        if (content.activeInHierarchy)
        {
            ShowMenu();
        }
    }
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            if (content.activeInHierarchy)
            {
                HideMenu();
            }
            else
            {
                ShowMenu();
            }
        }
    }
    private void ShowMenu()
    {
        content.SetActive(true);
        Time.timeScale = 0f;
        MazeState.isPause = true;
    }
    private void HideMenu()
    {
        content.SetActive(false);
        Time.timeScale = 1.0f;
        MazeState.isPause = false;
    }
    public void OnMusicVolumeChanged(float volume)
    {
        MazeState.musicVolume = volume;
    }
    public void OnEffectsVolumeChanged(float volume)
    {
        MazeState.effectsVolume = volume;
    }
    public void OnMuteAllChanged(bool value)
    {
        MazeState.isSoundsMuted = value;
    }
}
