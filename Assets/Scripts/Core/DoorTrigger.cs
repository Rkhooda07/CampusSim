using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public Transform teleportTarget;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (teleportTarget != null)
            {
                other.transform.position = teleportTarget.position;
            }
            else
            {
                Debug.LogWarning("No teleport target assigned to door.");
            }
        }
    }
}