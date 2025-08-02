using UnityEngine;

public class DamageTarget : MonoBehaviour
{
    public void DamageGO(DamageGoEntity go)
    {
        if (go.go && go.go.TryGetComponent(out Health health))
        {
            health.GetDamage(go.damage);
        }
    }
}
