using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BattleLogic : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Player _player;
    [SerializeField] private Transform _playerHand;
    [SerializeField] private Transform _enemyDropPlace;
    [SerializeField] private Transform _playerDropPlace;
    [SerializeField] private Card _playerCard;
    [SerializeField] private Card _enemyCard;
    [SerializeField] private CardGenerator _cardGenerator;

    public void Fight()
    {
        int damage = CalculateDamage();

        if (damage == 0)
        {
        }
        else if (damage < 0)
        {
            _enemy.Hit();
            _player.TakeDamage(Mathf.Abs(damage));
        }
        else
        {
            _player.Hit();
            _enemy.TakeDamage(Mathf.Abs(damage));
        }

        DestroyCards();
        CreateCards();
    }

    public int CalculateDamage()
    {
        int playerDamage = _playerDropPlace.GetComponentInChildren<Card>().NumberRang;
        string playerSuit = _playerDropPlace.GetComponentInChildren<Card>().SuitName;
        int enemyDamage = _enemyDropPlace.GetComponentInChildren<Card>().NumberRang;
        string enemySuit = _enemyDropPlace.GetComponentInChildren<Card>().SuitName;

        if (playerSuit != enemySuit)
            playerDamage /= 2;

        return playerDamage - enemyDamage;
    }

    private void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            _cardGenerator.CreatCard(_playerCard, _playerHand);
        }

        _cardGenerator.CreatCard(_enemyCard, _enemyDropPlace);
    }

    private void DestroyCards()
    {
        Destroy(_playerDropPlace.GetComponentInChildren<Card>().gameObject);
        Destroy(_enemyDropPlace.GetComponentInChildren<Card>().gameObject);
    }

    private void CreateCards()
    {
        _cardGenerator.CreatCard(_playerCard, _playerHand);
        _cardGenerator.CreatCard(_enemyCard, _enemyDropPlace);
    }
}