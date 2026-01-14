using UnityEngine;
using TMPro;

public class Interactable : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private GameObject interactionPrompt;
    [SerializeField] private TextMeshProUGUI promptText;
    [TextArea] public string promptMessage = "Press E";

    private bool playerInRange = false;

    private void Awake()
    {
        if (interactionPrompt != null)
            interactionPrompt.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        playerInRange = true;

        if (interactionPrompt != null)
        {
            promptText.text = promptMessage;
            interactionPrompt.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        playerInRange = false;

        if (interactionPrompt != null)
            interactionPrompt.SetActive(false);
    }

    public bool CanInteract()
    {
        return playerInRange && Input.GetKeyDown(KeyCode.E);
    }
}