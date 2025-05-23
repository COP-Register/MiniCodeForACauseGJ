using UnityEngine;

public class ObjectRotatorAndTranslator : MonoBehaviour
{
    [Header("Rotation")]
    
    [Tooltip("Rotation Local X")]
    [SerializeField] private bool rotateLocalX = false;
    
    [Tooltip("Rotation Local X Speed")]
    [SerializeField] private float rotateLocalXSpeed = 10f;
    
    [Space(10)]
    [Tooltip("Rotation Local Y")]
    [SerializeField] private bool rotateLocalY = false;
    
    [Tooltip("Rotation Local Y Speed")]
    [SerializeField] private float rotateLocalYSpeed = 10f;
    
    [Space(10)]
    [Tooltip("Rotation Local Z")]
    [SerializeField] private bool rotateLocalZ = false;
    
    [Tooltip("Rotation Local Z Speed")]
    [SerializeField] private float rotateLocalZSpeed = 10f;
    
    [Header("Translation")]
    [Tooltip("Translation Local X")]
    [SerializeField] private bool translateLocalX = false;
    
    [Tooltip("Translation Local X Speed")]
    [SerializeField] private float translateLocalXSpeed = 10f;
    
    [Tooltip("Translation Local X Distance")]
    [SerializeField] private float translateLocalXDistance = 10f;
    
    [Space(10)]
    [Tooltip("Translation Local Y")]
    [SerializeField] private bool translateLocalY = false;
    
    [Tooltip("Translation Local Y Speed")]
    [SerializeField] private float translateLocalYSpeed = 10f;
    
    [Tooltip("Translation Local Y Distance")]
    [SerializeField] private float translateLocalYDistance = 10f;
    
    [Space(10)]
    [Tooltip("Translation Local Z")]
    [SerializeField] private bool translateLocalZ = false;
    
    [Tooltip("Translation Local Z Speed")]
    [SerializeField] private float translateLocalZSpeed = 10f;
    
    [Tooltip("Translation Local Z Distance")]
    [SerializeField] private float translateLocalZDistance = 10f;

    private Vector3 _startPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        ApplyRotation();
        ApplyTranslation();
    }

    private void ApplyRotation()
    {
        float x = rotateLocalX ? rotateLocalXSpeed * Time.deltaTime : 0f;
        float y = rotateLocalY ? rotateLocalYSpeed * Time.deltaTime : 0f;
        float z = rotateLocalZ ? rotateLocalZSpeed * Time.deltaTime : 0f;

        transform.Rotate(new Vector3(x, y, z), Space.Self);
    }

    private void ApplyTranslation()
    {
        Vector3 offset = Vector3.zero;
        
        if (translateLocalX)
            offset += transform.right * Mathf.Sin(Time.time * translateLocalXSpeed) * translateLocalXDistance;

        if (translateLocalY)
            offset += transform.up * Mathf.Sin(Time.time * translateLocalYSpeed) * translateLocalYDistance;

        if (translateLocalZ)
            offset += transform.forward * Mathf.Sin(Time.time * translateLocalZSpeed) * translateLocalZDistance;

        transform.localPosition = _startPos + offset;
    }
}
