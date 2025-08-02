using UnityEngine;

public class LoadAScene : MonoBehaviour
{
    private ScenesManager SM;
    [SerializeField] private SceneEnum _sceneToLoad;
    [SerializeField] private bool _loadAtStart;

    [SerializeField] [Tooltip("Only fill if want to unload scene on load")]
    private SceneEnum[] _scenesToUnloadOnLoad;
    private void Start()
    {
        SM = FindObjectOfType<ScenesManager>();
        if(_loadAtStart){LoadTheScene();}
    }

    public void LoadTheScene()
    {
        foreach (SceneEnum scene in _scenesToUnloadOnLoad)
        {
            SM.UnloadAScene(scene);
        }
        SM.LoadAScene(_sceneToLoad);
    }
}
