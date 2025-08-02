using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class FollowTarget : MonoBehaviour
{
    private Transform target;
    private Coroutine routine;

    [SerializeField] private float speed = 5;
    [SerializeField] private UnityEvent<Transform> OnStartFollow;
    [SerializeField] private UnityEvent OnTargetLost;
    private IEnumerator FollowRoutine()
    {
        while (true)
        {
            
            while (target  && Vector3.Distance(transform.position, target.position) > 0f)
            {
                if (!this || !gameObject || !target.gameObject)
                {
                    break;
                }
                transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
                yield return null;
            }
            OnTargetLost?.Invoke();
            yield break;
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
}
