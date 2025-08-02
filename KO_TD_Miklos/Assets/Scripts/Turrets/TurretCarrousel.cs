using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TurretCarrousel : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Transform _content;
    private TurretManager _manager;
    private List<TurretDataSO> _turrets = new List<TurretDataSO>();

    [HideInInspector] public UnityEvent<TurretDataSO> onTurretBuy;

    private void Start()
    {
        _manager = FindObjectOfType<TurretManager>();
        if(!_manager)
        {
            Debug.LogWarning("NO TURRET MANAGER");
            return;
        }
        _turrets = _manager._turretsAvailable;
        if(_turrets.Count == 0){Debug.LogWarning("EMPTY TURRETS"); return;}
        CreateTurretObj();
    }

    private void CreateTurretObj()
    {
        foreach (TurretDataSO turret in _turrets)
        {
            if(turret.turret.isUpgradeFromOther){continue;}
            GameObject prefab = Instantiate(_prefab, _content);
            if (prefab.TryGetComponent(out TurretFillData turretFill))
            {
                turretFill.InitTurret(turret);
                turretFill.BuyTurret.AddListener(ListenBuyTurret);
            }
        }
    }

    private void ListenBuyTurret(TurretDataSO turret)
    {
        onTurretBuy?.Invoke(turret);
    }
}
