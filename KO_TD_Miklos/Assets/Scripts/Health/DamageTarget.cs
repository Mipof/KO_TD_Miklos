using UnityEngine;

public class DamageTarget : MonoBehaviour
{
    public void DamageGO(DamageGoEntity go)
    {
        //Get GO and look for health script to deal damage
        if (go.go && go.go.TryGetComponent(out Health health))
        {
            health.GetDamage(go.damage);
        }
    }
}
