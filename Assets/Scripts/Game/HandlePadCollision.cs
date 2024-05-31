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
            Vector2 hitPoint = GetAverageContactPoint(hit.contacts);
            Vector3 localPoint = transform.InverseTransformPoint(hitPoint.x, hitPoint.y, transform.position.z);
            Vector2 localHitPoint = new Vector2(localPoint.x, localPoint.y);

            Debug.Log($"Hit on {localHitPoint.x} | {localHitPoint.y}");
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
}
