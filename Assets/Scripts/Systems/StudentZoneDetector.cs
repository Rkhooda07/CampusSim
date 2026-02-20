using UnityEngine;

public class StudentZoneDetector : MonoBehaviour
{
    private StudentPresence studentPresence;

    private void Awake()
    {
        studentPresence = GetComponent<StudentPresence>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        ZoneArea zone = other.GetComponent<ZoneArea>();
        if (zone == null) return;

        studentPresence.UpdateStatusByZone(zone.ZoneName);
    }

    private void Start()
    {
        // Ensure correct status at scene start if already inside zone
        Collider2D[] hits = Physics2D.OverlapPointAll(transform.position);

        foreach (var hit in hits)
        {
            ZoneArea zone = hit.GetComponent<ZoneArea>();
            if (zone != null)
            {
                studentPresence.UpdateStatusByZone(zone.ZoneName);
                break;
            }
        }
    }
}