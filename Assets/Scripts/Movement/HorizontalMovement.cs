using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *   - Bonus: Crear un component que substitueix el 
 *   de moviment per un altre que dona el moviment 
 *   del personatge a l'usuari.
 *  */

public class HorizontalMovement : MonoBehaviour
{
    private float jumpSpeed;
    private float speed;
    private Rigidbody2D rb;

    private Vector2 playerInput;
    private bool shouldJump;
    private bool canJump;

    [SerializeField]
    private int multiplyingFactor = 1000;

    private Animator animator;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        speed = gameObject.GetComponent<DataPlayer>().GetSpeed();
        jumpSpeed = gameObject.GetComponent<DataPlayer>().GetJumpSpeed();

        animator = gameObject.GetComponent<Animator>();
    }

    // get input values each frame
    private void Update()
    {
        // using "GetAxis" allows for many different control schemes to work here
        // go to Edit -> Project Settings -> Input to see and change them
        
        // playerInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        playerInput = new Vector2(Input.GetAxis("Horizontal"), 0);
        animator.SetFloat("Horizontal", playerInput.x);

        if (canJump && Input.GetButtonDown("Jump"))
        {
            canJump = false;
            shouldJump = true;
        }

    }

    // apply physics movement based on input values
    private void FixedUpdate()
    {
        // move
        if (playerInput != Vector2.zero)
        {
            rb.AddForce(multiplyingFactor * playerInput * speed * Time.fixedDeltaTime, ForceMode2D.Impulse);
        }

        // jump
        if (shouldJump)
        {
            rb.AddForce(multiplyingFactor * Vector2.up * jumpSpeed, ForceMode2D.Impulse);
            shouldJump = false;
            animator.SetBool("Jump", true);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        // allow jumping again
        if (col.gameObject.CompareTag("Floor"))
        {
            canJump = true;
            gameObject.transform.tag = "onFloor";
            animator.SetBool("Jump", false);
        }
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        gameObject.transform.tag = "Jumping";
    }

    public bool GetMoving()
    {
        if (MovingX()) return true;
        else return false;
    }

    public bool MovingX()
    {
        if (Input.GetAxis("Horizontal") > 0 || Input.GetAxis("Horizontal") < 0) return true;
        else return false;
    }

    public bool FacingRight()
    {
        if (Input.GetAxis("Horizontal") > 0) return true;
        else return false;
    }

    public bool FacingLeft()
    {
        if (Input.GetAxis("Horizontal")< 0) return true;
        else return false;
    }

    private void OnEnable()
    {
        Start();
    }

}

