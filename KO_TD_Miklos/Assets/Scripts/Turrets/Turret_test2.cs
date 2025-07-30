using System.Collections.Generic;
using UnityEngine;

public class Turret_test2 : MonoBehaviour
{
    [Header("OBJS")][Space(15)]
    [SerializeField] private Transform _pivot;
    [SerializeField] private List<Transform> _detectedEnemies;

    [Header("STATS")][Space(15)]
    [SerializeField] [Range(0f, 50f)] private float _rotationSpeed = 10f;

    private Quaternion init;
    
    public void AddEnemyToTrackList(Transform enemy)
    {
        if (!_detectedEnemies.Contains(enemy))
        {
            _detectedEnemies.Add(enemy);
        }
    }

    public void RemoveEnemyFromTrackList(Transform enemy)
    {
        if (_detectedEnemies.Contains(enemy))
        {
            _detectedEnemies.Remove(enemy);
        }
    }

    void Update()
    {
        if (_detectedEnemies.Count <= 0)
        {
            LookAtHelper.LookAtTargetWithDelay(_pivot, init, _rotationSpeed);
            _pivot.rotation = init;
            return;
        }

        Transform enemy = _detectedEnemies[0];
        LookAtHelper.LookAtTargetWithDelay(_pivot, enemy, _rotationSpeed);
    }
}
