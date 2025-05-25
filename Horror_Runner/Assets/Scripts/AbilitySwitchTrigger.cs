using UnityEngine;

public class AbilitySwitchTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        var _playerInfoScript = other.GetComponent<PlayerLevelInfo>();
        var uiScript = GameObject.Find("IngameUI").GetComponent<IngameUI>();
        uiScript.ShowMessageBox(_playerInfoScript.GetCurrentLevel());
        uiScript.StopTimer();
        _playerInfoScript.IncreaseLevel();
        Destroy(GameObject.Find("AbilitySwitcher"));
    }
}
