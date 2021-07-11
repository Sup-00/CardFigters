using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class DropPlace : MonoBehaviour, IDropHandler
{
    public abstract void OnDrop(PointerEventData eventData);

    protected void Droped(PointerEventData eventData)
    {
        CardMover card = eventData.pointerDrag.GetComponent<CardMover>();

        if (card != null)
            card.SetCardParent(transform);
    }

}