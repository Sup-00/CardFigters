using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    [SerializeField] private List<Image> _suits;
    [SerializeField] private List<Image> _numbers;

    protected int _numberRang;
    protected string _suitName;

    public int NumberRang => _numberRang;
    public string SuitName => _suitName;

    public void SetSuit(Sprite suit, string suitName)
    {
        _suitName = suitName;

        foreach (var cardSuit in _suits)
        {
            cardSuit.sprite = suit;
        }
    }

    public void SetNumber(Sprite number, int numberRang)
    {
        _numberRang = numberRang;

        foreach (var cardNumber in _numbers)
        {
            cardNumber.sprite = number;
        }
    }
}