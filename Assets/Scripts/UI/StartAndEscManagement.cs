using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameWithEnter : MonoBehaviour
{
    public bool IsOnePlayerGame;

    private Settings GameSettings => GameObject.Find("MainCamera").GetComponent<Settings>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartGame();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        }
    }

    private void StartGame()
    {
        gameObject.SetActive(false);

        List<string> padNames = new List<string>()
        {
            "LeftPad",
        };

        if (!IsOnePlayerGame)
        {
            padNames.Add("RightPad");
        }
        else
        {
            GameObject.Find("RightPad").GetComponent<PaddleIA>().Reset();
        }

        foreach (string padName in padNames)
        {
            GameObject.Find(padName).GetComponent<MovePad>().ResetPosition();
            GameObject.Find(padName).GetComponent<MovePad>().enabled = true;
        }

        GameObject.Find("Ball").GetComponent<MoveBall>().LaunchBall(GameSettings.LaunchSide);
    }
}
