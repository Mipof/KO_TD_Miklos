using UnityEngine;

public class Currency : MonoBehaviour
{
    private RunWave[] waves;

    private void Start()
    {
        waves = FindObjectsOfType<RunWave>();
        foreach (RunWave runWave in waves)
        {
            runWave.OnEnemyCreation.AddListener(GetEnemyDestroyListener);
        }
    }

    private void GetEnemyDestroyListener(GameObject enemy)
    {
        if (enemy.TryGetComponent(out DestroyGO dgo))
        {
            dgo.OnDestoy.AddListener(AddCurrencyOnEnemyDeath);
        }
    }

    private void AddCurrencyOnEnemyDeath(GameObject enemy)
    {
        print("an enemy dead");
        if (enemy.TryGetComponent(out DestroyGO dgo))
        {
            dgo.OnDestoy.RemoveListener(AddCurrencyOnEnemyDeath);
        }
    }
}
