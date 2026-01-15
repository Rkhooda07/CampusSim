using UnityEngine;
using TMPro;

public class NPCDialogue : MonoBehaviour
{
    [Header("Dialogue")]
    [TextArea(2, 4)]
    [SerializeField] private string[] dialogueLines;

    [Header("UI")]
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TextMeshProUGUI dialogueText;

    private Interactable interactable;
    private int currentLine = 0;
    private bool isTalking = false;

    private void Awake()
    {
        interactable = GetComponentInChildren<Interactable>();

        if (dialogueBox != null)
            dialogueBox.SetActive(false);
    }

    private void Update()
    {
        if (interactable == null)
            return;

		if (isTalking && !interactable.CanInteract())
		{
			EndDialogue();
			return;
		}

        // Start or progress dialogue ONLY when player presses E
        if (interactable.CanInteract() && Input.GetKeyDown(KeyCode.E))
        {
            if (!isTalking)
                StartDialogue();
            else
                NextLine();
        }
    }

    private void StartDialogue()
    {
        if (dialogueLines == null || dialogueLines.Length == 0)
            return;

        isTalking = true;
        currentLine = 0;

        interactable.BeginInteraction();

        dialogueBox.SetActive(true);
        dialogueText.text = dialogueLines[currentLine];
    }

    private void NextLine()
    {
        currentLine++;

        if (currentLine >= dialogueLines.Length)
            EndDialogue();
        else
            dialogueText.text = dialogueLines[currentLine];
    }

    private void EndDialogue()
    {
        isTalking = false;

        dialogueBox.SetActive(false);
        interactable.EndInteraction();
    }
}