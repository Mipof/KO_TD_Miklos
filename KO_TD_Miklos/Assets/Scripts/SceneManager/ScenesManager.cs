using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public void LoadAScene(SceneEnum scene)
    {
        print(scene.ToString());
        SceneManager.LoadSceneAsync(scene.ToString(), LoadSceneMode.Additive);
    }

    public void UnloadAScene(SceneEnum scene)
    {
        SceneManager.UnloadSceneAsync(scene.ToString());
    }

    [ContextMenu("load")]
    public void TestLoadScene()
    {
        LoadAScene(SceneEnum.FirstLeveScene);
    }

    [ContextMenu("unload")]
    public void TestUnloadScene()
    {
        UnloadAScene(SceneEnum.FirstLeveScene);
    }
}
