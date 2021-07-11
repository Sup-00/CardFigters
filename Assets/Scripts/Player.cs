using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] protected int _maxHealth;
    [SerializeField] protected Slider _slider;

    [SerializeField] private int _currentHealth;
    [SerializeField] private UnityEvent _hit;
    [SerializeField] private UnityEvent _hited;
    [SerializeField] private UnityEvent _dying;
    [SerializeField] private UnityEvent _enemyVictory;

    private IEnumerator WaitBeforeSetVitoryAnimation()
    {
        yield return new WaitForSeconds(2);
        _enemyVictory.Invoke();
    }
    
    protected void Start()
    {
        _currentHealth = _maxHealth;
        SetSliderValue();
    }

    protected void SetSliderValue()
    {
        _slider.value = Convert.ToSingle(_currentHealth) / _maxHealth;
    }

    protected void Dead()
    {
        StartCoroutine(WaitBeforeSetVitoryAnimation());
        _dying.Invoke();
    }

    public void Hit()
    {
        _hit.Invoke();
    }
    
    public void TakeDamage(int damage)
    {
        _hited.Invoke();
        
        _currentHealth -= damage;
        SetSliderValue();

        if (_currentHealth <= 0)
            Dead();
    }
}