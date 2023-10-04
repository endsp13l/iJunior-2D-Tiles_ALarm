using UnityEngine;
using UnityEngine.Events;

public class AlarmZone : MonoBehaviour
{
    private UnityEvent _movementDetected = new UnityEvent();
    private UnityEvent _zoneCleared = new UnityEvent();

    public event UnityAction MovementDetected
    {
        add => _movementDetected.AddListener(value);
        remove => _movementDetected.RemoveListener(value);
    }

    public event UnityAction ZoneCleared
    {
        add => _zoneCleared.AddListener(value);
        remove => _zoneCleared.RemoveListener(value);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<CharacterMovement>())
        {
            _movementDetected?.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<CharacterMovement>())
        {
            _zoneCleared?.Invoke();
        }
    }
}