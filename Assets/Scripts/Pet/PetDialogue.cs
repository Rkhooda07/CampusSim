using UnityEngine;
using TMPro;

public class PetDialogue : Interactable
{
    [Header("Dialogue")]
    [TextArea(2, 4)]
    [SerializeField] private string[] dialogueLines;

    [Header("UI")]
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TextMeshProUGUI dialogueText;

    private int currentLineIndex = -1;
    private bool isTalking = false;

    private PetInteractionLock thisPetLock;
    private PetInteractionLock otherPetLock;

    private void Awake()
    {
        thisPetLock = GetComponent<PetInteractionLock>();
        if (dialogueBox != null)
            dialogueBox.SetActive(false);
    }

    public override void Interact(GameObject interactor)
    {
        if (interactor == null || !interactor.CompareTag("Pet"))
            return;

        // Dialogue already running → advance exactly ONE line
        if (isTalking)
        {
            ShowNextLine();
            return;
        }

        // Start dialogue
        if (dialogueLines == null || dialogueLines.Length == 0)
            return;

        StartDialogue(interactor);
    }

    private void StartDialogue(GameObject interactor)
    {
        isTalking = true;
        currentLineIndex = -1;

        BeginInteraction();

        otherPetLock = interactor.GetComponent<PetInteractionLock>();

        if (thisPetLock != null) thisPetLock.Lock();
        if (otherPetLock != null) otherPetLock.Lock();

        dialogueBox.SetActive(true);

        ShowNextLine(); // FIRST line always comes from here
    }

    private void ShowNextLine()
    {
        currentLineIndex++;

        if (currentLineIndex < dialogueLines.Length)
        {
            dialogueText.text = dialogueLines[currentLineIndex];
        }
        else
        {
            EndDialogue();
        }
    }

    private void EndDialogue()
    {
        isTalking = false;
        dialogueBox.SetActive(false);

        if (thisPetLock != null) thisPetLock.Unlock();
        if (otherPetLock != null) otherPetLock.Unlock();

        EndInteraction();
    }
}