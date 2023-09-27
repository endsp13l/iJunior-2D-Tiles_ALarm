using UnityEngine;

public class AlarmZone : MonoBehaviour
{
    [SerializeField] private bool isInvasion;

    public bool IsInvasion => isInvasion;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.GetComponent<CharacterMovement>())
        {
           isInvasion = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<CharacterMovement>())
        {
            isInvasion = false;
        }
    }
}
