using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PaddleIA : MonoBehaviour
{
    #region  Inspector
    public GameObject Ball;
    public GameObject MainCamera;
    [Range(0.05f, 5.0f)] public float ErrorMargin;
    #endregion

    Rigidbody2D RigidBody => GetComponent<Rigidbody2D>();
    Settings Settings => MainCamera.GetComponent<Settings>();
    float Speed => Settings.PadSpeed;

    private float HitPosition;

    // Start is called before the first frame update
    void Start()
    {
        RegenerateHitPosition();
    }

    void FixedUpdate()
    {
        float hitY = RigidBody.transform.TransformPoint(0, HitPosition, 0).y;
        float move = Speed * Time.deltaTime;
        float direction = Ball.transform.position.y > hitY ? 1 : -1;
        float distance = Math.Abs(hitY - Ball.transform.position.y);

        RigidBody.MovePosition(RigidBody.position + new Vector2(0, Math.Min(move, distance) * direction));
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        RegenerateHitPosition();
    }

    void RegenerateHitPosition()
    {
        HitPosition = UnityEngine.Random.Range(-0.5f - ErrorMargin, 0.5f + ErrorMargin);
    }

    public void Reset()
    {
        transform.position = new Vector3(transform.position.x, 0f, transform.position.z);
        RegenerateHitPosition();
    }
}
