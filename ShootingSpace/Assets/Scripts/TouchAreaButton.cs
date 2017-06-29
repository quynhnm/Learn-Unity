using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class TouchAreaButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    private bool touched;
    private int pointerId;
    private bool canFire;


    private void Awake()
    {
        touched = false;
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        if (!touched)
        {
            touched = true;
            pointerId = eventData.pointerId;
            canFire = true;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (eventData.pointerId == pointerId)
        {
            canFire = false;
            touched = false;
        }
    }

    public bool CanFire()
    {
        return canFire;
    }
}
