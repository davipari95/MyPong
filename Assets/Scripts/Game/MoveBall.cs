using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBall : MonoBehaviour
{

    float Speed => GetComponentInParent<Settings>().BallSpeed;
    Rigidbody2D RigidBody;

    // Start is called before the first frame update
    void Start()
    {
        RigidBody = GetComponent<Rigidbody2D>();
        RigidBody.AddForce(new Vector2(200, 200));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
