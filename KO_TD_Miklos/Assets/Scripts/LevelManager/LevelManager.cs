using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Transform _enemiesParent;
    [SerializeField] private TurretDataSO.Turret[] _turretsForThisLevel;
    [SerializeField] private GameObject _winView;
    [SerializeField] private GameObject _loseView;
    
    private RunWave[] waves;
    private int wavesCompleted = 0;
    private ScenesManager SM;
    public void GameLose()
    {
        print("you lose the game");
        Time.timeScale = 0f;
        _loseView.SetActive(true);
    }

    public void YouWin()
    {
        print("you win");
        Time.timeScale = 0f;
        _winView.SetActive(true);
    }

    public void StartMatch()
    {
        foreach (RunWave wave in waves)
        {
            wave.StartRoutine();
        }
    }

    public void ToMainMenu()
    {
        SM.UnloadAScene(SceneEnum.HomeScene);
        
    }

    private void Start()
    {
        waves = FindObjectsOfType<RunWave>();
        foreach (RunWave wave in waves)
        {
            wave._waveComplete.AddListener(WaveCompleted);
        }

        Time.timeScale = 1f;
        SM = FindObjectOfType<ScenesManager>();
        SM.LoadAScene(SceneEnum.LevelGUI);
    }
    
    private void WaveCompleted()
    {
        wavesCompleted++;
    }

    private void Update()
    {
        if(wavesCompleted < waves.Length){return;}

        if (_enemiesParent.childCount == 0)
        {
            YouWin();
            wavesCompleted = -1;
        }
    }

    public TurretDataSO.Turret[] GetTurretsForThisLevel()
    {
        return _turretsForThisLevel;
    }
}
