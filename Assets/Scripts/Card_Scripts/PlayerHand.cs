using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerHand : DropPlace
{
    public override void OnDrop(PointerEventData eventData)
    {
        Droped(eventData);
    }
}
