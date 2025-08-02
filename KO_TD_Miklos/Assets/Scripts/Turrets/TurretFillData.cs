using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class TurretFillData : MonoBehaviour
{
    [Header("OBJS")][Space(15)]
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private TextMeshProUGUI _cost;

    public UnityEvent<TurretDataSO> BuyTurret;

    [HideInInspector]
    public TurretDataSO turret;

    public void InitTurret(TurretDataSO _turret)
    {
        turret = _turret;
        _name.text = turret.turret.turretName;
        _cost.text = $"${turret.turret.cost}";
    }

    public void OnCLick()
    {
        print("buying on canva");
        BuyTurret?.Invoke(turret);
    }
}
