using UnityEngine;

public class LevelExit : MonoBehaviour
{
    private SceneSwitcher sceneSwitcher;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        sceneSwitcher = GameObject.Find("SceneSwitcher").GetComponent<SceneSwitcher>();
        sceneSwitcher.LoadNextScene();
        Destroy(GameObject.Find("AbilitySwitcher"));
    }
}
