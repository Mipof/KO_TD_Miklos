using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TurretTracking : MonoBehaviour
{
    [Header("EVENTS")] [Space(15)]
    [SerializeField] private UnityEvent<TurretTargetEntity> OnTargetChanged;
    
    private bool isReady = false;
    private TurretDataSO data;
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

    public void Initialize(TurretDataSO _data)
    {
        data = _data;
        isReady = true;
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
        if(!isReady){return;}
        TurretTargetEntity entity = new TurretTargetEntity(data.turret.type, _detectedEnemies, data.turret.maxEnemies);
        OnTargetChanged?.Invoke(entity);
    }
}
