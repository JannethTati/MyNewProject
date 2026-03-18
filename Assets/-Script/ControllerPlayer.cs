using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerPlayer : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;


    private Rigidbody2D rb;
    private Animator anim;

    public Transform groundCheck;
    public float groundRadius = 0.5f;
    public LayerMask groundLayer;
    private bool isGrounded = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }    

    void Update()
    {
        CheckGround();
        Move();
        Jump();
        UpdateAnimation();
    }
        void Move()
    {
        float move = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(move * speed, rb.linearVelocity.y);

        // Girar personaje
        if (move > 0) transform.localScale = new Vector3(1, 1, 1);
        else if (move < 0) transform.localScale = new Vector3(-1, 1, 1);
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            isGrounded = false;
        }
    }

    void CheckGround()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundLayer);
    }
    void UpdateAnimation()
    {
        float move = Mathf.Abs(rb.linearVelocity.x);
        anim.SetBool("Running", move > 0.1f);   // Controla Idle/Run
        anim.SetBool("IsJumping", !isGrounded);
        anim.SetBool("Falling", rb.linearVelocity.y < -0.1f);
    }
}
