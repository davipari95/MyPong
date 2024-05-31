using System;
using UnityEngine;

public class HandlePadCollision : MonoBehaviour
{

    public enum PadSideEnum
    {
        Left,
        Right,
    }

    public PadSideEnum PadSize = PadSideEnum.Left;

    private float MaxHitAngle => FindFirstObjectByType<Camera>().GetComponent<Settings>().MaxHitAngle;
    private float HitForce => FindFirstObjectByType<Camera>().GetComponent<Settings>().Force;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D hit)
    {
        if (hit.gameObject.name == "Ball")
        {
            Vector2 hitPoint = GetAverageContactPoint(hit.contacts);
            Vector3 localPoint = transform.InverseTransformPoint(hitPoint.x, hitPoint.y, transform.position.z);
            Vector2 localHitPoint = new Vector2(localPoint.x, localPoint.y);
            GameObject ball = hit.gameObject;

            double hitAngleRad = FromDegToRad(localHitPoint.y * MaxHitAngle);
            Vector2 force = new Vector2((float)Math.Cos(hitAngleRad), (float)Math.Sin(hitAngleRad)) * HitForce;

            if (PadSize == PadSideEnum.Right)
            {
                force = new Vector2(-force.x, force.y);
            }

            ball.GetComponent<Rigidbody2D>().velocity = Vector2.zero;   //Remove all forces
            ball.GetComponent<Rigidbody2D>().AddForce(force, ForceMode2D.Impulse);

            FindFirstObjectByType<Camera>().GetComponent<Settings>().IncreaseForce();
        }
    }

    private Vector2 GetAverageContactPoint(ContactPoint2D[] contacts)
    {
        float avgX = 0f;
        float avgY = 0f;

        for (int i = 0; i < contacts.Length; i++)
        {
            avgX = ((avgX * i) + contacts[i].point.x) / (i + 1);
            avgY = ((avgY * i) + contacts[i].point.y) / (i + 1);
        }

        return new Vector2(avgX, avgY);
    }

    private double FromDegToRad(float angleDeg)
    {
        return angleDeg * Math.PI / 180f;
    }
}
