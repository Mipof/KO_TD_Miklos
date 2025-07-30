using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [Header("STATS")][Space(15)]
    [SerializeField] [Min(0)] private float _maxHealth;
    [SerializeField] private float _currentHealth;
    [SerializeField] private bool _hasDelayForDamage = false;
    [SerializeField] [Min(0)] [Tooltip("If 'hasDelayForDame' is false, this value will not have effect")] 
    private float timeDelayForDame = 0.5f;

    [Header("EVENTS")] [Space(15)] 
    [SerializeField] private UnityEvent OnZeroHealth;
    [SerializeField] private UnityEvent<float> OnGetDamaged;
    [SerializeField] private UnityEvent<float> OnGetHealed;

    private bool canGetDamaged = true;
    private bool canBeHealed = true;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    private void CheckIfStillAlive()
    {
        if (_currentHealth <= 0)
        {
            _currentHealth = 0;
            OnZeroHealth?.Invoke();
        }
    }

    public void GetDamage(float damage)
    {
        if(!canGetDamaged) return;
        OnGetDamaged?.Invoke(damage);
        _currentHealth -= damage;
        CheckIfStillAlive();
    }

    public void GetHealed(float heal)
    {
        if(!canBeHealed)return;
        OnGetHealed?.Invoke(heal);
        _currentHealth = Math.Min(_maxHealth, _currentHealth + heal);
    }
}
