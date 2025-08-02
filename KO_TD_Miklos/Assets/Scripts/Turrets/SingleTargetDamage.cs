using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class SingleTargetDamage : MonoBehaviour
{


    [Header("EVENTS")][Space(15)]
    [SerializeField] private UnityEvent OnFire;

    [SerializeField] private UnityEvent<DamageGoEntity> DamageGo;

    [SerializeField] [Tooltip("If needed")]
    private GameObject _missilePrefab;

    private Transform currentTarget = null;
    private Coroutine routine;
    private TurretDataSO data;
    private bool targetChanged;
    
    public void OnTargetChanged(Transform target)
    {
        targetChanged = true;
        currentTarget = target;
    }

    private void ShootAction()
    {
        switch (data.turret.type)
        {
            case TurretType.SINGLE:
                ShootEnemy();
                break;
            case TurretType.MISSILE:
                CreateMissile();
                break;
        }
    }

    private void ShootEnemy()
    {
        DamageGo?.Invoke(new DamageGoEntity(currentTarget.gameObject, data.turret.damagePerShot));
    }

    private void CreateMissile()
    {
        GameObject missile = Instantiate(_missilePrefab, transform.position, transform.rotation);
        missile.transform.SetParent(transform);
        if (missile.TryGetComponent(out FollowTarget follow))
        {
            follow.Initialize(currentTarget);
            OnFire?.Invoke();
        }
    }

    IEnumerator ShootRoutine()
    {
        while (true)
        {
            if (!currentTarget)
            {
                yield return null;
                continue; 
            }
            yield return new WaitForSeconds(data.turret.delayFirstShot);
            while (currentTarget && !targetChanged)
            {
                targetChanged = false;
                ShootAction();
                OnFire?.Invoke();

                yield return new WaitForSeconds(data.turret.delayNextShot);
            }
        }
    }

    private void OnDestroy()
    {
        if(routine == null){return;}
        StopCoroutine(routine);
    }

    public void Initialize(TurretDataSO _data)
    {
        print("a");
        data = _data;
        routine = StartCoroutine(ShootRoutine());
    }
}
