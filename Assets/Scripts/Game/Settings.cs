using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Diagnostics;

public class Settings : MonoBehaviour
{
    public struct ScoreStruct
    {
        public uint Left;
        public uint Right;
    }

    #region  Inspector
    [Header("Inactivable objects")]
    public GameObject Canvas;

    [Header("Pad")]
    public float PadSpeed = 1.0f;

    [Header("Ball")]
    [Range(45f, 60f)]
    public float MaxHitAngle;
    public float StartingForce;
    public float ForceIncrease;

    [Header("Game")]
    public Enums.SideEnum LaunchSide;
    #endregion
    
    [HideInInspector] public ScoreStruct Score;
    [HideInInspector] public float Force;

    public void Start()
    {
        Score.Left = 0;
        Score.Right = 0;
    }

    public void IncreaseForce()
    {
        Force += ForceIncrease;
    }

    public void AssignScore(char side)
    {
        switch (side)
        {
            case 'l':
                Score.Left++;
                break;
            case 'r':
                Score.Right++;
                break;
            default:
                Debug.LogError("AssignScore side not valid");
                break;
        }
    }

    public void ResetScore()
    {
        Score.Left = 0;
        Score.Right = 0;
    }

    public void Reset()
    {
        Force = StartingForce;
    }
}
