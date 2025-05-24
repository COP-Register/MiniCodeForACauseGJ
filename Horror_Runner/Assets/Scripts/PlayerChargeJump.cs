using System;
using InputSystem;
using StarterAssets;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerChargeJump : MonoBehaviour
{
    // timeout deltatime
    private float _jumpTimeoutDelta;
    private float _fallTimeoutDelta;

    private FirstPersonController _fpController;
    private StarterAssetsInputs _input;
    private GameObject _mainCamera;

    private float _jumpLoad = 0.0f;
    [SerializeField] private float jumpLoadMax = 20f;
    [SerializeField] private float chargeTime = 20f;
    
    private Vector3 _lastPosition;
    private const float Tolerance = 0.01f;
    [SerializeField] private float jumpTimer;
    [SerializeField] private bool isJumping = false;

    //private bool _isLoading = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        _input = GetComponent<StarterAssetsInputs>();
        _fpController = GetComponent<FirstPersonController>();
        // reset our timeouts on start
        _jumpTimeoutDelta = _fpController.JumpTimeout;
        _fallTimeoutDelta = _fpController.FallTimeout;
        _lastPosition = transform.position;
    }

    // Update is called once per frame
    private void Update()
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

            // Loading Jump
            if (_input.jump && _jumpTimeoutDelta <= 0.0f)
            {
                // the square root of H * -2 * G = how much velocity needed to reach desired height
                // _fpController.VerticalVelocity = Mathf.Sqrt(_fpController.JumpHeight * -2f * _fpController.Gravity);
                if (_jumpLoad <= jumpLoadMax)
                {
                    _jumpLoad += (chargeTime * Time.deltaTime);
                }
            }

            if (_input.jump == false && _jumpLoad >= 0.1f)
            {
                _fpController.VerticalVelocity = Mathf.Sqrt(_fpController.JumpHeight * -2f * _fpController.Gravity * _jumpLoad);
                _jumpLoad = 0.0f;
                jumpTimer = 0.5f;
                isJumping = true;
            }

            // jump timeout
            if (_jumpTimeoutDelta >= 0.0f)
            {
                _jumpTimeoutDelta -= Time.deltaTime;
            }
            
            isJumping = false;
        }
        else
        {
            if (jumpTimer >= 0.0f)
            {
                jumpTimer -= Time.deltaTime;
            }
            
            if (Math.Abs(transform.position.y - _lastPosition.y) < Tolerance  && jumpTimer <= 0.0f)
            {
                _fpController.VerticalVelocity = -2f;
            }
            
            _lastPosition = transform.position;
            
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
