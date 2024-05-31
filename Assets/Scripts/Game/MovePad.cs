using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class MovePad : MonoBehaviour
{

    public KeyCode MovePadUpKey;
    public KeyCode MovePadDownKey;

    private float Speed => GetComponentInParent<Settings>().PadSpeed;
    private Rigidbody2D Body;
    private BoxCollider BoxCollider;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Pad speed is setted to " + Speed.ToString("0.00"));
        Body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        float moveTo = Speed * Time.deltaTime;

        if (Input.GetKey(MovePadUpKey))
        {
            //transform.position += new Vector3(0f, moveTo, 0f);
            Body.MovePosition(Body.position + new Vector2(0f, moveTo));
        }

        if (Input.GetKey(MovePadDownKey))
        {
            Body.MovePosition(Body.position + new Vector2(0f, -moveTo));
        }
    }

    public void ResetPosition()
    {
        transform.position = new Vector3(transform.position.x, 0f, transform.position.z);
    }
}
