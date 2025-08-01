using System;
using System.Collections;
using UnityEngine;

public class MeshBlink : MonoBehaviour
{
    [SerializeField] private bool _blinkOnce = true;
    [SerializeField] private bool _blinkAtStart = false;
    [SerializeField] [Min(0)] private float _blinkTime = 0.1f;

    private Coroutine routine = null;
    private MeshRenderer mesh;

    IEnumerator BlinkRoutine()
    {
        do
        {
            mesh.enabled = true;
            yield return new WaitForSeconds(_blinkTime);
            mesh.enabled = false;
        } while (!_blinkOnce);
        StopCurrentRoutine();
    }

    private void StopCurrentRoutine()
    {
        if(routine == null){return;}
        StopCoroutine(routine);
        routine = null;
    }
    private void OnDestroy()
    {
        if(routine == null){return;}
        StopCurrentRoutine();
    }

    private void Start()
    {
        mesh = transform.GetComponent<MeshRenderer>();
        if(!mesh){return;}

        if (_blinkAtStart)
        {
            StartBlink();
        }
    }

    public void StartBlink()
    {
        if(routine != null){return;}
        routine = StartCoroutine(BlinkRoutine());
    }
}