using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUiHandler : MonoBehaviour
{
    public InputField inputField;
    public static string playerName;
    public TMP_Text highScoreText;
    void OnEnable()
    {
        StartCoroutine(SelectInputField());
    }

    IEnumerator SelectInputField()
    {
        yield return new WaitForEndOfFrame();
        inputField.ActivateInputField();
    }
    public void Start()
    {
        MainManager.Instance.LoadPlayerData();
        highScoreText.text = GameManager.highScoreName + " " + GameManager.highScore;
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartNew();
        }
    }
    public void StartNew()
    {
        playerName = inputField.GetComponent<InputField>().text;
        if(playerName == "")
        {
            playerName = "NoName";
        }
        Debug.Log("PlayerName = " + playerName);
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        MainManager.Instance.SavePlayerData();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }
}
