using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SetScoreText : MonoBehaviour
{
    Settings GameSettings => FindFirstObjectByType<Camera>().GetComponent<Settings>();
    
    public void UpdateText()
    {
        string scoreText = "Actual score\r\n{0} - {1}";
        scoreText = string.Format(scoreText, GameSettings.Score.Left, GameSettings.Score.Right);

        GetComponent<TextMeshProUGUI>().text = scoreText;
    }

    public void OnEnable()
    {
        UpdateText();
    }
}
