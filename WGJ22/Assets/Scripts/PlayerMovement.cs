using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float JumpForce;
    public float Speed;
    private Rigidbody2D ridigbody2D;
    private Animator animator;
    private float Horizontal;
    private bool Grounded;

    // Start is called before the first frame update
    void Start()
    {
        ridigbody2D = GetComponent<Rigidbody2D>();
        //animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal") * Speed;

        if(Horizontal < 0.0f) transform.localScale = new Vector3(-0.1578557f, 0.1489582f, 1.0f);
        else if (Horizontal > 0.0f) transform.localScale = new Vector3(0.1578557f, 0.1489582f, 1.0f);

        //animator.SetBool("Walking", Horizontal != 0.0f);

        Debug.DrawRay(transform.position, Vector3.down * 0.1578557f, Color.red);
        if (Physics2D.Raycast(transform.position, Vector3.down, 0.1f))
        {
            Grounded = true;
        }
        else Grounded = false;

        // Salto
        if (Input.GetKeyDown(KeyCode.S) && Grounded)
        {
            Jump();
            Debug.Log("jumping");
        }
    }

    private void Jump(){
        ridigbody2D.AddForce(Vector2.up * JumpForce);
    }

    private void FixedUpdate(){
        ridigbody2D.velocity = new Vector2(Horizontal, ridigbody2D.velocity.y);
    } 
}
