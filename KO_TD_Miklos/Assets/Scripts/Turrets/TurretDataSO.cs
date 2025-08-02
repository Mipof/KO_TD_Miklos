using UnityEngine;
[CreateAssetMenu(menuName = "Turrets", fileName = "newTurret")]
public class TurretDataSO : ScriptableObject
{
    [System.Serializable]
    public struct Turret
    {
        public TurretType type;
        public string turretName;
        public int cost;
        public float delayFirstShot;
        public float delayNextShot;
        public float damagePerShot;
        public int maxEnemies;
        public bool canBeUpgraded;
        public TurretDataSO upgradedTurret;
        public bool isUpgradeFromOther;
        public GameObject prefab;

    }

    [SerializeField] public Turret turret;
}