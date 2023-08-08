using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class SpriteMirrorer : MonoBehaviour
{
    [SerializeField] private Transform _transform;

    private Rigidbody2D _rigidbody2D;
    private Quaternion _toRightRotation = new Quaternion(0, 0, 0, 0);
    private Quaternion _toLeftRotation = new Quaternion(0, 180, 0 , 0);

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (_rigidbody2D.velocity.x > 0)
        {
            _transform.rotation = _toRightRotation;
        }
        else if (_rigidbody2D.velocity.x < 0)
        {
            _transform.rotation = _toLeftRotation;
        }
    }
}