using UnityEngine;

public class NPCIdleMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 1.5f;
    [SerializeField] private float walkTime = 2f;
    [SerializeField] private float waitTime = 2f;
    [SerializeField] private float roamRadius = 1.5f;

    private Rigidbody2D rb;
    private Vector2 startPosition;
    private Vector2 moveDirection;
    private float timer;
    private bool isWalking = false;
    private bool isPausedByDialogue = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        startPosition = rb.position;
        ChooseNewDirection();
    }

    private void Update()
    {
        if (isPausedByDialogue)
        {
            return;
        }

        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            if (isWalking)
                StopWalking();
            else
                StartWalking();
        }
    }

    private void FixedUpdate()
    {
        if (isWalking && !isPausedByDialogue)
        {
            rb.MovePosition(rb.position + moveDirection * moveSpeed * Time.fixedDeltaTime);
        }
    }

    private void StartWalking()
    {
        isWalking = true;
        timer = walkTime;
        ChooseNewDirection();
    }

    private void StopWalking()
    {
        isWalking = false;
        timer = waitTime;
    }

    private void ChooseNewDirection()
    {
        Vector2 randomOffset = Random.insideUnitCircle * roamRadius;
        Vector2 target = startPosition + randomOffset;
        moveDirection = (target - rb.position).normalized;
    }

    // Called by NPCDialogue
    public void PauseMovement()
    {
        isPausedByDialogue = true;
    }

    public void ResumeMovement()
    {
        isPausedByDialogue = false;
    }
}