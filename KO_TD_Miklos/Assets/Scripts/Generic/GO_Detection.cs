using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GODetection : MonoBehaviour
{
    [Header("EVENTS")][Space(15)]
    [SerializeField] private UnityEvent<GameObject> OnGOEnter;
    [SerializeField] private UnityEvent<GameObject> OnGoExit;

    [Header("STATS")][Space(15)]
    [SerializeField] private List<string> _tagList;

    private void OnTriggerEnter(Collider other)
    {
        foreach (string tag in _tagList)
        {
            if(!other.CompareTag(tag)){continue;}
            OnGOEnter?.Invoke(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        foreach (string tag in _tagList)
        {
            if(!other.CompareTag(tag)){continue;}
            OnGoExit?.Invoke(other.gameObject);
        }
    }
}
