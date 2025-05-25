using UnityEngine;

public class HideMessageBoxTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        GameObject.Find("IngameUI").GetComponent<IngameUI>().HideMessageBox();
    }
}
