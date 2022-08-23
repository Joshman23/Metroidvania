using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class Playermovement : MonoBehaviour
{
    //necesary for animation and physics
    private Rigidbody2D rb2D;
    private Animator myAnimator;

    private bool facingright = true;

    //variables to play with
    public float speed = 2.0f;
    public float horizmovement;// = [1OR]-1[OR]0

   private void Start()
    {
        // define the game objects found on the player
        rb2D = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
       
    }

    // handles the input for physics 
   private void Update()
    {
        // check direcrtion given by player
        horizmovement = Input.GetAxis("Horizontal");
    }
    // handles running the physics
    private void FixedUpdate()
    {
        // move the chracter left and right
        rb2D.velocity = new Vector2(horizmovement * speed, rb2D.velocity.y);
        Flip(horizmovement);
        myAnimator.SetFloat("speed", Mathf.Abs(horizmovement));
    }
    // Flipping function
    private void Flip(float horizontal)
    {
        if (horizontal <0 && facingright || horizontal > 0 && !facingright)
        {
            facingright = !facingright;

            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }
}
