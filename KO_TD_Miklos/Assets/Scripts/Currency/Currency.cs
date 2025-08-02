using TMPro;
using UnityEngine;

public class Currency : MonoBehaviour
{
    [SerializeField] private int _startCurrency;
    [SerializeField] private TextMeshProUGUI _currencyText;
    private RunWave[] waves;

    private int currentCurrency;

    private void Start()
    {
        waves = FindObjectsOfType<RunWave>();
        currentCurrency = _startCurrency;
        UpdateGUI();
        foreach (RunWave runWave in waves)
        {
            //Subscribe to every enemy created
            runWave.OnEnemyCreation.AddListener(GetEnemyDestroyListener);
        }
    }

    private void UpdateGUI()
    {
        _currencyText.text = $"${currentCurrency}";
    }

    public void AddCurrency(int _currency)
    {
        currentCurrency += _currency;
        UpdateGUI();
    }

    private void GetEnemyDestroyListener(GameObject enemy)
    {
        //Subscribe to DestroyGo event of every enemy
        if (enemy.TryGetComponent(out DestroyGO dgo))
        {
            dgo.OnDestoy.AddListener(AddCurrencyOnEnemyDeath);
        }
    }

    public bool Purchase(int cost)
    {
        if (currentCurrency < cost) return false;
        currentCurrency -= cost;
        UpdateGUI();
        return true;
    }

    private void AddCurrencyOnEnemyDeath(GameObject enemy)
    {
        if (enemy.TryGetComponent(out EnemyData data))
        {
            AddCurrency(data.GetEnemyData().enemy.currencyPerKill);
        }
        if (enemy.TryGetComponent(out DestroyGO dgo))
        {
            dgo.OnDestoy.RemoveAllListeners();
        }
    }
}
