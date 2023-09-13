using UnityEngine;

public class ObjectCameraRotator : MonoBehaviour
{
    [SerializeField] private RectTransform _transform;

    private Vector3 _mainCameraForward;

    private void Awake()
    {
        _mainCameraForward = Camera.main.transform.forward * 1000;
    }

    private void LateUpdate()
    {
        _transform.LookAt(_mainCameraForward);
    }
}

