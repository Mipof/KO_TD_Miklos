using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MultipleTargetDamage : MonoBehaviour
{
    private Coroutine routine;
    private List<Transform> _currentTargets = new List<Transform>();
    private TurretDataSO data;
    
    [Header("EVENTS")][Space(15)]
    [SerializeField] private UnityEvent OnFire;
    [SerializeField] private UnityEvent<DamageGoEntity> DamageGo;

    private IEnumerator MultipleDamageRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(data.turret.delayFirstShot);
            OnFire?.Invoke();
            foreach (Transform target in _currentTargets)
            {
                DamageGo?.Invoke(new DamageGoEntity(target.gameObject, data.turret.damagePerShot));
            }
        }
    }

    public void ChangeTargets(List<Transform> newList)
    {
        _currentTargets = newList;
    }

    public void Initialize(TurretDataSO _data)
    {
        data = _data;
        routine = StartCoroutine(MultipleDamageRoutine());
    }

    private void OnDestroy()
    {
        if(routine==null){return;}
        StopCoroutine(routine);
    }
}
