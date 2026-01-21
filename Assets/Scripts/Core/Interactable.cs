using UnityEngine;
using TMPro;

public class Interactable : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private GameObject interactionPrompt;
    [SerializeField] private TextMeshProUGUI promptText;
    [TextArea] public string promptMessage = "Press E";

    private bool playerInRange = false;
    private bool isInteracting = false;

    private void Awake()
    {
        if (interactionPrompt != null)
            interactionPrompt.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        playerInRange = true;

        if (interactionPrompt != null && !isInteracting)
        {
            promptText.text = promptMessage;
            interactionPrompt.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        playerInRange = false;

        if (interactionPrompt != null && !isInteracting)
            interactionPrompt.SetActive(false);
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
        if (interactionPrompt != null && playerInRange)
        {
            promptText.text = promptMessage;
            interactionPrompt.SetActive(true);
        }
    }

    public bool CanInteract()
    {
        return playerInRange;
    }
}