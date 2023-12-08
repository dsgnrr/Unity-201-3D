using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayScript : MonoBehaviour
{
    [SerializeField]
    private TMPro.TextMeshProUGUI clock;
    [SerializeField]
    private TMPro.TextMeshProUGUI score;

    private float gameTime;
    void Start()
    {
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
        if (second % 5 == 0&&MazeState.score>0)
        {
            MazeState.score -= 1;
            score.text = $"Score: {MazeState.score}";
        }
    } 
}
