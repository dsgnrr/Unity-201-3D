using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MazeState : MonoBehaviour
{
    private static List<Action<String>> observers = new();
    public static void AddNotifyListener(Action<String> listener) => observers.Add(listener);

    private static void NotifyListeners([CallerMemberName]String propertyName="")
    {
        observers.ForEach(listener => listener.Invoke(propertyName));
        /*foreach (var listener in observers)
        {
            listener.Invoke(propertyName);
        }*/
    }

    public static float checkPoint1Amount { get; set; }
    public static bool checkPoint1Passed { get; set; }
    public static bool cameraFirstPerson { get; set; }
    public static bool isDay { get; set; }
    public static bool isPause { get; set; }
    public static int score { get; set; }

   
    public static float effectsVolume;
    private static float _musicVolume;
    public static bool isSoundsMuted;

    public static float musicVolume
    {
        get { return _musicVolume; }
        set { _musicVolume = value; 
            NotifyListeners(); }
    }
}
