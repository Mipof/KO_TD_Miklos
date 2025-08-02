using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Canvas _canvas;
    [SerializeField] private Slider _slider;

    private Transform _lookAt;

    private void Start()
    {
        _lookAt = Camera.main.transform;
        _canvas.worldCamera = Camera.main;
    }

    public void SetHealth(int health)
    {
        _slider.maxValue = health;
        _slider.value = health;
    }

    public void GetDamaged(float damage)
    {
        _slider.value -= damage;
        if (_slider.value < 0)
        {
            _slider.value = 0;
        }
    }

    private void Update()
    {
        transform.LookAt(_lookAt);
    }
}
