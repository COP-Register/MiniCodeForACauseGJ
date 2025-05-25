using UnityEngine;

public class AbilitySwitchTrigger : MonoBehaviour
{
    [SerializeField] private AudioClip pickupSound;
    
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        var _playerInfoScript = other.GetComponent<PlayerLevelInfo>();
        var uiScript = GameObject.Find("IngameUI").GetComponent<IngameUI>();
        uiScript.ShowMessageBox(_playerInfoScript.GetCurrentLevel());
        uiScript.StopTimer();
        _playerInfoScript.IncreaseLevel();
        SoundManager.Instance.PlaySound(pickupSound, transform, 100);
        Destroy(GameObject.Find("AbilitySwitcher"));
    }
}
