using System;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [Header("STATS")][Space(15)]
    [SerializeField] [Min(0)] private float _maxHealth;
    [SerializeField] private float _currentHealth;
    [SerializeField] private bool _hasDelayForDamage = false;
    [SerializeField] [Min(0)] [Tooltip("If 'hasDelayForDame' is false, this value will not have effect")] 
    private float timeDelayForDamage = 0.5f;

    [Header("CONFIG")] [Space(15)] [Tooltip("If you will initialize this values")]
    [SerializeField] private bool willBeInitialized = false;

    [Header("EVENTS")] [Space(15)] 
    [SerializeField] private UnityEvent OnZeroHealth;
    [SerializeField] private UnityEvent<float> OnGetDamaged;
    [SerializeField] private UnityEvent<float> OnGetHealed;
    [SerializeField] private UnityEvent<int> OnHealthInitialized;

    private bool canGetDamaged = true;
    private bool canBeHealed = true;

    private void Start()
    {
        if(willBeInitialized){return;}
        _currentHealth = _maxHealth;
        OnHealthInitialized?.Invoke((int)_maxHealth);
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

    public void Initialize(float newMaxhelth)
    {
        _maxHealth = newMaxhelth;
        _currentHealth = _maxHealth;
        OnHealthInitialized?.Invoke((int)_maxHealth);
        
    }

    public void DamageForCollision(GameObject obj)
    {
        if (obj.TryGetComponent(out CollisionDamage collisionDamage))
        {
            GetDamage(collisionDamage._damageForCollision);
        }
    }
}
