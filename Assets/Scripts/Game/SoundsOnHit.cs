using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SoundsOnHit : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D hit)
    {
        if (hit.gameObject.name != "LeftWall" && hit.gameObject.name != "RightWall")
        {
            GetComponent<AudioSource>().Play();
        }
    }
}
