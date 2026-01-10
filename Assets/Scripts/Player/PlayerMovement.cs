using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 4f;

    private Rigidbody2D rb;
    private Vector2 movementInput;
    private bool usingUIInput = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Keyboard input (development only)
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        if (moveX != 0 || moveY != 0)
        {
            usingUIInput = false;
            movementInput = new Vector2(moveX, moveY).normalized;
        }
        else
        {
            // Only stop movement if keyboard is the active input source
            if (!usingUIInput)
            {
                movementInput = Vector2.zero;
            }
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = movementInput * moveSpeed;
    }

    // Called by mobile UI buttons / joystick
    public void SetMovement(Vector2 direction)
    {
        usingUIInput = true;
        movementInput = direction.normalized;
    }

    public void MoveUp()
    {
        SetMovement(Vector2.up);
    }

    public void MoveDown()
    {
        SetMovement(Vector2.down);
    }

    public void MoveLeft()
    {
        SetMovement(Vector2.left);
    }

    public void MoveRight()
    {
        SetMovement(Vector2.right);
    }

    public void StopMovement()
    {
        usingUIInput = false;
        movementInput = Vector2.zero;
    }
}