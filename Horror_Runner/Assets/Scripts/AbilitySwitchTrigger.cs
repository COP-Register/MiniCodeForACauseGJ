using System;
using UnityEngine;

public class AbilitySwitchTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        other.GetComponent<PlayerLevelInfo>().IncreaseLevel();
        Destroy(GameObject.Find("AbilitySwitcher"));
    }
}
