using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public float DelayForNextScene = 5f;
    public bool IsFillerScene;


    private string _currentSceneName;
    private string _nextSceneName;


    private void Start()
    {
        _currentSceneName = SceneManager.GetActiveScene().name;
        SetNextScene();
        if(IsFillerScene) LoadNextScene();
        Cursor.lockState = CursorLockMode.Locked;
    }

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

    private void SetNextScene()
    {
        switch (_currentSceneName)
        {
            case "Level_0_Titel":
                _nextSceneName = "Level_0";
                break;
            case "Level_0":
                _nextSceneName = "Level_1_Titel";
                break;
            case "Level_1_Titel":
                _nextSceneName = "Level_1";
                break;
            case "Level_1":
                _nextSceneName = "Level_2_Titel";
                break;
            case "Level_2_Titel":
                _nextSceneName = "Level_2";
                break;
            case "Level_2":
                _nextSceneName = "Level_3_Titel";
                break;
            case "Level_3_Titel":
                _nextSceneName = "Level_3";
                break;
            case "Level_3":
                _nextSceneName = "Level_3_End";
                break;
            case "Level_3_End":
                _nextSceneName = "Level_3_Thank";
                break;
        }
    }
}
