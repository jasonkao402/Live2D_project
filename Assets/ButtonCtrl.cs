using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
public class ButtonCtrl : MonoBehaviour, IPointerDownHandler, IPointerUpHandler{
    [HideInInspector]public bool ispressed = false;
    public void OnPointerDown(PointerEventData eventData){
        ispressed = true;
    }
    public void OnPointerUp(PointerEventData eventData){
        ispressed = false;
    }
} 