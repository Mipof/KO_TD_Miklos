using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Turret_test2 : MonoBehaviour
{
    [Header("STATS")][Space(15)]
    [SerializeField] private TurretType _turretType;

    [SerializeField] [Tooltip("if type is 'SINGLE' this value will have no effect")]
    private int _maxTargets = 1;
    
    [Header("EVENTS")] [Space(15)]
    [SerializeField] private UnityEvent<TurretTargetEntity> OnTargetChanged;

    private Quaternion init;
    private List<GameObject> _detectedEnemies = new List<GameObject>();
    
    public void AddEnemyToTrackList(GameObject enemy)
    {
        if (_detectedEnemies.Contains(enemy)) return;
        _detectedEnemies.Add(enemy);
        if (enemy.TryGetComponent(out DestroyGO dg))
        {
            dg.OnDestoy.AddListener(RemoveEnemyFromTrackList);
        }
        SelectCurrentTarget();
    }

    public void RemoveEnemyFromTrackList(GameObject enemy)
    {
        if (!_detectedEnemies.Contains(enemy)) return;
        _detectedEnemies.Remove(enemy);
        if (enemy.TryGetComponent(out DestroyGO dg))
        {
            dg.OnDestoy.RemoveListener(RemoveEnemyFromTrackList);
        }
        SelectCurrentTarget();
    }

    private void SelectCurrentTarget()
    {
        TurretTargetEntity entity = new TurretTargetEntity(_turretType, _detectedEnemies, _maxTargets);
        OnTargetChanged?.Invoke(entity);
    }
}
