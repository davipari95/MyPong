using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnWallHitted : MonoBehaviour
{

    public Settings GameSettings => FindFirstObjectByType<Camera>().GetComponent<Settings>();

    public Enums.SideEnum WallSide = Enums.SideEnum.Left;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.name == "Ball")
        {
            GameObject ball = collider.gameObject;

            if (WallSide == Enums.SideEnum.Left)
            {
                GameSettings.AssignScore('r');
            }
            else if (WallSide == Enums.SideEnum.Right)
            {
                GameSettings.AssignScore('l');
            }

            GameSettings.LaunchSide = WallSide;

            ball.GetComponent<MoveBall>().Stop();
            GameObject.Find("LeftPad").GetComponent<MovePad>().enabled = false;
            GameObject.Find("RightPad").GetComponent<MovePad>().enabled = false;

            GameObject.Find("MainCamera").GetComponent<Settings>().Canvas.SetActive(true);
        }
    }
}
