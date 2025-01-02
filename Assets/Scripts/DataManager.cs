using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    public string playerName;
    public string bestScorerName;
    public int bestScore;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } 
        else
        {
            Destroy(gameObject);
        }

        LoadBestScore();
    }

    public void SetName(string name)
    {
        playerName = name;
    }

    public void SetBestScore(string playerName, int newHighestScore)
    {
        bestScorerName = playerName;
        bestScore = newHighestScore;

        SaveBestScore();
    }

    [System.Serializable]
    private class SaveData
    {
        public string bestScorerName;
        public int bestScore;
    }

    public void SaveBestScore()
    {
        SaveData data = new SaveData();
        data.bestScorerName = bestScorerName;
        data.bestScore = bestScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadBestScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestScorerName = data.bestScorerName;
            bestScore = data.bestScore;
        }
    }
}
