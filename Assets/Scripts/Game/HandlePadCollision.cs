using UnityEngine;

public class HandlePadCollision : MonoBehaviour
{
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
            Debug.Log($"Conact on {hit.contacts[0].point.x} | {hit.contacts[0].point.y}");

            GameObject ball = hit.gameObject;
        }
    }
}
