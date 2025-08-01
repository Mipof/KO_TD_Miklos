using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class SingleTargetDamage : MonoBehaviour
{
    [Header("STATS")][Space(15)]
    [SerializeField] [Min(0)][Tooltip("The delay before dealing new damage to a new enemy")]
    private float _delayFirstShot = 0.1f;
    
    [SerializeField] [Min(0.1f)][Tooltip("Fire rate")] 
    private float _delayNextShots = 0.5f;

    [SerializeField] [Min(0)] private float _damagePerShot;

    [Header("EVENTS")][Space(15)]
    [SerializeField] private UnityEvent OnFire;

    private Transform currentTarget = null;
    private Coroutine routine;
    
    public void OnTargetChanged(Transform target)
    {
        currentTarget = target;
    }

    IEnumerator ShootRoutine()
    {
        while (true)
        {
            Transform t = currentTarget;
            if (!currentTarget)
            {
                yield return null; 
                continue; 
            }
            yield return new WaitForSeconds(_delayFirstShot);
            while (t == currentTarget)
            {
                if (t && t.TryGetComponent(out Health health))
                {
                    health.GetDamage(_damagePerShot);
                    OnFire?.Invoke();
                }

                yield return new WaitForSeconds(_delayNextShots);
            }
        }
    }

    private void OnDestroy()
    {
        if(routine == null){return;}
        StopCoroutine(routine);
    }

    private void Start()
    {
        routine = StartCoroutine(ShootRoutine());
    }
}
