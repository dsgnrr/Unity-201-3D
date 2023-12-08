using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayScript : MonoBehaviour
{
    [SerializeField]
    private TMPro.TextMeshProUGUI clock;
    [SerializeField]
    private TMPro.TextMeshProUGUI score;
    [SerializeField]
    private Image image1; // for checkpoint1 indicator

    private float gameTime;
    void Start()
    {
        MazeState.AddPropertyListener(nameof(MazeState.checkPoint1Amount),OnMazeStateChanged);
        gameTime = 0f;
        MazeState.score = 100;
        score.text = $"Score: {MazeState.score}";
    }
    void Update()
    {
        gameTime += Time.deltaTime;
    }
    private void LateUpdate()
    {
        int time = (int)gameTime;
        int hour = time / 3600;
        int minute = (time % 3600) / 60;
        int second = time % 60;
        int decisecond = (int)((gameTime - time) * 10);
        clock.text = $"{hour:00}:{minute:00}:{second:00}.{decisecond:0}";
        if (second % 5 == 0 && MazeState.score > 0) 
        {
            MazeState.score -= 1;
            score.text = $"Score: {MazeState.score}";
        }
    } 
    private void OnMazeStateChanged()
    {
       image1.fillAmount = MazeState.checkPoint1Amount; 
    }
    private void OnDestroy()
    {
        MazeState.RemovePropertyListener(nameof(MazeState.checkPoint1Amount), OnMazeStateChanged);
    }
}
