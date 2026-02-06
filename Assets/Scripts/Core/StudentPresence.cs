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

    [SerializeField]
    private Status currentStatus = Status.Available;

    public string CurrentStatus => currentStatus.ToString();
}