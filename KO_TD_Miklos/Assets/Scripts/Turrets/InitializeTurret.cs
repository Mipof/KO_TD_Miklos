using UnityEngine;
using UnityEngine.Events;

public class InitializeTurret : MonoBehaviour
{
    [SerializeField] private UnityEvent<TurretDataSO> OnDataLoaded;

    public void Initialize(TurretDataSO data)
    {
        OnDataLoaded?.Invoke(data);
    }
}
