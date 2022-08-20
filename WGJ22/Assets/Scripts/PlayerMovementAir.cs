using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementAir : MonoBehaviour
{
    public float JumpForce;
    public float Speed;
    private Rigidbody2D ridigbody2D;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private float Horizontal;
    private bool Grounded;

    // Start is called before the first frame update
    void Start()
    {
        ridigbody2D = GetComponent<Rigidbody2D>();
        Physics2D.gravity = new Vector2(0, 9.8f);
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal") * Speed;

        if(Horizontal < 0.0f) spriteRenderer.flipX = true;
        else if (Horizontal > 0.0f) spriteRenderer.flipX = false;

        animator.SetBool("isRunning", Horizontal != 0.0f);

        Debug.DrawRay(transform.position, Vector3.down * 0.4f, Color.red);
        if (Physics2D.Raycast(transform.position, Vector3.down, 0.1f))
        {
            Grounded = true;
        }
        else Grounded = false;

        // Salto
        if (Input.GetKeyDown(KeyCode.W) && Grounded)
        {
            Jump();
            Debug.Log("jumping");
        }

    }

    private void Jump(){
        ridigbody2D.AddForce(Vector2.down * JumpForce);
    }

    private void FixedUpdate(){
        ridigbody2D.velocity = new Vector2(Horizontal * -1, ridigbody2D.velocity.y);
    } 
}
