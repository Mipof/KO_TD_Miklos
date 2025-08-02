using UnityEngine;
using UnityEngine.Events;

public class EnemyData : MonoBehaviour
{
    [Header("DATA")][Space(15)]
    [SerializeField] private EnemyDataSo data;
    
    [Header("EVENTS")][Space(15)]
    [SerializeField] private UnityEvent<EnemyDataSo> OnInitialize;

    [SerializeField] private UnityEvent<float> ChangeMaxHealth;
    [SerializeField] private UnityEvent<float> ChangeCollisionDamage;
    [SerializeField] private UnityEvent<float> ChangeSpeed;
    [SerializeField] private UnityEvent<float> ChangeTreshold;

    private void Start()
    {
        //Set all data on single events because cant handle on time a better way
        OnInitialize?.Invoke(data);
        ChangeMaxHealth?.Invoke(data.enemy.maxHealth);
        ChangeCollisionDamage?.Invoke(data.enemy.damagePerCollision);
        ChangeSpeed?.Invoke(data.enemy.speed);
        ChangeTreshold?.Invoke(data.enemy.threshold);
    }

    public EnemyDataSo GetEnemyData()
    {
        return data;
    }
}
