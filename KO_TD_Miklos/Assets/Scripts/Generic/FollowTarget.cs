using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class FollowTarget : MonoBehaviour
{
    private Transform target;
    private Coroutine routine;

    [SerializeField] private float speed = 5;

    [SerializeField] [Min(0)] [Tooltip("Lower is more accurate on when stop following")]
    private float threshold = 0f;
    
    [Header("EVENTS")][Space(15)]
    [SerializeField] private UnityEvent<Transform> OnStartFollow;
    [SerializeField] private UnityEvent OnTargetReach;
    
    private IEnumerator FollowRoutine()
    {
        while (true)
        {
            //validate valid target
            while (target  && Vector3.Distance(transform.position, target.position) > threshold)
            {
                //check if this GO still in scene (missile issues)
                if (!this || !gameObject || !target.gameObject)
                {
                    break;
                }
                transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
                yield return null;
            }
            OnTargetReach?.Invoke();
            if(!target){yield break;}
        }
    }

    private void OnDestroy()
    {
        if(routine == null){return;}
        StopCoroutine(routine);
    }

    public void Initialize(Transform _target)
    {
        target = _target;
        routine = StartCoroutine(FollowRoutine());
        OnStartFollow?.Invoke(target);
    }

    public void ChangeTarget(Transform newTarget)
    {
        target = newTarget;
    }

    public void ChangeSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    public void ChangeThreshold(float newThreshold)
    {
        threshold = newThreshold;
    }
}
