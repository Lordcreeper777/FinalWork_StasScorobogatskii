using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 6f;
    public float jumpForce = 12f;

    [Header("Ground Check")]
    public Transform groundCheck;
    public float groundCheckRadius = 0.1f;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private Animator anim;

    private bool isGrounded;
    private bool animatorReady;
    private float moveInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        animatorReady = false;

        anim.SetBool("isWalking", false);
        anim.SetBool("isGrounded", true);
        anim.SetFloat("yVelocity", 0f);

        Invoke(nameof(EnableAnimatorUpdates), 0.1f);
    }

    void EnableAnimatorUpdates()
    {
        animatorReady = true;
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(
            groundCheck.position,
            groundCheckRadius,
            groundLayer
        );

        moveInput = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(
                rb.velocity.x,
                jumpForce
            );
        }

        if (moveInput > 0)
        {
            transform.localScale = new Vector3(0.4f, 0.4f, 1f);
        }
        else if (moveInput < 0)
        {
            transform.localScale = new Vector3(-0.4f, 0.4f, 1f);
        }

        if (animatorReady)
        {
            anim.SetBool("isWalking", moveInput != 0);
            anim.SetBool("isGrounded", isGrounded);
            anim.SetFloat("yVelocity", rb.velocity.y);
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(
            moveInput * moveSpeed,
            rb.velocity.y
        );
    }

    void OnDrawGizmosSelected()
    {
        if (groundCheck == null)
            return;

        Gizmos.DrawWireSphere(
            groundCheck.position,
            groundCheckRadius
        );
    }
}