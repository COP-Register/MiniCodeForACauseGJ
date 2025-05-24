using InputSystem;
using StarterAssets;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerJumpAndDash : MonoBehaviour
{
    [SerializeField] private float BounceStrength = 1f;

    private FirstPersonController _fpController;
    private StarterAssetsInputs _input;
    private GameObject _mainCamera;
    public float _dashCooldownBase = 1f;
    public float _dashCooldownCurrent = 0f;
    public float _dashDurationBase = .5f;
    public float _dashDuration = 0f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _input = GetComponent<StarterAssetsInputs>();
        _fpController = GetComponent<FirstPersonController>();
        // reset our timeouts on start
    }

    // Update is called once per frame
    void Update()
    {
        _dashCooldownCurrent -= Time.deltaTime;
        Dash();
        
        if (_fpController.IsDashing)
        {
            _dashDuration -= Time.deltaTime;
            if (_dashDuration <= 0f)
            {
                _fpController.IsDashing = false;
                _dashDuration = _dashDurationBase;
            }
        }
    }

    private void Dash()
    {
        if (SceneManager.GetActiveScene().name != "Level_3" || _fpController.IsGrounded()) return;
        
        // Dash
        if (_input.jump && _dashCooldownCurrent <= 0f)
        {
            _fpController.IsDashing = true;
            var facingDir = transform.forward * 1.5f;
            //_fpController.BounceVelocity += facingDir * 15;
            _fpController.BounceVelocity = facingDir * 15;
            _dashCooldownCurrent = _dashCooldownBase;
        }

        if (_fpController.IsDashing)
        {
            _fpController.VerticalVelocity = 0f;
        }
    }
    
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (enabled)
        {
            if (_fpController.VerticalVelocity < 0.0f)
            {
                _fpController.VerticalVelocity = -2f;
            }
        
            Vector3 dir;
            if (hit.collider.CompareTag("BouncingPlatform"))
            {
                _fpController.VerticalVelocity = 2f;
                dir = hit.transform.forward.normalized;
                dir *= BounceStrength;
            }
            else
            {
                dir = Vector3.zero;
            }
            _fpController.BounceVelocity = dir;
        }
    }
}
