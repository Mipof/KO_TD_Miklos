using UnityEngine;
[CreateAssetMenu(menuName = "Enemy", fileName = "newEnemy")]
public class EnemyDataSo : ScriptableObject
{
    [System.Serializable]
    public struct Enemy
    {
        public EnemyTypes type;
        public int currencyPerKill;
        public float maxHealth;
        public float damagePerCollision;
        public float speed;
        public float threshold; //of how to accurate will be follow points
    }

    [SerializeField] public Enemy enemy;
}
