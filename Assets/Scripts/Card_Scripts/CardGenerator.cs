using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardGenerator : MonoBehaviour
{
    [SerializeField] private List<Sprite> _redNumbers;
    [SerializeField] private List<Sprite> _blackNumbers;
    [SerializeField] private List<Sprite> _suits;
    [SerializeField] private string[] _suitNames;

    public void CreatCard(Card cardType, Transform spawnPoint)
    {
        Sprite Number;
        Sprite Suit;
        int NumberRange = Random.Range(0, _redNumbers.Count);
        int SuitNameIndex = Random.Range(0, _suits.Count);
        string SuitName = _suitNames[SuitNameIndex];

        if (SuitNameIndex <= 1)
            Number = _redNumbers[NumberRange];
        else
            Number = _blackNumbers[NumberRange];

        Suit = _suits[SuitNameIndex];

        var card = Instantiate(cardType, spawnPoint);

        card.SetNumber(Number, NumberRange + 2);
        card.SetSuit(Suit, SuitName);
    }
}