using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class ColliderDisabler : MonoBehaviour
{
    private Collider2D _collider;

    private void Start()
    {
        _collider = GetComponent<Collider2D>();
    }

    public void DisableCollider()
    {
        _collider.enabled = false;
    }
}
