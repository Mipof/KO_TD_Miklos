using UnityEngine;
using UnityEngine.Events;

public class EnemyDetection : MonoBehaviour
{
    [Header("EVENTS")][Space(15)]
    [SerializeField] private UnityEvent<Transform> OnEnemyEnter;
    [SerializeField] private UnityEvent<Transform> OnEnemyExit;
    private void OnTriggerEnter(Collider other)
    {
        if(!other.CompareTag("Enemy")){return;}
        OnEnemyEnter?.Invoke(other.transform);
    }

    private void OnTriggerExit(Collider other)
    {
        if(!other.CompareTag("Enemy")){return;}
        OnEnemyExit?.Invoke(other.transform);
    }
}
