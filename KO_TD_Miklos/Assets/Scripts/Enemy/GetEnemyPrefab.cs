using System.Collections.Generic;
using UnityEngine;

public class GetEnemyprefab : MonoBehaviour
{
    [SerializeField] private List<EnemyPrefabMatch> EnemyPrebabs;

    public GameObject GetPrefab(EnemyEnum enemy)
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
    public EnemyEnum enemy;
    public GameObject enemyPrefab;
}
