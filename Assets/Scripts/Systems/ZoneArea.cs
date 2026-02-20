using UnityEngine;

public class ZoneArea : MonoBehaviour
{
    public enum ZoneCategory
    {
        Library,
        Cafe,
        Academic,
        Ground
    }

    [Header("Zone Settings")]
    [SerializeField] private string zoneName; // kept for UI display
    [SerializeField] private ZoneCategory zoneCategory;

    public string ZoneName => zoneName;
    public ZoneCategory Category => zoneCategory;

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