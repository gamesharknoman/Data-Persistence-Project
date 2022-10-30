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
    public int highScore;
    public string highScoreName;

    [System.Serializable]
    public class PlayerData
    {
        public string playerName;
        public int highScore;
        public string highScoreName;
    }
    public void Update()
    {
        playerName = MenuUiHandler.playerName;
        highScore = GameManager.highScore;
        highScoreName = GameManager.highScoreName;
    }
    public void SavePlayerData()
    {
        PlayerData data = new PlayerData();
        data.playerName = MenuUiHandler.playerName;
        data.highScore = GameManager.highScore;
        data.highScoreName = GameManager.highScoreName;

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

            MenuUiHandler.playerName = data.playerName;
            GameManager.highScore = data.highScore;
            GameManager.highScoreName = data.highScoreName;
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
    }
}
