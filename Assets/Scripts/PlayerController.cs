using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public SpriteRenderer sr;
    public float gravityMultiplier = 1f;
    public float moveSpeed;
    public float jumpSpeed;
    public bool isGrounded = false;

    void Start()
    {
        myRigidbody.gravityScale = gravityMultiplier;
    }
    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); //horizontal input (1 or -1)
        float currentVerticalVelocity = myRigidbody.linearVelocity.y; //current vertical velocity

        if (Input.GetKeyDown(KeyCode.W) && isGrounded){
            currentVerticalVelocity = jumpSpeed;
            isGrounded = false;
            // sr.color = Color.red;
        }
        
        Vector2 newVelocity = new Vector2(horizontalInput * moveSpeed, currentVerticalVelocity);
        myRigidbody.linearVelocity = newVelocity;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground")){
            isGrounded = true;
            // sr.color = Color.green;
        }
    }
}