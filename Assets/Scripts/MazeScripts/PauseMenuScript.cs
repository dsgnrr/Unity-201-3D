using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Audio;
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
    [SerializeField]
    private AudioMixer soundMixer;

    void Start()
    {
        OnMusicVolumeChanged(musicVolumeSlider.value);
        OnEffectsVolumeChanged(effectsVolumeSlider.value);
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
        if (!MazeState.isSoundsMuted)
        {
            // volume [0..1], db [-80..+10]
            float dB = -80f + 90f * volume;
            soundMixer.SetFloat("MusicVolume", dB);
        }
    }
    public void OnEffectsVolumeChanged(float volume)
    {
        MazeState.effectsVolume = volume;
        if (!MazeState.isSoundsMuted)
        {
            float dB = -80f + 90f * volume;
            soundMixer.SetFloat("EffectsVolume", dB);
        }
    }
    public void OnMuteAllChanged(bool value)
    {
        MazeState.isSoundsMuted = value;
        if (value)
        {
            soundMixer.SetFloat("EffectsVolume", -80f);
            soundMixer.SetFloat("MusicVolume", -80f);
        }
        else
        {
            OnEffectsVolumeChanged(MazeState.effectsVolume);
            OnMusicVolumeChanged(MazeState.musicVolume);
        }
    }
    public void OnMenuButtonClick(int value)
    {
        //Debug.Log(value.ToString());
        switch (value)
        {
            case 1: //exit
                if (Application.isEditor)
                {
                    EditorApplication.ExitPlaymode();// припиняє гру у редакторі
                    //EditorApplication.Exit(0);// Закриває разом з Unity   
                }
                else
                {
                    Application.Quit(0);
                }
    
                break;
            case 2: // Defaults
                OnMusicVolumeChanged(0.5f);
                OnEffectsVolumeChanged(0.5f);
                OnMuteAllChanged(false);
                break;
            case 3:// Close
                HideMenu();
                break;
            default:
                Debug.LogError($"Undefined button click detected: value = '{value}'");
                break;
        }
    }
}
