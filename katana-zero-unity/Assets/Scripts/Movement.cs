using UnityEngine;

public class Movement : MonoBehaviour
{
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask ground;
    public float moveInput;
    public float Speed;
    public float JumpForce;

    private Rigidbody2D Rigidbody2D;
    private Animator Animator;

    private bool IsFacingRight = true;
    private bool IsJumping = false;
    private bool IsGrounded = true;

    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
    }

    void Update()
    {
        IsGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, ground);
        moveInput = Input.GetAxis("Horizontal");

        if (IsGrounded)
        {
            Debug.Log("IsGrounded");
            Animator.SetFloat("Velocity", Mathf.Abs(moveInput));
        }

        if (Input.GetButtonDown("Jump") && IsGrounded && !IsJumping)
        {
            Debug.Log("Jump and Grounded");
            IsJumping = true;
            Animator.SetTrigger("Jump");
        }
    }

    private void FixedUpdate()
    {
        Rigidbody2D.velocity = new Vector2(moveInput * Speed, Rigidbody2D.velocity.y);

        if (IsFacingRight == false && moveInput > 0)
        {
            Flip();
        }
        else if (IsFacingRight == true && moveInput < 0)
        {
            Flip();
        }

        if (IsJumping)
        {
            Debug.Log("Jump");
            Rigidbody2D.AddForce(new Vector2(0f, JumpForce));
            IsJumping = false;
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