using UnityEngine;

public class PetMovement : MonoBehaviour
{
    public enum FacingDirection
    {
        Up,
        Down,
        Left,
        Right
    }

    public float moveSpeed = 4f;

    private Rigidbody2D rb;
    private Vector2 movementInput;
    private bool usingUIInput = false;
    public FacingDirection facingDirection = FacingDirection.Down;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
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
        UpdateFacingDirection(movementInput);
        ApplyFacingVisual();
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

    void UpdateFacingDirection(Vector2 input)
    {
        if (input == Vector2.zero) return;

        if (Mathf.Abs(input.x) > Mathf.Abs(input.y))
        {
            facingDirection = input.x > 0 ? FacingDirection.Right : FacingDirection.Left;
        }
        else
        {
            facingDirection = input.y > 0 ? FacingDirection.Up : FacingDirection.Down;
        }

        Debug.Log("Direction facing: " + facingDirection);
    }

    void ApplyFacingVisual()
    {
        if (spriteRenderer == null) return;

        if (facingDirection == FacingDirection.Left)
            spriteRenderer.flipX = true;
        else if (facingDirection == FacingDirection.Right)
            spriteRenderer.flipX = false;
    }
}