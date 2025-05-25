using UnityEngine;

public class AbilitySwitchTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        var _playerInfoScript = other.GetComponent<PlayerLevelInfo>();
        GameObject.Find("IngameUI").GetComponent<IngameUI>().ShowMessageBox(_playerInfoScript.GetCurrentLevel());
        _playerInfoScript.IncreaseLevel();
        Destroy(GameObject.Find("AbilitySwitcher"));
    }
}
