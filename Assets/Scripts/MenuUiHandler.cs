using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MenuUiHandler : MonoBehaviour
{
    public InputField inputField;
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
        highScoreText.text = MainManager.Instance.highScoreName + ": " + MainManager.Instance.highScore;
        inputField.GetComponent<InputField>().text = MainManager.Instance.playerName;
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
        MainManager.Instance.playerName = inputField.GetComponent<InputField>().text;
        if(MainManager.Instance.playerName == "")
        {
            MainManager.Instance.playerName = "NoName";
        }
        Debug.Log("PlayerName = " + MainManager.Instance.playerName);
        SceneManager.LoadScene(1);
    }

}
