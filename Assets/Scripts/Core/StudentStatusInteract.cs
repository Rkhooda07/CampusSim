using UnityEngine;
using TMPro;

public class StudentStatusInteract : Interactable
{
    [Header("UI")]
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TextMeshProUGUI dialogueText;

    private StudentPresence presence;

    private void Awake()
    {
        presence = GetComponentInParent<StudentPresence>();
    }

    private void Start()
    {
        promptMessage = "Press E to check status";
    }

    public override void Interact(GameObject interactor)
    {
        if (!CanInteract()) return;

        BeginInteraction();

        if (dialogueBox != null)
            dialogueBox.SetActive(true);

        if (dialogueText != null && presence != null)
            dialogueText.text = $"Student is {presence.CurrentStatus}";

        // Auto end interaction after short delay
        Invoke(nameof(EndStudentInteraction), 2f);
    }

    private void EndStudentInteraction()
    {
        if (dialogueBox != null)
            dialogueBox.SetActive(false);

        EndInteraction();
    }
}