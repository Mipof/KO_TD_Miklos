using UnityEngine;
using UnityEngine.Events;

public class DestroyGO : MonoBehaviour
{
    [SerializeField] private float _timeBeforeDestroy = 0f;
    [SerializeField] private UnityEvent OnDestoy;
    public void DestroyThisGO()
    {
        Destroy(gameObject, _timeBeforeDestroy);
        OnDestoy?.Invoke();
    }
}
