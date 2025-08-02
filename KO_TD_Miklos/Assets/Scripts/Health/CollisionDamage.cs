using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// When need to deal damage on collision, here can handle the logic. Use a [generic]GO_Detection to trigger this
/// </summary>
public class CollisionDamage : MonoBehaviour
{
    [Header("STATS")][Space(15)]
    [Min(0f)] public float _damageForCollision;

    [SerializeField] private UnityEvent<DamageGoEntity> damage;

    public void CreateDamage(GameObject go)
    {
        damage?.Invoke(new DamageGoEntity(go, _damageForCollision));
    }

    public void SetNewCollisionDamage(float newDamage)
    {
        _damageForCollision = newDamage;
    }
}
