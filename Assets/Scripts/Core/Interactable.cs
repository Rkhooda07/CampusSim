using UnityEngine;

public class Interactable : MonoBehaviour
{
    public GameObject interactionPrompt;

    private bool playerInRange = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            interactionPrompt.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            interactionPrompt.SetActive(false);
        }
    }

    protected bool CanInteract()
    {
        return playerInRange && Input.GetKeyDown(KeyCode.E);
    }
}