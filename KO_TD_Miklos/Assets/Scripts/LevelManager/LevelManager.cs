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
        Time.timeScale = 0f;
        _loseView.SetActive(true);
    }

    public void YouWin()
    {
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

    private void Start()
    {
        waves = FindObjectsOfType<RunWave>();
        foreach (RunWave wave in waves)
        {
            //set a listener to all wave routines when completed
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
        //Will check first if the waves already finish, next, check if still enemies in the scene
        if(wavesCompleted < waves.Length){return;}

        if (_enemiesParent.childCount == 0)
        {
            YouWin();
            //for entry only once
            wavesCompleted = -1;
        }
    }

    public TurretDataSO.Turret[] GetTurretsForThisLevel()
    {
        return _turretsForThisLevel;
    }
}
