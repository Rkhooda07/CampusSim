using UnityEngine;

public class ZoneArea : MonoBehaviour
{
    [SerializeField] private string zoneName;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Pet"))
            return;

        ZoneManager.Instance.EnterZone(zoneName);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Pet"))
            return;

        ZoneManager.Instance.ExitZone(zoneName);
    }
}