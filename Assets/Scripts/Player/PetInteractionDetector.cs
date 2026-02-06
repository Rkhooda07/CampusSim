using UnityEngine;

public class PetInteractionDetector : MonoBehaviour
{
    private Interactable currentInteractable;

    private void OnTriggerEnter2D(Collider2D other)
    {
        var interactable = other.GetComponent<Interactable>();
        if (interactable != null)
            currentInteractable = interactable;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        var interactable = other.GetComponent<Interactable>();
        if (interactable != null && interactable == currentInteractable)
            currentInteractable = null;
    }

    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.E)) return;

        if (currentInteractable != null)
            currentInteractable.Interact(gameObject);
    }
}