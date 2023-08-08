using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class ObstacleChecker : MonoBehaviour
{
    public bool IsTriggered { get; private set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Obstacle>(out _))
        {
            IsTriggered = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Obstacle>(out _))
        {
            IsTriggered = false;
        }
    }
}
