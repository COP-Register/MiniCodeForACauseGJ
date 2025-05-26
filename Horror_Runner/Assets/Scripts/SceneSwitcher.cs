using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class SceneSwitcher : MonoBehaviour
{
    public float DelayForNextScene = 5f;
    public bool IsFillerScene;
#if UNITY_EDITOR
    public SceneAsset _currentScene;
    public SceneAsset _nextScene;
#endif

    private string _currentSceneName;
    private string _nextSceneName;


    private void Start()
    {
        if(IsFillerScene) LoadNextScene();
    }

#if UNITY_EDITOR
    private void OnValidate()
    {
        if (_currentScene != null && _nextScene != null)
        {
            string pathCurrent = AssetDatabase.GetAssetPath(_currentScene);
            string pathNext = AssetDatabase.GetAssetPath(_nextScene);
            _currentSceneName = System.IO.Path.GetFileNameWithoutExtension(pathCurrent);
            _nextSceneName = System.IO.Path.GetFileNameWithoutExtension(pathNext);
        }
    }
#endif

    public void ReloadCurrentScene()
    {
        SceneManager.LoadScene(_currentSceneName);
    }

    public void LoadNextScene()
    {
        StartCoroutine(TriggerLoad());
    }

    IEnumerator TriggerLoad()
    {
        yield return new WaitForSeconds(DelayForNextScene);
        SceneManager.LoadScene(_nextSceneName);
    }
}
