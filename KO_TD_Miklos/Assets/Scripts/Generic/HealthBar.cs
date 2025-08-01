using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Transform _lookAt;
    [SerializeField] private Canvas _canvas;
    [SerializeField] private Slider _slider;

    private void Start()
    {
        _lookAt = Camera.main.transform;
        _canvas.worldCamera = Camera.main;
    }

    private void Update()
    {
        transform.LookAt(_lookAt);
    }
}
