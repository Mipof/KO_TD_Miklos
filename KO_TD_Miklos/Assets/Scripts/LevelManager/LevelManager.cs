using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Transform _enemiesParent;
    
    private RunWave[] waves;
    private int wavesCompleted = 0;
    public void GameLose()
    {
        print("you lose the game");
        Time.timeScale = 0f;
    }

    public void YouWin()
    {
        print("you win");
        Time.timeScale = 0f;
    }

    private void Start()
    {
        waves = FindObjectsOfType<RunWave>();
        foreach (RunWave wave in waves)
        {
            wave._waveComplete.AddListener(WaveCompleted);
        }
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
}
