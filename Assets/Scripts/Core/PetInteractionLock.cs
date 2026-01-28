using UnityEngine;

public class PlayerInteractionLock : MonoBehaviour
{
    private PlayerMovement playerMovement; // or whatever your movement script is called

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    public void Lock()
    {
        if (playerMovement != null)
            playerMovement.enabled = false;
    }

    public void Unlock()
    {
        if (playerMovement != null)
            playerMovement.enabled = true;
    }
}