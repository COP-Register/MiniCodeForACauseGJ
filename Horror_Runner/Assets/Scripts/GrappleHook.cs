using InputSystem;
using StarterAssets;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GrappleHook : MonoBehaviour
{
    private CharacterController _characterController;
    private FirstPersonController _firstPersonController;
    private StarterAssetsInputs _input;
    [SerializeField] private GameObject mainCamera;
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private LayerMask grappleLayer;
    [SerializeField] private float maxDistant = 50.0f;
    [SerializeField] private float grappleSpeed = 50.0f;
    private Vector3 _grapplePoint;
    private Vector3 _grappleDirection;
    private bool _isGrappling = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _firstPersonController = GetComponent<FirstPersonController>();
        _input = GetComponent<StarterAssetsInputs>();
        lineRenderer.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_input.jump && !_isGrappling)
        {
            if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out var hit, maxDistant, grappleLayer))
            {
                _grapplePoint = hit.point;
                _grappleDirection = _grapplePoint - transform.position;
                _isGrappling = true;
            }
        }
        
        if (_isGrappling)
        {
            _characterController.Move(_grappleDirection.normalized * (Time.deltaTime * grappleSpeed));
            _input.move = Vector2.zero;
            _firstPersonController.VerticalVelocity = 0.0f;
            if (_input.jump && !((_grapplePoint - transform.position).magnitude <= 3)) return;
            _isGrappling = false;
            lineRenderer.enabled = false;
            _grapplePoint = Vector3.zero;
            lineRenderer.enabled = false;
        }
    }

    void FixedUpdate()
    {
        if (_isGrappling)
        {
            lineRenderer .SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, _grapplePoint);
            lineRenderer.enabled = true;
        }
    }
}
