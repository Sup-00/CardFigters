using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class CardMover : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Camera _camera;
    private Transform _cardtParent;
    private TemporaryCard _temporaryCard;

    private void Awake()
    {
        _camera = Camera.main;
        _temporaryCard = FindObjectOfType<TemporaryCard>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _cardtParent = transform.parent;

        _temporaryCard.transform.SetParent(_cardtParent);
        _temporaryCard.transform.SetSiblingIndex(transform.GetSiblingIndex());

        transform.SetParent(_cardtParent.parent);
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        float z = 50;
        Vector3 newPosition = GetWorldPositionOnPlane(eventData.position, z);
        transform.position = newPosition;

        CheckPosition();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(_cardtParent);
        transform.SetSiblingIndex(_temporaryCard.transform.GetSiblingIndex());
        _temporaryCard.transform.SetParent(GameObject.Find("Canvas").transform);
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    public void SetCardParent(Transform parent)
    {
        _cardtParent = parent;
    }

    private Vector3 GetWorldPositionOnPlane(Vector3 screenPosition, float z)
    {
        Ray ray = _camera.ScreenPointToRay(screenPosition);
        Plane plane = new Plane(Vector3.forward, new Vector3(0, 0, z));
        float distance;
        plane.Raycast(ray, out distance);
        return ray.GetPoint(distance);
    }

    private void CheckPosition()
    {
        int index = _cardtParent.childCount;

        for (int i = 0; i < _cardtParent.childCount; i++)
        {
            if (transform.position.x < _cardtParent.GetChild(i).position.x)
            {
                index = i;

                if (_temporaryCard.transform.GetSiblingIndex() < index)
                {
                    index--;
                }

                break;
            }
        }

        _temporaryCard.transform.SetSiblingIndex(index);
    }
}