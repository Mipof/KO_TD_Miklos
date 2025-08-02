using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RunWave : MonoBehaviour
{
    [Header("DATA")][Space(15)]
    [SerializeField] private WaveSO _wave;
    
    [Header("OBJS")][Space(15)]
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private List<Transform> _waypoints;
    [SerializeField] private Transform _enemiesParent;

    [Header("EVENTS")][Space(15)]
    public UnityEvent _waveComplete;

    public UnityEvent<GameObject> OnEnemyCreation;


    private GetEnemyprefab getEnemyprefab;
    private Coroutine routine;
    

    private IEnumerator WaveRoutine()
    {
        int currentIndex = 0;
        WaveSO.Wave currentWave = _wave.waves[currentIndex];
        yield return new WaitForSeconds(currentWave._delayBeforeStart);
        while (true)
        {
            GameObject prefab = getEnemyprefab.GetPrefab(currentWave._enemyType);
            int currentEnemy = 0;
            while (currentEnemy < currentWave._qty)
            {
                GameObject newEnemy = Instantiate(prefab, _spawnPoint.position, Quaternion.identity, _enemiesParent);
                if (newEnemy.TryGetComponent(out FollowPoints follow))
                {
                    follow.SetWaypoint(_waypoints);
                    follow.StartFollowing();
                }
                else
                {
                    Destroy(newEnemy);
                }
                OnEnemyCreation?.Invoke(newEnemy);

                currentEnemy++;
                yield return new WaitForSeconds(currentWave._delayBetweenEnemies);
            }

            if (currentIndex + 1 > _wave.waves.Length - 1)
            {
                _waveComplete?.Invoke();
                print("wave complete");
                yield break;
            }

            currentIndex++;
            currentWave = _wave.waves[currentIndex];
        }
    }

    private void OnDestroy()
    {
        if (routine != null)
        {
            StopCoroutine(routine);
        }
    }

    private void Start()
    {
        getEnemyprefab = FindObjectOfType<GetEnemyprefab>();
    }

    [ContextMenu("start")]
    public void StartRoutine()
    {
        routine = StartCoroutine(WaveRoutine());
    }
}
