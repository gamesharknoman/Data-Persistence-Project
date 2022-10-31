using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;
    public static MenuUiHandler MenuUiHandler;
    public static GameManager GameManager;
    public string playerName;
    public string highScoreName;
    public int highScore;

    [System.Serializable]
    class PlayerData
    {
        public string playerName;
        public string highScoreName;
        public int highScore;
    }

    public void SavePlayerData()
    {
        PlayerData data = new PlayerData();
        data.playerName = playerName;
        data.highScoreName = highScoreName;
        data.highScore = highScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadPlayerData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            PlayerData data = JsonUtility.FromJson<PlayerData>(json);

            playerName = data.playerName;
            highScoreName = data.highScoreName;
            highScore = data.highScore;
        }
    }
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadPlayerData();
    }

}
