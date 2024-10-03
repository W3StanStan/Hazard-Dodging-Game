using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
	[SerializeField] private float jumpForce;

	private Rigidbody2D rb;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius;
    [SerializeField] private LayerMask groundMask;

    [SerializeField] private float jumpBufferWindow;
    private float jumpBufferCountdown;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        bool isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundMask);

        Debug.Log(isGrounded);

        float moveSpeed = Input.GetAxisRaw("Horizontal") * speed;

        if (Input.GetButtonDown("JumpButton"))
        {
            jumpBufferCountdown = jumpBufferWindow;
        }

        jumpBufferCountdown -= Time.deltaTime; 

        if (jumpBufferCountdown > 0 && isGrounded)
        {
			rb.velocity = new Vector2(rb.velocity.x, jumpForce);
		}

        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
    }
}
