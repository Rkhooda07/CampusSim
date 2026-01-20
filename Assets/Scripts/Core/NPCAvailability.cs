using UnityEngine;

public class NPCAvailability : MonoBehaviour
{
    public enum NPCState
    {
        Available,
        Busy,
        Ambient
    }

    [Header("NPC State")]
    public NPCState currentState = NPCState.Available;

    [Header("Busy Response")]
    [TextArea]
    public string busyMessage = "Sorry, I'm busy right now.";

    public bool CanTalk()
    {
        return currentState == NPCState.Available;
    }

    public bool IsAmbient()
    {
        return currentState == NPCState.Ambient;
    }
}