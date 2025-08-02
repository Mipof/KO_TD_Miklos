using UnityEngine;

/// <summary>
/// For make visible (or not) the effective zone of the turrets
///
/// NOT IMPLEMETED YET
/// </summary>
public class ChangeZoneView : MonoBehaviour
{
    [SerializeField] private MeshRenderer _renderer;

    [ContextMenu("change")]
    public void ChangeView()
    {
        _renderer.enabled = !_renderer.enabled;
    }
}
