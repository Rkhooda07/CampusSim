using UnityEngine;
using TMPro;

public class Interactable : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private GameObject interactionPrompt;
    [SerializeField] private TextMeshProUGUI promptText;
    [TextArea] public string promptMessage = "Press E";

    private bool petInRange = false;
    private bool isInteracting = false;

    private void Awake()
    {
        if (interactionPrompt != null)
            interactionPrompt.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Pet")) return;

        petInRange = true;

        if (interactionPrompt != null && !isInteracting)
        {
            promptText.text = promptMessage;
            interactionPrompt.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Pet")) return;

        petInRange = false;

        if (interactionPrompt != null)
            interactionPrompt.SetActive(false);
    }

    public virtual void Interact(GameObject interactor)
    {
        // Overridden by subclasses
    }

    public void BeginInteraction()
    {
        isInteracting = true;
        if (interactionPrompt != null)
            interactionPrompt.SetActive(false);
    }

    public void EndInteraction()
    {
        isInteracting = false;
        if (interactionPrompt != null && petInRange)
        {
            promptText.text = promptMessage;
            interactionPrompt.SetActive(true);
        }
    }

    public bool CanInteract()
    {
        return petInRange && !isInteracting;
    }
}