using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    // Movement Speed
    public float moveSpeed;
    private Rigidbody2D myRigidbody;

    // Jump Speed
    public float jumpSpeed;

    // Ground Check 
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;

    public bool isGrounded;

    // Animation 
    private Animator myAnim;

	// Use this for initialization
	void Start () {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        // Ground Check Cont. 

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

        // Player movement x-axis 
        if (Input.GetAxisRaw("Horizontal") > 0f)
        {
            myRigidbody.velocity = new Vector3(moveSpeed, myRigidbody.velocity.y, 0f); // Right Movement
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (Input.GetAxisRaw("Horizontal") < 0f)
        {
            myRigidbody.velocity = new Vector3(-moveSpeed, myRigidbody.velocity.y, 0f); // Left Movement 
			transform.localScale = new Vector3(-1f, 1f, 1f);
        } else {
            myRigidbody.velocity = new Vector3(0f, myRigidbody.velocity.y, 0f); // Idle 
        }

        // Jumping mechanics 
        if (Input.GetButtonDown("Jump") && isGrounded) 
        {
            myRigidbody.velocity = new Vector3(myRigidbody.velocity.x, jumpSpeed, 0f);
        }

        /* Animation - Mathf.Abs will cause the myRigidbody.velocity.x to turn positive,
         * thus when the player is moving backwards (at Speed = -5), the value will change to
         * +5, thus the "walking" character animation should still work when the player is
         * moving to the left. 
         */
        myAnim.SetFloat("Speed", Mathf.Abs(myRigidbody.velocity.x));
        myAnim.SetBool("Grounded", isGrounded);
	}
}
