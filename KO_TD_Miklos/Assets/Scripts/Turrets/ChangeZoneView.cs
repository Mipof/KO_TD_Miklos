using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeZoneView : MonoBehaviour
{
    [SerializeField] private MeshRenderer _renderer;

    [ContextMenu("change")]
    public void ChangeView()
    {
        _renderer.enabled = !_renderer.enabled;
    }
}
