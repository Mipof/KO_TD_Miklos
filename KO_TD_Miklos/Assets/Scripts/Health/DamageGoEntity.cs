using UnityEngine;
/// <summary>
/// Entity build for send GO and damage through event
/// </summary>
[System.Serializable]
public class DamageGoEntity
{
    public GameObject go;
    public float damage;

    public DamageGoEntity(GameObject _go, float _damage)
    {
        this.go = _go;
        this.damage = _damage;
    }
}