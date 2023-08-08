using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour, IHasVelocity
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpHeight;
    [SerializeField] private ObstacleChecker _groundChecker;
    [SerializeField] private ObstacleChecker _rightWallChecker;
    [SerializeField] private ObstacleChecker _leftWallChecker;

    private Rigidbody2D _rigidbody2D;
    private Vector2 _velocity;
    private float _maxfallSpeed = -5;
    private float _jumpForce = -2;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space) && _groundChecker.IsTriggered)
        {
            _velocity.y = Mathf.Sqrt(_jumpHeight * _jumpForce * Physics.gravity.y);
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D) && _rightWallChecker.IsTriggered == false)
        {
            _velocity.x = _speed;
        }
        else if (Input.GetKey(KeyCode.A) && _leftWallChecker.IsTriggered == false)
        {
            _velocity.x = -_speed;
        }
        else
        {
            _velocity.x = 0;
        }

        if (_groundChecker.IsTriggered && _velocity.y < 0)
        {
            _velocity.y = 0;
        }
        else if (_groundChecker.IsTriggered == false)
        {
            _velocity += Physics2D.gravity * Time.deltaTime;

            if (_velocity.y < _maxfallSpeed)
            {
                _velocity.y = _maxfallSpeed;
            }
        }

        _rigidbody2D.velocity = _velocity;
    }

    public Vector2 GetVelocity()
    {
        return _velocity;
    }
}
