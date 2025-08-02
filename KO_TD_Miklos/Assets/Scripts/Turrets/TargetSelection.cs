using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TargetSelection : MonoBehaviour
{
    [Header("EVENTS")][Space(15)]
    [SerializeField] private UnityEvent<Transform> OnSingleTargetChanged;
    [SerializeField] private UnityEvent<List<Transform>> OnMultipleTargetChanged;
    private TurretDataSO data;


    public void TargetListChanged(TurretTargetEntity entity)
    {
        switch (entity.type)
        {
            case TurretType.SINGLE:
            case TurretType.MISSILE:
                SetNewSingleTarget(entity.listOfTargets);
                break;
            case TurretType.MULTIPLE:
                SetNewMultipleTarget(entity.listOfTargets);
                break;
        }
    }
    //Get first target
    private void SetNewSingleTarget(List<GameObject> targetList)
    {
        Transform target = null;
        if (targetList.Count > 0)
        {
            target = targetList[0].transform;
        }
        
        OnSingleTargetChanged?.Invoke(target);
    }

    //Get the list of targets to deal damage
    private void SetNewMultipleTarget(List<GameObject> targetList)
    { 
        if(!data){return;}
        List<Transform> targets = new List<Transform>();
        for (int i = 0; i < Math.Min(targetList.Count, data.turret.maxEnemies); i++)
        {
            targets.Add(targetList[i].transform);
        }
        OnMultipleTargetChanged?.Invoke(targets);
    }

    public void Initialize(TurretDataSO _data)
    {
        data = _data;
    }
}
