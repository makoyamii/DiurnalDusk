using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerWisp : MonoBehaviour
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
        rb.MovePosition(rb.position + movement * (moveSpeed * Time.fixedDeltaTime));
    }


}
