using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleIA : MonoBehaviour
{
    #region  Inspector
    [Range(0.05f, 5.0f)] public float ErrorMargin;
    #endregion

    Rigidbody2D RigidBody => GetComponent<Rigidbody2D>();
    GameObject Ball = GameObject.Find("Ball");

    private float HitPosition;

    // Start is called before the first frame update
    void Start()
    {
        HitPosition = Random.Range(-0.5f - ErrorMargin, 0.5f + ErrorMargin);
    }

    void FixedUpdate()
    {
        float hitY = RigidBody.transform.TransformPoint(0, HitPosition, 0).y;

        //if (Ball.transform.position.y > )
    }
}
