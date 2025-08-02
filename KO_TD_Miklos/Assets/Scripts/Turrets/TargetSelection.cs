using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TargetSelection : MonoBehaviour
{
    [SerializeField] private UnityEvent<Transform> OnSingleTargetChanged;


    public void TargetListChanged(TurretTargetEntity entity)
    {
        switch (entity.type)
        {
            case TurretType.SINGLE:
            case TurretType.MISSILE:
                SetNewSingleTarget(entity.listOfTargets);
                break;
            case TurretType.MULTIPLE:
                break;
        }
    }

    private void SetNewSingleTarget(List<GameObject> targetList)
    {
        Transform target = null;
        if (targetList.Count > 0)
        {
            target = targetList[0].transform;
        }
        
        OnSingleTargetChanged?.Invoke(target);
    }
}
