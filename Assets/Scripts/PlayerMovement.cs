using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private new Rigidbody2D rigidbody2D;
    private BoxCollider2D boxCollider2D;
    private SpriteRenderer sprite;
    private Animator animator;

    private float directionX = 0f;
    [SerializeField] private LayerMask ground;
    [SerializeField] private float movementSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;

    private enum MovementState { idle, running, jumping, falling }
    
    private void Start() {
        rigidbody2D = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }


    private void Update() {
        directionX = Input.GetAxisRaw("Horizontal");
        rigidbody2D.velocity = new Vector2(directionX * movementSpeed, rigidbody2D.velocity.y);

        if (Input.GetButtonDown("Jump") && isGrounded()) {
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpForce);
        }

        UpadteAnimation();
    }

    private void UpadteAnimation() {
        MovementState movementState;

        if (directionX > 0f) {
            movementState = MovementState.running;
            sprite.flipX = false; 
        } else if (directionX < 0f) {
            movementState = MovementState.running;
            sprite.flipX = true; 
        } else {
            movementState = MovementState.idle;
        }

        if (rigidbody2D.velocity.y > 0.1f) {
            movementState = MovementState.jumping;
        } else if (rigidbody2D.velocity.y < -0.1f) {
            movementState = MovementState.falling;
        }

        animator.SetInteger("movementState", (int) movementState);
    }

    private bool isGrounded() {
        return Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, Vector2.down, 0.1f, ground);
    }
}
