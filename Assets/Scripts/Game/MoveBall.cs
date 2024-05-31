using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBall : MonoBehaviour
{

    float StartingForce => GetComponentInParent<Settings>().Force;
    Rigidbody2D RigidBody => GetComponent<Rigidbody2D>();

    void Start()
    {
    }

    public void LaunchBall(Enums.SideEnum direction)
    {
        ResetPosition();
        HitBall(direction);
    }

    public void Stop()
    {
        RigidBody.velocity = Vector2.zero;
    }

    private void ResetPosition()
    {
        transform.position = new Vector3(0f, 0f, 0f);
    }

    private void HitBall(Enums.SideEnum direction)
    {
        int dirVersor = direction == Enums.SideEnum.Left ? -1 : 1;
        RigidBody.AddForce(new Vector2(StartingForce * dirVersor, 0), ForceMode2D.Impulse);
    }
}
