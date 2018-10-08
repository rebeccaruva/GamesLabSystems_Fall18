using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    float jumpForce = 150f;
    private int jumps = 0;
    private int maxJumps = 1; //double jump max

    public bool jumpPress = false;
    float jumpTime = 0; //how long you can hold down jump button

    float speed = 10f;

    private Rigidbody2D rb;

    public bool grounded = false;
    public Transform footPos;
    public LayerMask whatIsGround;

    public GameObject scrunchie;

    public GameObject book;
    public bool bookPower = false;

    // private float previousPos;
    private SpriteRenderer sr;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        // previousPos = transform.position.x;
    }

    void Update() {
        //move
        float xSpeed = Input.GetAxisRaw("Horizontal") * speed; //raw doesn't have easing
        float ySpeed = rb.velocity.y;

        //overlap circle for jump
        grounded = Physics2D.OverlapCircle(footPos.position, 0.5f, whatIsGround);

        //double jump
        if (grounded)
        {
            jumps = maxJumps;
        }

        //jump
        if (Input.GetKeyDown("up") && (jumps > 0))
        {
            jumps--;
            ySpeed = 0;
            jumpPress = true;
            jumpTime = Time.time;
        }

        //end jump
        if (Input.GetKeyUp("up"))
        {
            jumpPress = false;
        }

        //calculate move after jump stuff
        rb.velocity = new Vector2(xSpeed, ySpeed);

        //boomerang scrunchie
        if (Input.GetButtonDown("Jump")) {
            GameObject newScrunchie = Instantiate(scrunchie, this.transform.position, this.transform.rotation) as GameObject;
            newScrunchie.GetComponent<ScrunchieControl>().direction = -1; //replace with whatever direction
        }

        //throw book
		if(Input.GetKey(KeyCode.LeftShift)) {// && bookPower
			GameObject newBook = Instantiate(book, this.transform.position, this.transform.rotation) as GameObject;
			newBook.GetComponent<BookControl>().direction = -1; //replace with whatever direction
		}

        //player sprite flip
        if (rb.velocity.x > 0) {
            sr.flipX = true;
        } else {
            sr.flipX = false;
        }
    }

    void FixedUpdate() {
        //longer you hold down, the higher you jump
        if (jumpPress)
        {
            if (Time.time - jumpTime < .11f)
            {
                rb.AddForce(new Vector2(0, jumpForce));
            }
        }
    }
}
