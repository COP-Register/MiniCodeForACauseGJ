using InputSystem;
using StarterAssets;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    // timeout deltatime
    private float _jumpTimeoutDelta;
    private float _fallTimeoutDelta;

    private FirstPersonController _fpController;
    private StarterAssetsInputs _input;
    private GameObject _mainCamera;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _input = GetComponent<StarterAssetsInputs>();
        _fpController = GetComponent<FirstPersonController>();
        // reset our timeouts on start
        _jumpTimeoutDelta = _fpController.JumpTimeout;
        _fallTimeoutDelta = _fpController.FallTimeout;
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
    }

    private void Jump()
    {
        if (_fpController.IsGrounded())
        {
            // reset the fall timeout timer
            _fallTimeoutDelta = _fpController.FallTimeout;

            // stop our velocity dropping infinitely when grounded
            if (_fpController.VerticalVelocity < 0.0f)
            {
                _fpController.VerticalVelocity = -2f;
            }

            // Jump
            if (_input.jump && _jumpTimeoutDelta <= 0.0f)
            {
                // the square root of H * -2 * G = how much velocity needed to reach desired height
                _fpController.VerticalVelocity = Mathf.Sqrt(_fpController.JumpHeight * -2f * _fpController.Gravity);
            }

            // jump timeout
            if (_jumpTimeoutDelta >= 0.0f)
            {
                _jumpTimeoutDelta -= Time.deltaTime;
            }
        }
        else
        {
            // reset the jump timeout timer
            _jumpTimeoutDelta = _fpController.JumpTimeout;

            // fall timeout
            if (_fallTimeoutDelta >= 0.0f)
            {
                _fallTimeoutDelta -= Time.deltaTime;
            }

            // if we are not grounded, do not jump
            _input.jump = false;
        }
    }
}
