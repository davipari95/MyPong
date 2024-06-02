using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChangeButtonBackground : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public float TransitionTime = 0.5f;
    public float MaxAlpha = 10f;

    private bool MouseIn = false;
    private float ActAlpha = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (MouseIn)
        {
            ActAlpha += Time.deltaTime / TransitionTime * MaxAlpha;
            ActAlpha = Math.Min(MaxAlpha, ActAlpha);
        }
        else
        {
            ActAlpha -= Time.deltaTime / TransitionTime * MaxAlpha;
            ActAlpha = Math.Max(0, ActAlpha);
        }

        Color color = GetComponent<UnityEngine.UI.Image>().color;
        GetComponent<UnityEngine.UI.Image>().color = new Color(color.r, color.g, color.b, ActAlpha / 255f);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        MouseIn = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        MouseIn = false;
    }
}
