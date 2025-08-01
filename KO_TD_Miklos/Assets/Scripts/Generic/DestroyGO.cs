using UnityEngine;
using UnityEngine.Events;

public class DestroyGO : MonoBehaviour
{
    [SerializeField] private float _timeBeforeDestroy = 0f;
    public UnityEvent<GameObject> OnDestoy;
    public void DestroyThisGO()
    {
        Destroy(gameObject, _timeBeforeDestroy);
        OnDestoy?.Invoke(gameObject);
    }
}
