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
    private TMPro.TextMeshProUGUI level;
    [SerializeField]
    private Image image1; // for checkpoint1 indicator
    [SerializeField]
    private Image image2; // for checkpoint2 indicator

    private float gameTime;
    void Start()
    {
        MazeState.AddPropertyListener(nameof(MazeState.checkPoint1Amount),OnCheckpoint1AmountChanged);
        MazeState.AddPropertyListener(nameof(MazeState.checkPoint2Amount),OnCheckpoint2AmountChanged);
        MazeState.AddPropertyListener(nameof(MazeState.gameLevel),OnGameLevelChanged);
        gameTime = 0f;
        MazeState.score = 100;
        MazeState.gameLevel = 1;
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
    private void OnCheckpoint1AmountChanged()
    {
       image1.fillAmount = MazeState.checkPoint1Amount; 
    }
    private void OnCheckpoint2AmountChanged()
    {
        image2.fillAmount = MazeState.checkPoint2Amount;
    }
    private void OnGameLevelChanged()
    {
        level.text = $"Level: {MazeState.gameLevel}";
    }
    private void OnDestroy()
    {
        MazeState.RemovePropertyListener(nameof(MazeState.checkPoint1Amount), OnCheckpoint1AmountChanged);
        MazeState.RemovePropertyListener(nameof(MazeState.checkPoint2Amount), OnCheckpoint2AmountChanged);
        MazeState.RemovePropertyListener(nameof(MazeState.gameLevel), OnGameLevelChanged);
    }
}
