using UnityEngine;

[RequireComponent(typeof(IHasVelocity))]
public class MoveAnimationStatesSetter : MonoBehaviour
{
    private const string VelocityY = nameof(VelocityY);
    private const string VelocityX = nameof(VelocityX);

    [SerializeField] private Animator _animator;

    private IHasVelocity _hasVelocity;

    private void Awake()
    {
        _hasVelocity = GetComponent<IHasVelocity>();
    }

    private void Update()
    {
        _animator.SetFloat(VelocityX, _hasVelocity.GetVelocity().x);
        _animator.SetFloat(VelocityY, _hasVelocity.GetVelocity().y);
    }
}
