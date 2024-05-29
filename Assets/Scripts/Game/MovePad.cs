using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class MovePad : MonoBehaviour
{

    public KeyCode MovePadUpKey;
    public KeyCode MovePadDownKey;

    private float Speed => GetComponentInParent<Settings>().PadSpeed;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Pad speed is setted to " + Speed.ToString("0.00"));
    }

    // Update is called once per frame
    void Update()
    {
        float moveTo = Speed * Time.deltaTime;

        if (Input.GetKey(MovePadUpKey))
        {
            transform.position += new Vector3(0f, moveTo, 0f);
        }

        if (Input.GetKey(MovePadDownKey))
        {
            transform.position += new Vector3(0f, -moveTo, 0f);
        }
    }
}
