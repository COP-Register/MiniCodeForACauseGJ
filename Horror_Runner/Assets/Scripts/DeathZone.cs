using System;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        GameObject.Find("SceneSwitcher").GetComponent<SceneSwitcher>().ReloadTitleScene();
    }
}
