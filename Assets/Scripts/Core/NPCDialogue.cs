using UnityEngine;
using TMPro;

public class NPCDialogue : MonoBehaviour
{
    private NPCAvailability availability;

    [Header("Dialogue")]
    [TextArea(2, 4)]
    [SerializeField] private string[] dialogueLines;

    [Header("UI")]
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TextMeshProUGUI dialogueText;

    private Interactable interactable;
    private int currentLine = 0;
    private bool isTalking = false;
	private NPCIdleMovement idleMovement;

    private PetInteractionLock interactionLock;
    private SpriteRenderer npcSprite;
    private Transform player;

    private void Awake()
    {
        availability = GetComponent<NPCAvailability>();

        interactable = GetComponentInChildren<Interactable>();
		idleMovement = GetComponent<NPCIdleMovement>();

        if (dialogueBox != null)
            dialogueBox.SetActive(false);

        interactionLock = GetComponent<PetInteractionLock>();

        npcSprite = GetComponent<SpriteRenderer>();

        GameObject playerObj = GameObject.FindWithTag("Player");
        if (playerObj != null)
            player = playerObj.transform;
    }

    private void Update()
    {
        if (availability != null && availability.IsAmbient())
            return;

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
            {
                if (availability != null && !availability.CanTalk())
                {
                    ShowBusyMessage();
                    return;
                }
                StartDialogue();
            }
            else
                NextLine();
        }
    }

    private void FacePlayer()
    {
        if (player == null || npcSprite == null)
            return;

        float direction = player.position.x - transform.position.x;

        npcSprite.flipX = direction < 0;

        Debug.Log(direction < 0 ? "NPC facing LEFT" : "NPC facing RIGHT");
    }

    private void StartDialogue()
    {
        if (dialogueLines == null || dialogueLines.Length == 0)
            return;

        isTalking = true;
        currentLine = 0;

        interactable.BeginInteraction();

        if (interactionLock != null)
            interactionLock.Lock();

        FacePlayer();

		if (idleMovement != null)
		{
			idleMovement.PauseMovement();
		}

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

        if (interactionLock != null)
            interactionLock.Unlock();

		if (idleMovement != null)
			idleMovement.ResumeMovement();
    }

    private void ShowBusyMessage()
    {
        if (dialogueBox == null || dialogueText == null)
            return;

        dialogueBox.SetActive(true);
        dialogueText.text = availability.busyMessage;

        Invoke(nameof(HideBusyMessage), 1.5f);
    }

    private void HideBusyMessage()
    {
        dialogueBox.SetActive(false);
    }

    public void ShowSingleLine(string message)
    {
        isTalking = false;
        currentLine = 0;
        dialogueBox.SetActive(true);
        dialogueText.text = message;
    }
}