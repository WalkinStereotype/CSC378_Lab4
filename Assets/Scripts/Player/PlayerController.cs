using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public SpriteRenderer sr;
    public float gravityMultiplier = 1f;
    public float moveSpeed;
    public float jumpSpeed;
    public bool isGrounded = false;

    public Animator animator;

    public float yBoundary;

    void Start()
    {
        myRigidbody.gravityScale = gravityMultiplier;
    }
    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); //horizontal input (1 or -1)
        float currentVerticalVelocity = myRigidbody.linearVelocity.y; //current vertical velocity

        // Check if we fell off the map
        if(transform.position.y < yBoundary)
        {
            GameManager.instance.ShowGameOverScreen(false);
        }

        if (Input.GetKeyDown(KeyCode.W) && isGrounded){
            currentVerticalVelocity = jumpSpeed;
            isGrounded = false;
            animator.SetBool("Jump", true);
            // sr.color = Color.red;
        }
        
        Vector2 newVelocity = new Vector2(horizontalInput * moveSpeed, currentVerticalVelocity);
        myRigidbody.linearVelocity = newVelocity;

        animator.SetFloat("Run", Mathf.Abs(horizontalInput));
        sr.flipX = horizontalInput < 0f;
        animator.SetFloat("Vertical", currentVerticalVelocity);
        

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            isGrounded = true;
            animator.SetBool("Jump", false);
            // sr.color = Color.green;
        } 
        else if (collision.gameObject.layer == LayerMask.NameToLayer("Goal"))
        {
            GameManager.instance.ShowGameOverScreen(true);
        }
    }
}