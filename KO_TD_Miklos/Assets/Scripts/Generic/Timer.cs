using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    [SerializeField] [Min(0)] private float _time;
    [SerializeField] private UnityEvent OnTimeFinished;
    [SerializeField] private bool _startOnCreation;

    private Coroutine routine;

    private void Start()
    {
        if(_startOnCreation){InitTimer();}
    }

    private void OnDestroy()
    {
        if(routine == null){return;}
        StopCoroutine(routine);
    }

    private IEnumerator TimerRoutine()
    {
        yield return new WaitForSeconds(_time);
        OnTimeFinished?.Invoke();
    }

    public void InitTimer()
    {
        routine = StartCoroutine(TimerRoutine());
    }
}