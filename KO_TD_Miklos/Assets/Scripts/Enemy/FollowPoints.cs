using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FollowPoints : MonoBehaviour
{
    [Header("OBJS")][Space(15)]
    private List<Transform> _waypoints;
    
    [Header("STATS")][Space(15)]
    [SerializeField] [Range(0f, 10f)] private float speed = 1f;
    [SerializeField] [Range(0.1f, 3f)] [Min(0.1f)][Tooltip("distance that will be considered as arrived to the waypoint. Min = 0.1f")]
    private float _waypointThreshold = 0.1f;
    
    
    [Header("EVENTS")] [Space(15)] 
    [SerializeField] private UnityEvent<Transform> OnTargetChange;
    
    
    private Coroutine routine;
 
    private IEnumerator MoveRoutine()
    {
        int currentIndex = 0;
        while (true)
        {
            Transform destiny = _waypoints[currentIndex];
            OnTargetChange?.Invoke(destiny);
            while (Vector3.Distance(transform.position, destiny.position) > _waypointThreshold)
            {
                if(!this || !gameObject){yield break;}
                transform.position = Vector3.MoveTowards(transform.position, destiny.position, speed * Time.deltaTime);

                yield return null;
            }
            currentIndex++;
            if (currentIndex > _waypoints.Count - 1)
            {
                yield break;
            }
        }
    }

    private void OnDestroy()
    {
        if (routine != null)
        {
            StopCoroutine(routine);
        }
    }

    public void StartFollowing()
    {
        if(_waypoints.Count <= 0){return;}
        routine = StartCoroutine(MoveRoutine());
    }

    public void SetWaypoint(List<Transform> waypoints)
    {
        _waypoints = waypoints;
    }
}
