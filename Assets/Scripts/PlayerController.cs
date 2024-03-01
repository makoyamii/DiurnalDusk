using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 1f;
    public Rigidbody2D rb;
    Vector2 movement;
    public Animator animator;

    void Update() {
        //Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

    }

    void FixedUpdate() {
        //Movement
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }









    //weird movement starts here
    /*
    public float moveSpeed = 1f;
    public float collisionOffset = 0.05f;
    public ContactFilter2D movementFilter;
    Vector2 movementInput;
    Rigidbody2D rb;
    Animator animator;
    List<RaycastHit2D> castCollisions = new List <RaycastHit2D>();

    public LayerMask solidObjectsLayer;
    public LayerMask interactablesLayer;
    

    // Update is called once per frame
    void Update()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate() {

        
        //If movement is not 0, try to move
        if(movementInput != Vector2.zero) {
            int count = rb.Cast(
                movementInput, //x and y values between -1 and 1 that represent the direction frnm the body to look for collisions
                movementFilter, //settings that determine where a collision can occur on such as layer to collide with
                castCollisions, //list of collisions to store the found collisions into after the cast is finished
                moveSpeed * Time.fixedDeltaTime + collisionOffset); //the amount to cast equal to the movement plus an offset
                
            if(count == 0) {
                rb.MovePosition(rb.position + movementInput * moveSpeed * Time.fixedDeltaTime);
            }   
        }


        if(Input.GetKeyDown(KeyCode.Z)) {
            Interact();
        }


    }

    void OnMove(InputValue movementValue) {
        movementInput = movementValue.Get<Vector2>();
    }

    void Interact() {
        //if there is an interactable within range:
        
    }
    */


    
}



