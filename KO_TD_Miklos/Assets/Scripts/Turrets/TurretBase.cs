using UnityEngine;
using UnityEngine.Events;

public class TurretBase : MonoBehaviour
{
    private TurretDataSO currentTurret;
    private GameObject curretGO = null;
    [Header("INFO")][Space(15)]
    [SerializeField] private TurretDataSO.Turret _currentTurretData;

    [Header("OBJS")][Space(15)]
    [SerializeField] private Transform container;
    

    [Header("EVENTS")] [Space(15)] public UnityEvent<TurretBase> OnClick;

    public void SetTurret(TurretDataSO turret)
    {
        currentTurret = turret;
        if (turret == null)
        {
            turret = ScriptableObject.CreateInstance<TurretDataSO>();
        }
        _currentTurretData = turret.turret;
        DeleteGO();
        SetNewGo();
    }

    //create new GO, add listeners and set on top of the base
    private void SetNewGo()
    {
        if(currentTurret == null){return;}
        container.transform.localScale = Vector3.one;
        curretGO = Instantiate(currentTurret.turret.prefab, transform.position, transform.rotation);
        
        curretGO.transform.SetParent(container);
        if (curretGO.TryGetComponent(out TurretClick click))
        {
            click.OnTurretClick.AddListener(OnMouseDown);
        }

        if (curretGO.TryGetComponent(out InitializeTurret init))
        {
            init.Initialize(currentTurret);
        }
        SetOnTopOfGo.SetOnTop(gameObject, curretGO);
    }

    //Delete current turret GO and remove all listeners 
    private void DeleteGO()
    {
        if (curretGO || currentTurret == null)
        {
            if (curretGO.TryGetComponent(out TurretClick turretClick))
            {
                turretClick.OnTurretClick.RemoveAllListeners();
            }
            curretGO.transform.parent = null;
            if (curretGO.TryGetComponent(out DestroyGO dg))
            {
                dg.DestroyThisGO();
            }
            else
            {
                Debug.LogWarning("TURRET CANT BE DESTROYED");
                return;
            }
        }
    }

    public TurretDataSO GetTurretData()
    {
        return currentTurret;
    }

    private void OnMouseDown()
    {
        print("click");
        OnClick?.Invoke(this);
    }
}