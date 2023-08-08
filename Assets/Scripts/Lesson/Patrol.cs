using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Patrol : MonoBehaviour, IHasVelocity
{
    [SerializeField] private float _speed;
    [SerializeField] private ObstacleChecker _rightWallChecker;
    [SerializeField] private ObstacleChecker _leftWallChecker;
    [SerializeField] private ObstacleChecker _rightGroundChecker;
    [SerializeField] private ObstacleChecker _leftGroundChecker;

    private Rigidbody2D _rigidbody2D;
    private Vector2 _velocity;
    private MoveDirection _moveDirection;
    private bool _isRightWayBlocked;
    private bool _isLeftWayBlocked;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _isRightWayBlocked = CheckWayBlocker(_rightWallChecker, _rightGroundChecker);
        _isLeftWayBlocked = CheckWayBlocker(_leftWallChecker, _leftGroundChecker);

        if (_isRightWayBlocked)
        {
            _moveDirection = MoveDirection.Left;
        }

        if (_isLeftWayBlocked)
        {
            _moveDirection = MoveDirection.Right;
        }
    }

    private void FixedUpdate()
    {
        switch (_moveDirection)
        {
            case MoveDirection.Right:
                _velocity.x = _speed;
                break;

            case MoveDirection.Left:
                _velocity.x = -_speed;
                break;
        }

        _rigidbody2D.velocity = _velocity;
    }

    private bool CheckWayBlocker(ObstacleChecker wallChecker, ObstacleChecker groundChecker)
    {
        return wallChecker.IsTriggered || groundChecker.IsTriggered == false;
    }

    public Vector2 GetVelocity()
    {
        return _velocity;
    }

    enum MoveDirection
    {
        Right,
        Left
    }
}
