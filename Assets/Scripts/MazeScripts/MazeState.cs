using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeState : MonoBehaviour
{
    public static float checkPoint1Amount { get; set; }
    public static bool checkPoint1Passed { get; set; }
    public static bool cameraFirstPerson { get; set; }
    public static bool isDay { get; set; }
    public static bool isPause { get; set; }

    public static float musicVolume;
    public static float effectsVolume;
    public static bool isSoundsMuted;
}
