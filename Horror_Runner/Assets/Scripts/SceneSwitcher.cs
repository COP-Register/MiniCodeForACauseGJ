using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class SceneSwitcher : MonoBehaviour
{
    public float DelayForNextScene = 5f;
    public bool IsFillerScene;
    public SceneAsset _currentScene;
    public SceneAsset _nextScene;


    private void Start()
    {
        if(IsFillerScene) LoadNextScene();
    }

    public void ReloadCurrentScene()
    {
        SceneManager.LoadScene(_currentScene.name);
    }

    public void LoadNextScene()
    {
        StartCoroutine(TriggerLoad());
    }

    IEnumerator TriggerLoad()
    {
        yield return new WaitForSeconds(DelayForNextScene);
        SceneManager.LoadScene(_nextScene.name);
    }
}
