using UnityEngine;

public class StudentPresence : MonoBehaviour
{
    public enum Status
    {
        Available,
        Studying,
        Eating,
        Busy
    }

    private Status currentStatus = Status.Available;

    public string CurrentStatus => currentStatus.ToString();

    // called by zone trigger
    public void UpdateStatusByZone(string zoneName)
    {
        switch (zoneName)
        {
            case "Library":
            case "A Block":
            case "B Block":
            case "C Block":
            case "D Block":
            case "E Block":
            case "G Block":
                currentStatus = Status.Studying;
                break;

            case "Shop":
            case "Nescafe":
            case "Old Canteen":
            case "Canteen / Mess":
            case "Bunny's Kitchen":
                currentStatus = Status.Eating;
                break;

            case "Admin Block":
            case "Boys Hostel":
            case "Girls Hostel":
                currentStatus = Status.Busy;
                break;

            case "Ground":
            case "Garden":
            case "Open Air Theater":
            case "Parking Area":
            case "VolleyBall court":
            case "BasketBall Court":
                currentStatus = Status.Available;
                break;

            default:
                currentStatus = Status.Available;
                break;
        }
    }
}