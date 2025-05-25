using System;
using UnityEngine;

public class RedLight : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Color color = Color.red;
    [SerializeField] private AudioClip clip;
    private Light _light;
    private Color _lastColor;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _light = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        _lastColor = _light.color;
        _light.color = color;
        _light.intensity = 2f;
        SoundManager.Instance.PlaySound(clip, transform, 100);
    }

    private void OnTriggerExit(Collider other)
    {
        _light.color = _lastColor;
        _light.intensity = 1f;
    }
}
