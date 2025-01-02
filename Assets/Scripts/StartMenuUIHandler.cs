using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

[DefaultExecutionOrder(1000)]
public class StartMenuUIHandler : MonoBehaviour
{
    public TextMeshProUGUI bestScoreText;
    public TextMeshProUGUI playerNameText;

    private void Start()
    {
        string highestScorerName = DataManager.Instance.bestScorerName;
        int highestScore = DataManager.Instance.bestScore;

        bestScoreText.text = $"Best Score: {highestScorerName} - {highestScore}";
    }

    public void StartNew()
    {
        DataManager.Instance.SetName(playerNameText.text);

        SceneManager.LoadScene(1);
    }
}
