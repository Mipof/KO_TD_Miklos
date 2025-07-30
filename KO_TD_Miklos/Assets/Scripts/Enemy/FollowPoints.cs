using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPoints : MonoBehaviour
{
    [Header("OBJS")][Space(15)]
    [SerializeField] private List<Transform> _waypoints;
    
    [Header("STATS")][Space(15)]
    [SerializeField] [Range(0f, 10f)] private float speed = 1f;

    private Coroutine routine;
 
    private IEnumerator MoveRoutine()
    {
        int currentIndex = 0;
        while (true)
        {
            Transform destiny = _waypoints[currentIndex];
            while (Vector3.Distance(transform.position, destiny.position) > 0f)
            {
                if(!this || !gameObject){yield break;}
                LookAtHelper.LookAtTargetWithDelay(transform, destiny);
                transform.position = Vector3.MoveTowards(transform.position, destiny.position, speed * Time.deltaTime);

                yield return null;
            }
            currentIndex++;
            if (currentIndex > _waypoints.Count - 1)
            {
                currentIndex = 0;
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

    private void Start()
    {
        if(_waypoints.Count <= 0){return;}
        routine = StartCoroutine(MoveRoutine());
        
        
    }
}
