using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderTitel : MonoBehaviour
{
    [SerializeField] private string sceneName;
    [SerializeField] private float changeTimer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(ChangeScene());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(changeTimer);
        SceneManager.LoadScene(sceneName);
    }
}
