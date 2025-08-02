using System;
using UnityEngine;
[CreateAssetMenu(menuName = "Waves", fileName = "NewWave")]
public class WaveSO : ScriptableObject
{
    [Serializable]
    public struct Wave
    {
        public float _delayBeforeStart;
        public EnemyTypes _enemyType;
        public int _qty;
        public float _delayBetweenEnemies;
    }

    [SerializeField] public Wave[] waves;
}
