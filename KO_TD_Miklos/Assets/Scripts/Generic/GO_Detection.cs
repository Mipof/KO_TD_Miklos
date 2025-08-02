using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GODetection : MonoBehaviour
{
    [Header("EVENTS")][Space(15)]
    [SerializeField] private UnityEvent<GameObject> OnGOEnter;
    [SerializeField] private UnityEvent<GameObject> OnGoExit;
    [SerializeField] private UnityEvent<GameObject> OnStay;
    [SerializeField] private bool DisableAfterCollision;
    private bool collision = false;

    [Header("STATS")][Space(15)]
    [SerializeField] private List<string> _tagList;

    private void OnTriggerEnter(Collider other)
    {
        foreach (string tag in _tagList)
        {
            if(!other.CompareTag(tag) || (DisableAfterCollision && collision) ){continue;}
            OnGOEnter?.Invoke(other.gameObject);
            collision = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        foreach (string tag in _tagList)
        {
            if(!other.CompareTag(tag) || (DisableAfterCollision && collision) ){continue;}
            OnGoExit?.Invoke(other.gameObject);
            collision = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        foreach (string tag in _tagList)
        {
            if(!other.CompareTag(tag) || (DisableAfterCollision && collision) ){continue;}
            OnStay?.Invoke(other.gameObject);
            collision = true;
        }
    }
}
