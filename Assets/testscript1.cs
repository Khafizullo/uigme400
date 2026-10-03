using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class testscript1 : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Mouse clicked th button");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Mouse pointer down");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Mouse pointer enter");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Mouse pointer exit");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("Mouse pointer up");
    }
}
