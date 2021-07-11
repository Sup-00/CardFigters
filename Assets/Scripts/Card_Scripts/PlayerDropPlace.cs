using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerDropPlace : DropPlace
{
    public bool IsActive => transform.GetComponentInChildren<Card>();

    public override void OnDrop(PointerEventData eventData)
    {
        if (IsActive)
            return;
        else
            Droped(eventData);
    }
}