using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;

    private Rigidbody2D rb;
    private bool isGrounded;

    // Input value (-1 = left, 0 = stop, 1 = right)
    private float moveInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Keyboard support (for testing)
        float keyboardInput = Input.GetAxis("Horizontal");
        if (keyboardInput != 0)
        {
            moveInput = keyboardInput;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
    }

    // ===== METHODS FOR MOBILE BUTTONS =====

    public void MoveLeft()
    {
        moveInput = -1f;
    }

    public void MoveRight()
    {
        moveInput = 1f;
    }

    public void StopMoving()
    {
        moveInput = 0f;
    }

    public void Jump()
    {
        if (isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

    // ===== GROUND CHECK =====

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}