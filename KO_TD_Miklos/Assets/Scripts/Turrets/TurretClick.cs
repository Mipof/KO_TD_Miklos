using UnityEngine;
using UnityEngine.Events;

public class TurretClick : MonoBehaviour
{
    [HideInInspector] public UnityEvent OnTurretClick;

    private void OnMouseDown()
    {
        OnTurretClick?.Invoke();
    }
}
