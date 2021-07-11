using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BattleUI : MonoBehaviour
{
    [SerializeField] private BattleLogic _battleLogitc;
    [SerializeField] private GameObject _fightButton;
    [SerializeField] private GameObject _damageText;
    [SerializeField] private PlayerDropPlace _playerDropPlace;
    [SerializeField] private Transform _enemyDropPlace;

    private void Update()
    {
        if (_playerDropPlace.IsActive)
        {
            SetFightStatsActive(true);
            SetDamageText(true);
        }
        else
        {
            SetFightStatsActive(false);
        }
    }

    private void SetFightStatsActive(bool state)
    {
        _fightButton.SetActive(state);
        _damageText.SetActive(state);
    }

    private void SetDamageText(bool state)
    {
        int damage = _battleLogitc.CalculateDamage();

        if (damage == 0)
        {
            SetTextSettings(Mathf.Abs(damage).ToString(), Color.white);
        }
        else if (damage < 0)
        {
            SetTextSettings(Mathf.Abs(damage).ToString(), Color.red);
        }
        else
        {
            SetTextSettings(Mathf.Abs(damage).ToString(), Color.green);
        }
    }

    private void SetTextSettings(string text, Color color)
    {
        _damageText.GetComponent<TMP_Text>().text = text;
        _damageText.GetComponent<TMP_Text>().color = color;
    }
}