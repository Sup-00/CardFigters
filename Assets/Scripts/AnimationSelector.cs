using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AnimationSelector : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private int _entryCount;
    [SerializeField] private int _idleCount;
    [SerializeField] private int _boxingCount;
    [SerializeField] private int _hitCount;
    [SerializeField] private int _victoryCount;
    [SerializeField] private int _dyingCount;

    private void Start()
    {
        _animator.SetInteger("Entry_ID", Random.Range(1, _entryCount));
        _animator.SetInteger("Idle_ID", Random.Range(1, _idleCount));
    }

    public void SetBoxingAnimation()
    {
        _animator.SetTrigger("Boxing");
        _animator.SetInteger("Boxing_ID", Random.Range(1, _boxingCount));
    }
    
    public void SetHitAnimation()
    {
        _animator.SetTrigger("Hit");
        _animator.SetInteger("Hit_ID", Random.Range(1, _hitCount));
    }
    
    public void SetVictoryAnimation()
    {
        _animator.SetTrigger("Victory");
        _animator.SetInteger("Victory_ID", Random.Range(1, _victoryCount));
    }
    
    public void SetDyingAnimation()
    {
        _animator.SetTrigger("Dying");
        _animator.SetInteger("Dying_ID", Random.Range(1, _dyingCount));
    }
}