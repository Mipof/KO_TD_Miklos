using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
/// <summary>
/// This script will assist the [generic]follow target script, providing next points to follow
/// </summary>
public class FollowPoints : MonoBehaviour
{
    [Header("OBJS")][Space(15)]
    private List<Transform> _waypoints;

    [Header("EVENTS")] [Space(15)] 
    [SerializeField] private UnityEvent<Transform> OnTargetChange;

    [SerializeField] private UnityEvent<Transform> StartFollowingPoints;


    private int currentIndex = 0;

    public void StartFollowing()
    {
        if(_waypoints.Count <= 0){return;}
        StartFollowingPoints?.Invoke(_waypoints[0]);
    }

    public void TargetReached()
    {
        currentIndex++;
        Transform nextTarget = null;
        if (currentIndex <= _waypoints.Count - 1)
        {
            nextTarget = _waypoints[currentIndex];
        }
        OnTargetChange?.Invoke(nextTarget);
    }

    public void SetWaypoint(List<Transform> waypoints)
    {
        _waypoints = waypoints;
    }
}
