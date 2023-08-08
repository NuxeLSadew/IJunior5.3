using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private float _smoothValue = 0.1f;
    [SerializeField] private float _offsetByDirectionValue = 3;

    private Vector3 _offset = new Vector3(0, 1, -10);
    private Vector3 _offsetByDirection;

    private void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            _offsetByDirection.x = _offsetByDirectionValue;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            _offsetByDirection.x = -_offsetByDirectionValue;
        }
    }

    private void LateUpdate()
    {
        Vector3 desiredPosition = transform.position + _offset + _offsetByDirection;
        Vector3 smoothedPosition = Vector3.Lerp(_camera.transform.position, desiredPosition, _smoothValue);

        _camera.transform.position = smoothedPosition;
    }
}
