using InputSystem;
using StarterAssets;
using UnityEngine;

public class StickToPlatform : MonoBehaviour
{
    private FirstPersonController _controller;
    private StarterAssetsInputs _input;
    public Vector3 _velocityToAdd;
    void Start()
    {
        _controller = GetComponent<FirstPersonController>();
        _input = GetComponent<StarterAssetsInputs>();
        _velocityToAdd = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        _controller.PlatformVelocity = _input.jump ? Vector3.zero : _velocityToAdd;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.CompareTag("MovingPlatform") && !_input.jump)
        {
            _velocityToAdd = hit.gameObject.GetComponent<VelocityCalculator>().GetVelocity();
        }
        else
        {
            _velocityToAdd = Vector3.zero;
        }
    }
}
