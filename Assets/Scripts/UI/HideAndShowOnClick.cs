using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HideAndShowOnClick : MonoBehaviour, IPointerClickHandler
{

    public GameObject ToHide;
    public GameObject ToShow;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        ToHide.SetActive(false);
        ToShow.SetActive(true);
    }
}
