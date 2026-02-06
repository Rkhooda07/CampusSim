using UnityEngine;

public class PetInteractionLock : MonoBehaviour
{
    private PetMovement petMovement;
    private NPCIdleMovement npcIdleMovement;
    private Rigidbody2D rb;

    private void Awake()
    {
        petMovement = GetComponent<PetMovement>();
        npcIdleMovement = GetComponent<NPCIdleMovement>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void Lock()
    {
        // Lock player-controlled pet movement
        if (petMovement != null)
            petMovement.enabled = false;

        // Lock NPC idle movement
        if (npcIdleMovement != null)
            npcIdleMovement.enabled = false;

        // Stop any residual physics motion
        if (rb != null)
            rb.linearVelocity = Vector2.zero;
    }

    public void Unlock()
    {
        // Unlock player-controlled pet movement
        if (petMovement != null)
            petMovement.enabled = true;

        // Unlock NPC idle movement
        if (npcIdleMovement != null)
            npcIdleMovement.enabled = true;
    }
}