using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour, IDamageable
{
    [SerializeField] private UnityEvent _onDamagedEvent;

    private bool _isAlive;

    private void Start()
    {
        _isAlive = true;
    }

    public void TakeDamage()
    {
        Debug.Log("Игра окончена!");

        _onDamagedEvent?.Invoke();

        _isAlive = false;
    }

    public bool GetAliveStatus()
    {
        return _isAlive;
    }
}
