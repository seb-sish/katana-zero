using UnityEngine;

public class SamuraiMovement : MonoBehaviour
{
    private Animator Animator;
    public float moveInput;

    public float moveSpeed = 3f;
    public float maxSpeed = 5f;
    public float jumpForce = 5f;
    public float friction = 0.25f;

    private Rigidbody2D rb;

    private bool IsFacingRight = true;
    private Vector2 movement;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isGrounded = false;
            Animator.SetTrigger("Jump");
        }
    }

    void FixedUpdate()
    {
        if (IsFacingRight == false && movement.x > 0)
        {
            Flip();
        }
        else if (IsFacingRight == true && movement.x < 0)
        {
            Flip();
        }

        if (Mathf.Abs(rb.velocity.x) < maxSpeed)
        {
            rb.AddForce(movement * moveSpeed, ForceMode2D.Impulse);
        }

        if (movement.x == 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x * friction, rb.velocity.y);
        }

        isGrounded = false;
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        foreach (ContactPoint2D contact in collision.contacts)
        {
            if (Vector2.Angle(contact.normal, Vector2.up) < 45f)
            {
                isGrounded = true;
                break;
            }
        }
    }

    private void Flip()
    {
        IsFacingRight = !IsFacingRight;

        Vector3 Scale = transform.localScale;
        Scale.x *= -1;

        transform.localScale = Scale;
    }
}
