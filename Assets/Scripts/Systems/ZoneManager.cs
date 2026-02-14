using UnityEngine;
using TMPro;

public class ZoneManager : MonoBehaviour
{
    public static ZoneManager Instance;

    [SerializeField] private TextMeshProUGUI zoneText;

    private string currentZone = "";

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void EnterZone(string zoneName)
    {
        currentZone = zoneName;

        if (zoneText != null)
            zoneText.text = zoneName;
    }

    public void ExitZone(string zoneName)
    {
        if (currentZone == zoneName)
        {
            currentZone = "";

            if (zoneText != null)
                zoneText.text = "";
        }
    }
}