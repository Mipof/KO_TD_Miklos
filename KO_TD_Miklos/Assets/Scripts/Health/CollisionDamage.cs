using UnityEngine;
using UnityEngine.Events;

public class CollisionDamage : MonoBehaviour
{
    [Header("STATS")][Space(15)]
    [Min(0f)] public float _damageForCollision;

    [SerializeField] private UnityEvent<DamageGoEntity> damage;

    public void CreateDamage(GameObject go)
    {
        damage?.Invoke(new DamageGoEntity(go, _damageForCollision));
    }
}
