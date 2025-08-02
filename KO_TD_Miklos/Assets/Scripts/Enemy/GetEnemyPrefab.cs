using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This script is on homeScene, must add the reference between prefab and type
/// </summary>
public class GetEnemyprefab : MonoBehaviour
{
    [SerializeField] private List<EnemyPrefabMatch> EnemyPrebabs;

    public GameObject GetPrefab(EnemyTypes enemy)
    {
        foreach (EnemyPrefabMatch match in EnemyPrebabs)
        {
            if (match.enemy == enemy)
            {
                return match.enemyPrefab;
            }
        }
        return null;
    }
}

[System.Serializable]
public class EnemyPrefabMatch
{
    public EnemyTypes enemy;
    public GameObject enemyPrefab;
}
